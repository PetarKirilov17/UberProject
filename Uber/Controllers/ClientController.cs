using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;
using Uber.Core.Contracts;
using Uber.Core.Models;
using Uber.Core.OpenRouteService;
using Uber.Infrastructure.Data.Models;
using Uber.Models.Client;
using Uber.Models.Driver;

namespace Uber.Controllers
{
    [Authorize(Roles = "Admin, Client")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IVehicleTypeService _vehicleTypeService;
        private readonly IDriverService _driverService;
        private readonly IPersonService _personService;
        private readonly IAddressService _addressService;
        private readonly IOrderService _orderService;
        private readonly IOrderStatusService _orderStatusService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;

        public ClientController(IClientService clientService, IVehicleTypeService vehicleTypeService,
            IDriverService driverService, IPersonService personService,  IAddressService addressService,
            IOrderService orderService, IOrderStatusService orderStatusService, RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _clientService = clientService;
            _vehicleTypeService = vehicleTypeService;
            _driverService = driverService;
            _personService = personService;
            _addressService = addressService;
            _orderService = orderService;
            _orderStatusService = orderStatusService;
            _roleManager = roleManager;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ApplyForDriver()
        {
            var item = (await _vehicleTypeService.GetAllVehicleTypes()).Select(
                v => new SelectListItem()
                {
                    Text = v.Label,
                    Value = v.TypeId.ToString()
                }).ToList();

            var viewModel = new ApplyForDriverViewModel()
            {
                VehicleCategories = item,
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ApplyForDriver(ApplyForDriverViewModel viewModel)
        {          
            var vehicleTypeIds = viewModel.VehicleCategories.Where(x => x.Selected).Select(y => y.Value)
                .Select(int.Parse).ToList();

            var driverVM = new DriverViewModel()
            {
                DrivingLicence = viewModel.DrivingLicence,
                YearsOfExperience = viewModel.YearsOfExperience,
                Latitude = viewModel.Latitude,
                Longitude = viewModel.Longitude,
                VehicleTypeIds = vehicleTypeIds
            };

            var userId = _userManager.GetUserId(User);
            var user = await _userManager.GetUserAsync(User);
            var currPerson = (await _personService.GetAllPeople()).Where(p => p.UserId == userId).FirstOrDefault();
            if (currPerson == null)
            {
                return NotFound();
            }
            await _driverService.CreateDriver(currPerson.Id, driverVM);
            _userManager.AddToRoleAsync(user, "Driver").Wait();
            
            return RedirectToAction("Index", "Home"); // TODO : add a toastr to notify the client that his application was sccessfully sent
        }

        [HttpGet]
        public IActionResult MakeAnOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MakeAnOrder(MakeAnOrderViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            // create the current address
            AddressViewModel currentAddressVM = new AddressViewModel()
            {
                Latitude = viewModel.CurrentAddressLatitude,
                Longitude = viewModel.CurrentAddressLongitude,
                Description = viewModel.CurrentAddressDescription
            };
            await _addressService.CreateAddress(currentAddressVM);

            var currentAddress = await _addressService.GetLastCreatedAddress();

            // create the destination address
            AddressViewModel destinationAddressVM = new AddressViewModel()
            {
                Latitude = viewModel.DestinationLatitude,
                Longitude = viewModel.DestinationLongitude,
                Description = viewModel.DestinationDescription
            };
            await _addressService.CreateAddress(destinationAddressVM);

            var destinationAddress = await _addressService.GetLastCreatedAddress();

            var userId = _userManager.GetUserId(User);
            var person = (await _personService.GetAllPeople()).Where(p => p.UserId == userId).FirstOrDefault();
            if (person == null)
            {
                return NotFound();
            }
            var client = (await _clientService.GetAllClients()).Where(c => c.PersonId == person.Id).FirstOrDefault();
            if(client == null)
            {
                return NotFound();
            }

            try
            {
                MatrixHandler matrixHandler = new MatrixHandler();
                var closestDriver = await matrixHandler.GetTheClosestDriver(_driverService, viewModel.CurrentAddressLatitude, viewModel.CurrentAddressLongitude);
                var personEntityForDriver = (await _personService.GetAllPeople()).Where(p => p.Id == closestDriver.PersonId).FirstOrDefault();
                if (personEntityForDriver == null)
                {
                    return NotFound();
                }
                var userEntityForDriver = _userManager.Users.Where(u => u.Id == personEntityForDriver.UserId).FirstOrDefault();
                if (userEntityForDriver == null)
                {
                    return NotFound();
                }

                // create the order
                var status = await _orderStatusService.GetOrderStatusByTypeId(1); // Pending
                var orderVM = new OrderViewModel()
                {
                    ClientId = client.ClientId,
                    DriverId = closestDriver.DriverId,
                    CurrentAddressId = currentAddress.AddressId,
                    DestinationId = destinationAddress.AddressId,
                    CountOfSeats = viewModel.CountOfSeats,
                    StatusId = status.StatusId
                };
                await _orderService.CreateOrder(orderVM);
                var order = await _orderService.GetLastCreatedOrder();

                // notify the user
                var callbackUrl = Url.Action("ProceedOrder", "Driver", values: new { driverId = closestDriver.DriverId, orderId = order.OdrerId},
                   protocol: Request.Scheme);
                await _emailSender.SendEmailAsync(userEntityForDriver.Email, "New order",
                    $"You were assigned a new order. Please log in to your account and accept or decline the order by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                return RedirectToAction("Index", "Home"); // TODO : add toastr to notify that the order was created
            }
            catch (ArgumentException exc) // TODO: if there are no free drivers
            {
                //var status = await _orderStatusService.GetOrderStatusByTypeId(4); // Waiting
                //await _orderService.CreateOrder(client.ClientId, currentAddress.AddressId, destinationAddress.AddressId, viewModel.CountOfSeats, status);
                return NotFound(exc.Message);
            }
            catch(Exception exc) // if driver cannot be found
            {
                return NotFound(exc.Message);
            }
        }

        
    }
}
