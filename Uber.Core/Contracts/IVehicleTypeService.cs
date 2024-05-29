using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uber.Infrastructure.Data.Models;

namespace Uber.Core.Contracts
{
    public interface IVehicleTypeService
    {
        Task CreateVehicleType(string label);

        Task<List<VehicleType>> GetAllVehicleTypes();

        Task<VehicleType> GetVehicleTypeByTypeId(int typeId);
    }
}
