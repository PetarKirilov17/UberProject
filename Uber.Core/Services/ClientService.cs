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
    public class ClientService : IClientService
    {

        private readonly IRepository repo;
        public ClientService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task CreateClient(int personId)
        {
            var entity = new Client()
            {
                PersonId = personId,
                isRegularCustomer = false
            };
            await this.repo.AddAsync(entity);
            await this.repo.SaveChangesAsync();
        }

        public async Task<List<Client>> GetAllClients()
        {
            return await this.repo.All<Client>().ToListAsync();
        }

        public async Task<Client> GetClientByClientId(int clientId)
        {
            return await this.repo.GetByIdAsync<Client>(clientId);
        }
    }
}
