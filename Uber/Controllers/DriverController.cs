using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uber.Core.Contracts;
using Uber.Core.Services;
using Uber.Models.Driver;

namespace Uber.Controllers
{
    [Authorize(Roles = "Admin, Driver, Client")]
    public class DriverController : Controller
    {
        private readonly IDriverService _driverService;
        private readonly IOrderService _orderService;
        private readonly IPersonService _personService;
        private readonly IClientService _clientService;
        private readonly IAddressService _addressService;

        public DriverController(IDriverService driverService, IOrderService orderService,
            IPersonService personService, IClientService clientService, IAddressService addressService)
        {
            _driverService = driverService;
            _orderService = orderService;
            _personService = personService;
            _clientService = clientService;
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var drivers = await _driverService.GetAllDrivers();
            var vehicleLabels = new List<string>();
            
            var viewModel = new List<DriverIndexViewModel>();
            foreach (var driver in drivers)
            {
                vehicleLabels = driver.VehicleCategories.Select(x => x.Label).ToList();
                viewModel.Add(new DriverIndexViewModel()
                {
                    DriverId = driver.DriverId,
                    DrivingLicence = driver.DrivingLicence,
                    YearsOfExperience = driver.Experience,
                    VehicleCategoriesLabels = vehicleLabels,
                    Latitude = driver.CurrentPosition.Value.X,
                    Longitude = driver.CurrentPosition.Value.Y,
                    IsApproved = driver.IsDriverApproved
                });
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ProceedOrder(int driverId, int orderId)
        {
            if (driverId <= 0 || orderId <= 0)
            {
                return NotFound();
            }
            var driver = await _driverService.GetDriverByDriverId(driverId);
            var order = await _orderService.GetOrderById(orderId);
            if (driver == null)
            {
                return NotFound("Driver not found!");
            }
            if (order == null)
            {
                return NotFound("Order not found!");
            }
            var client = await _clientService.GetClientByClientId(order.ClientId);
            var person = await _personService.GetPersonByPersonId(client.PersonId);
            var currAddress = await _addressService.GetAddressById(order.CurrentAddressId);
            var destinationAddress = await _addressService.GetAddressById(order.DestinationId);
            ProceedOrderViewModel viewModel = new ProceedOrderViewModel()
            {
                OrderId = orderId,
                ClientName = person.FirstName + " " + person.LastName,
                CurrentAddressLabel = currAddress.Description,
                CurrentAddressLatitude = currAddress.Location.Value.Y,
                CurrentAddressLongitude = currAddress.Location.Value.X,
                DestinationAddressLabel = destinationAddress.Description,
                DestinationAddressLatitude = destinationAddress.Location.Value.Y,
                DestinationAddressLongitude = destinationAddress.Location.Value.X,
                CountOfSeats = order.CountOfPassengers
            };
            return View(viewModel);
        }
    }
}
