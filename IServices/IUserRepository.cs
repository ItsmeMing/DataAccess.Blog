using DataAccess.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Blog.DataRequests;

namespace DataAccess.Blog.IServices
{
    public interface IUserRepository
    {
        Task<User> Login(UserLoginRequestData requestData);
        Task<int> UpdateRefeshToken(UserUpdateRefeshTokenRequestData requestData);
    }
}