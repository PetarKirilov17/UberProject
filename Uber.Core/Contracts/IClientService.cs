using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uber.Infrastructure.Data.Models;

namespace Uber.Core.Contracts
{
    public interface IClientService
    {
        Task CreateClient(int personId);

        Task<Client> GetClientByClientId(int clientId);

        Task<List<Client>> GetAllClients();
    }
}
