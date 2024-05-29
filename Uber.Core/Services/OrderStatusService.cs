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
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IRepository _repo;

        public OrderStatusService(IRepository repository)
        {
            _repo = repository;
        }

        public async Task CreateOrderStatus(string label)
        {
            var entity = new OrderStatus()
            {
                Label = label
            };

            await _repo.AddAsync(entity);
            await _repo.SaveChangesAsync();
        }

        public async Task<OrderStatus> GetOrderStatusByTypeId(int typeId)
        {
            return await _repo.GetByIdAsync<OrderStatus>(typeId);
        }
    }
}
