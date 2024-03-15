using DataAccess.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Blog.IServices
{
    public interface IOrderDetailRepository
    {
        Task<ReturnData> CreateOrderDetail(CreateOrderDetail orderDetail);
    }
}