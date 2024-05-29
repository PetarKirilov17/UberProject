using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uber.Core.Models;
using Uber.Infrastructure.Data.Models;

namespace Uber.Core.Contracts
{
    public interface IAddressService
    {
        Task CreateAddress(AddressViewModel viewModel);

        Task<Address?> GetLastCreatedAddress();

        Task<Address> GetAddressById(int addressId);
    }
}
