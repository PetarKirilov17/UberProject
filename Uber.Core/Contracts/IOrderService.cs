using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uber.Core.Models;
using Uber.Infrastructure.Data.Models;

namespace Uber.Core.Contracts
{
    public interface IOrderService
    {
        Task CreateOrder(OrderViewModel viewModel);

        Task<Order?> GetLastCreatedOrder();

        Task<Order?> GetOrderById(int orderId);
    }
}
