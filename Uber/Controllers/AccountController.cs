using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using NuGet.Protocol.Plugins;
using System.Text;
using System.Text.Encodings.Web;
using Uber.Core.Contracts;
using Uber.Core.Models;
using Uber.Models.Account;

namespace Uber.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginViewModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IEmailSender _emailSender;
        private readonly IPersonService _personService;
        private readonly IClientService _clientService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(SignInManager<IdentityUser> signInManager,
            ILogger<LoginViewModel> logger,
            UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            IEmailSender emailSender,
            IPersonService personService,
            IClientService clientService,
            RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _userStore = userStore;
            _emailSender = emailSender;
            _personService = personService;
            _clientService = clientService;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            var loginVM = new LoginViewModel {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            return View(loginVM);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            viewModel.ReturnUrl ??= Url.Content("~/");

            viewModel.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User was successfully logged in.");
                    //return LocalRedirect(viewModel.ReturnUrl); // TODO: with return Url
                    return RedirectToAction("Index", "Home");
                }
                // TODO :: add two-factor requirement check

                else
                {
                    ModelState.AddModelError(string.Empty, "The login was invalid.");
                    return View(viewModel);
                }
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Register(string? returnUrl = null)
        {
            var loginVM = new RegisterViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            return View(loginVM);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            viewModel.ReturnUrl ??= Url.Content("~/");
            viewModel.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                IdentityUser user;
                try
                {
                    user = new IdentityUser()
                    {
                        UserName = viewModel.Email,
                        Email = viewModel.Email,
                        NormalizedUserName = viewModel.Email.ToUpper(),
                        NormalizedEmail = viewModel.Email.ToUpper()
                    };
                }
                catch
                {
                    throw new InvalidOperationException($"Can't create an instance of {nameof(IdentityUser)}.");
                }

                var result = await _userManager.CreateAsync(user, viewModel.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("New user was successfully created.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    await _personService.CreatePerson(userId, new PersonViewModel()
                    {
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName,
                        Gender = viewModel.Gender,
                        Age = viewModel.Age
                    });

                    var people = await _personService.GetAllPeople();
                    var currentPerson = people.Where(p => p.UserId == userId).FirstOrDefault();

                    if (currentPerson != null) 
                    {
                        await _clientService.CreateClient(currentPerson.Id);
                    }

                    var role = await _roleManager.FindByNameAsync("Client");
                    _userManager.AddToRoleAsync(user, role.Name).Wait();

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    var callbackUrl = Url.Action("ConfirmEmail", "Account", values: new { userId = userId, code = code, returnUrl = viewModel.ReturnUrl },
                    protocol: Request.Scheme);

                    if (callbackUrl != null)
                        await _emailSender.SendEmailAsync(viewModel.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        //return RedirectToPage("Index", new { email = viewModel.Email, returnUrl = viewModel.ReturnUrl });
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(viewModel.ReturnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction("Index", "Home"); // TODO : make a toastr pop-up to show the error
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            var confirmEmailVM = new ConfirmEmailModel
            {
                StatusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email."
            };

            return View(confirmEmailVM);
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(viewModel.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    return RedirectToAction("Index", "Home"); // TODO : make a toastr pop-up to show the error
                }
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                var passwordResetLink = Url.Action("ResetPassword", "Account",
                    new { email = viewModel.Email, token = code }, Request.Scheme);

                _logger.Log(LogLevel.Warning, passwordResetLink);

                if (passwordResetLink != null)
                {

                    await _emailSender.SendEmailAsync(
                        viewModel.Email,
                       "Reset Password",
                       $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(passwordResetLink)}'>clicking here</a>.");
                }
                return RedirectToAction("Index", "Home"); // TODO : make a toastr to inform the user that the reset pass token was sent
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                ModelState.AddModelError("ResetPassError", "Invalid reset password token");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(viewModel.Email);
                if (user == null)
                {
                    return RedirectToAction("Index", "Home"); // TODO : make a toastr pop-up to show the error
                }
                var result = await _userManager.ResetPasswordAsync(user, Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(viewModel.Token)), viewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home"); // make a toastr to inform the user that the password was successfully reset
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(viewModel);
            }
            return View(viewModel);
        }

        [HttpGet]
        [Authorize] // TODO : is it needed
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("Login", "Account");
                }

                var result = await _userManager.ChangePasswordAsync(user, viewModel.CurrentPassword, viewModel.NewPassword);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }

                await _signInManager.RefreshSignInAsync(user);
                return RedirectToAction("Index", "Home"); // make a toastr pop-up to inform that the password was successfully changed
            }
            return View(viewModel);
        }

        [HttpGet]
        [Authorize] // is it needed
        public async Task<IActionResult> ChangeEmail() 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var viewModel = await LoadVMForChangeEmail(user);
            return View(viewModel);
        }

        private async Task<ChangeEmailViewModel> LoadVMForChangeEmail(IdentityUser user) 
        {
            var email = await _userManager.GetEmailAsync(user);
            var viewModel = new ChangeEmailViewModel()
            {
                CurrentEmail = email,
                NewEmail = email,
                IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user)
            };
            return viewModel;
        }

        [HttpPost]
        public async Task<IActionResult> ChangeEmail(ChangeEmailViewModel viewModel) 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var email = await _userManager.GetEmailAsync(user);
            if (email == viewModel.NewEmail) 
            {
                return RedirectToAction("Index", "Home"); // TODO : add toastr to show that the email was unchanged
            }
            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateChangeEmailTokenAsync(user, viewModel.NewEmail);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callBackUrl = Url.Action("ChangeEmailConfirmation", "Account",
                    new { userId = userId, email = viewModel.NewEmail, code = code }, Request.Scheme);

            if (callBackUrl != null)
            {
                await _emailSender.SendEmailAsync(
                    viewModel.NewEmail, "Confirm your email", $"Please confirm your account by  <a href='{HtmlEncoder.Default.Encode(callBackUrl)}'>clicking here</a>.");
            }
            return RedirectToAction("Index", "Home"); // TODO : add toastr to show that the email was successfully changed
        }

        [HttpGet]
        public async Task<IActionResult> ChangeEmailConfirmation(string userId, string email, string code)
        {
            if (userId == null || email == null || code == null)
            {
                return RedirectToAction("Index", "Home"); // TODO : add toastr to show the error
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var result = await _userManager.ChangeEmailAsync(user, email, code);
            if (!result.Succeeded)
            {
                return RedirectToAction("Index", "Home"); // TODO : add toastr to show the error
            }

            var setUserNameResult = await _userManager.SetUserNameAsync(user, email); // TODO : change when the email is no longer the username of the user
            if (!setUserNameResult.Succeeded)
            {
                return RedirectToAction("Index", "Home"); // TODO : add toastr to show the error
            }
            await _signInManager.RefreshSignInAsync(user);
            return View();
        }

        public async Task<IActionResult> Logout(string? returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home"); // TODO: add to toastr to show that the user was successfully logged out
            }
        }
    }
}
