using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uber.Core.Contracts;
using Uber.Infrastructure.Data.Common;
using Uber.Infrastructure.Data.Models;

namespace Uber.Core.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {

        private readonly IRepository repo;
        public VehicleTypeService(IRepository repo)
        {
            this.repo = repo;
        }
        public async Task CreateVehicleType(string label)
        {
            var entity = new VehicleType()
            { 
                Label = label 
            };

            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();
        }

        public async Task<List<VehicleType>> GetAllVehicleTypes()
        {
            return await repo.All<VehicleType>().ToListAsync();
        }

        public async Task<VehicleType> GetVehicleTypeByTypeId(int typeId)
        {
            return await this.repo.GetByIdAsync<VehicleType>(typeId);
        }
    }
}
