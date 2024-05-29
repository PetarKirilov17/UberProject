using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uber.Infrastructure.Data.Models;

namespace Uber.Core.Contracts
{
    public interface IOrderStatusService
    {
        Task CreateOrderStatus(string label);

        Task<OrderStatus> GetOrderStatusByTypeId(int typeId);
    }
}
