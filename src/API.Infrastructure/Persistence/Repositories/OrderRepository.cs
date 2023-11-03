using API.ApplicationCore.DTOs;
using API.ApplicationCore.Entities;
using API.ApplicationCore.Exceptions;
using API.Infrastructure.Persistence.Contexts;
using AutoMapper;
using API.ApplicationCore.Interfaces;
using API.ApplicationCore;

namespace API.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(APIContext context, IMapper mapper) 
        { 
            _mapper = mapper;
            _context = context;
        }

        public OrderResponse CreateOrder(Guid uid, CreateOrderRequest request, Guid[]? productIds)
        {
            var user = _context.Users.Find(uid)!;

            var order = _mapper.Map<Order>(request);
            order.User = user;
            order.CreatedAt = order.UpdatedAt = DateUtil.GetCurrentDate();

            if (productIds != null)
            {
                foreach (Guid productId in productIds)
                {
                    Product product = _context.Products.Find(productId)!;
                    OrderProduct orderProduct = new() { Oid = order.Oid, Pid = product.Pid, Order = order, Product = product };

                    this._context.OrderProducts.Add(orderProduct);
                }
            }

            this._context.Orders.Add(order);
            this._context.SaveChanges();

            return this._mapper.Map<OrderResponse>(order);
        }

        public void DeleteOrderById(Guid oid)
        {
            var order = _context.Orders.Find(oid);
            if (order != null)
            {
                this._context.Orders.Remove(order);
                this._context.SaveChanges();
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public List<OrderResponse> GetOrders()
        {
            return this._context.Orders.Select(o => this._mapper.Map<OrderResponse>(o)).ToList();
        }

        public OrderResponse GetOrderById(Guid oid)
        {
            var order = this._context.Orders.Find(oid);
            if (order != null)
            {
                return this._mapper.Map<OrderResponse>(order);
            }
            throw new NotFoundException();
        }

        public OrderResponse UpdateOrder(Guid oid, UpdateOrderRequest request, Guid[] productIds)
        {
            var order = this._context.Orders.Find(oid);

            if (order != null)
                order.UpdatedAt = DateUtil.GetCurrentDate();
            { 
                if (productIds != null)
                {
                    foreach (Guid propertyId in productIds)
                    {
                        Product product = _context.Products.Find(propertyId)!;
                        OrderProduct orderProduct = new() { Oid = order.Oid, Pid = product.Pid, Order = order, Product = product };

                        if (this._context.OrderProducts.Any(op => op.Oid == orderProduct.Oid && op.Pid == orderProduct.Pid))
                        {
                            this._context.Update(orderProduct);
                        }
                        else
                        {
                            this._context.Add(orderProduct);
                        }
                    }
                }

                this._context.Orders.Update(order);
                this._context.SaveChanges();

                return this._mapper.Map<OrderResponse>(order);
            }

            throw new NotFoundException();
        }

    }
}
