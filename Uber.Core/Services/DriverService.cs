using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uber.Core.Contracts;
using Uber.Core.Models;
using Uber.Infrastructure.Data.Common;
using Uber.Infrastructure.Data.Models;

namespace Uber.Core.Services
{
    public class DriverService : IDriverService
    {
        private readonly IRepository _repo;
        private readonly IVehicleTypeService _vehicleTypeService;

        public DriverService(IRepository repository, IVehicleTypeService vehicleTypeService)
        {
            _repo = repository;
            _vehicleTypeService = vehicleTypeService;
        }

        public async Task ApproveDriver(int driverId)
        {
           var driver = await this.GetDriverByDriverId(driverId);
            if (driver != null) 
            {
                driver.IsDriverApproved = true;
               await _repo.SaveChangesAsync();
            }
        }

        public async Task CreateDriver(int personId, DriverViewModel viewModel)
        {

            List<VehicleType> vehicleTypes = new List<VehicleType>();
            foreach (var item in viewModel.VehicleTypeIds)
            {
                vehicleTypes.Add(await _vehicleTypeService.GetVehicleTypeByTypeId(item));
            }

            var entity = new Driver()
            {
                PersonId = personId,
                DrivingLicence = viewModel.DrivingLicence,
                Experience = viewModel.YearsOfExperience,
                IsDriverApproved = false,
                IsFree = true,
                CurrentPosition = new NpgsqlTypes.NpgsqlPoint(viewModel.Longitude, viewModel.Latitude),
                VehicleCategories = vehicleTypes
            };

            await _repo.AddAsync(entity);
            await _repo.SaveChangesAsync();
        }

        public async Task<List<Driver>> GetAllDrivers()
        {
            return await _repo.All<Driver>().Include(d => d.VehicleCategories).ToListAsync();
        }

        public async Task<List<Driver>> GetAllFreeDrivers()
        {
            return await _repo.All<Driver>().Where(d => d.IsFree && d.IsDriverApproved).ToListAsync();
        }

        public async Task<Driver> GetDriverByDriverId(int driverId)
        {
            return await _repo.GetByIdAsync<Driver>(driverId);
        }
    }
}
