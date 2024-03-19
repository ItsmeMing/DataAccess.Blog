using DataAccess.Blog.Entities;
using DataAccess.Blog.EntityFramework;
using DataAccess.Blog.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Blog.Services
{
    public class OrderRepository : IOrderRepository
    {
        private BlogDbContext _context;

        public OrderRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrders(string? order_id)
        {
            var list = new List<Order>();
            try
            {
                if (order_id == null)
                {
                    list = _context.Orders.ToList();
                }
                else
                {
                    list = _context.Orders.ToList().FindAll(order => order.id == int.Parse(order_id));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public async Task<ReturnData> CreateOrder(CreateOrder order)
        {
            var returnData = new ReturnData();
            try
            {
                if (order == null)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;
                }

                if (order.CustomerId <= 0)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "Customer không hợp lệ";
                    return returnData;
                }
                else
                {
                    var orderEntity = new Order();

                    orderEntity.customer_id = order.CustomerId;

                    _context.Orders.Add((orderEntity));
                    foreach (var orderDetail in order.orderDetails.ToArray())
                    {
                        _context.OrderDetails.Add(orderDetail);
                    }
                }

                return returnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}