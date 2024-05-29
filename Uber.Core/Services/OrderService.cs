using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Uber.Core.Contracts;
using Uber.Core.Models;
using Uber.Infrastructure.Data.Common;
using Uber.Infrastructure.Data.Models;

namespace Uber.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository _repo;

        public OrderService(IRepository repository)
        {
            _repo = repository;
        }
        public async Task CreateOrder(OrderViewModel viewModel)
        {
            var entity = new Order()
            {
                ClientId = viewModel.ClientId,
                DriverId = viewModel.DriverId,
                CurrentAddressId = viewModel.CurrentAddressId,
                DestinationId = viewModel.DestinationId,
                CountOfPassengers = (short)viewModel.CountOfSeats,
                OrderStatusId = viewModel.StatusId,
                VehicleId = 1 // TODO : change, only try for testing the creation of order
            };
            await _repo.AddAsync(entity);
            await _repo.SaveChangesAsync();
        }

        public async Task<Order?> GetLastCreatedOrder()
        {
            return (await _repo.All<Order>().ToListAsync()).LastOrDefault();
        }

        public async Task<Order?> GetOrderById(int orderId)
        {
            return await _repo.GetByIdAsync<Order>(orderId);
        }
    }
}
