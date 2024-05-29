using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uber.Core.Models;
using Uber.Infrastructure.Data.Models;

namespace Uber.Core.Contracts
{
    public interface IDriverService
    {
        Task CreateDriver(int personId, DriverViewModel viewModel);

        Task<List<Driver>> GetAllDrivers();

        Task<Driver> GetDriverByDriverId(int driverId);

        Task ApproveDriver(int driverId);

        Task<List<Driver>> GetAllFreeDrivers();
    }
}
