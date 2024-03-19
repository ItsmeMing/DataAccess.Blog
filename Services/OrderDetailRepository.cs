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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private BlogDbContext _context;

        public OrderDetailRepository(BlogDbContext context)
        {
            _context = context;
        }
        
        public async Task<ReturnData> CreateOrderDetail(CreateOrderDetail orderDetail)
        {
            var returnData = new ReturnData();
            try
            {
                if (orderDetail == null)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "Dữ liệu đầu vào không hợp lệ";
                    return returnData;
                }

                if (orderDetail.order_id <= 0 || orderDetail.product_id <= 0 || orderDetail.quantity <= 0)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "Order/Product/Quantity không hợp lệ";
                    return returnData;
                }
                else
                {
                    var orderDetailEntity = new OrderDetail();

                    orderDetailEntity.order_id = orderDetail.order_id;
                    orderDetailEntity.product_id = orderDetail.product_id;
                    orderDetailEntity.quantity = orderDetail.quantity;

                    _context.OrderDetails.Add(orderDetailEntity);
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