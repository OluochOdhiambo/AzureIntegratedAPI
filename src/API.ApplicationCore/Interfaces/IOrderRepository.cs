using API.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ApplicationCore.Interfaces
{
    public interface IOrderRepository
    {
        List<OrderResponse> GetOrders();

        OrderResponse GetOrderById(Guid oid);

        void DeleteOrderById(Guid oid);

        OrderResponse UpdateOrder(Guid oid, UpdateOrderRequest request, Guid[] productIds);

        OrderResponse CreateOrder(Guid uid, CreateOrderRequest request, Guid[] productIds);
    }
}
