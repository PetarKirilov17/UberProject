using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uber.Core.Contracts;

namespace Uber.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IDriverService _driverService;

        public AdminController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ApproveDriver(int driverId)
        {
            await _driverService.ApproveDriver(driverId);
            return RedirectToAction("Index", "Driver"); // TODO: add toastr to notify the admin that driver was successfully approved
        }
    }
}
