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
    public class AddressService : IAddressService
    {
        private readonly IRepository _repo;

        public AddressService(IRepository repo)
        {
            _repo = repo;
        }
        public async Task CreateAddress(AddressViewModel viewModel)
        {
            //TODO : check if the address already exists
            var entity = new Address()
            {
                Location = new NpgsqlTypes.NpgsqlPoint(viewModel.Longitude, viewModel.Latitude),
                Description = viewModel.Description,
            };
            await _repo.AddAsync(entity);
            await _repo.SaveChangesAsync();
        }

        public async Task<Address> GetAddressById(int addressId)
        {
            return await _repo.GetByIdAsync<Address>(addressId);
        }

        public async Task<Address?> GetLastCreatedAddress()
        {
            return (await _repo.All<Address>().ToListAsync()).LastOrDefault();
        }
    }
}
