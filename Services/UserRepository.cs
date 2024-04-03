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
using DataAccess.Blog.DataRequests;

namespace DataAccess.Blog.Services
{
    public class UserRepository : IUserRepository
    {
        private BlogDbContext _context;

        public UserRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<User> Login(UserLoginRequestData requestData)
        {
            var user = new User();
            try
            {
                user = _context.Users.ToList().FirstOrDefault(user =>
                    user.username == requestData.username && user.password == requestData.password);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }
        
        public async Task<int> UpdateRefeshToken(UserUpdateRefeshTokenRequestData requestData)
        {
            try
            {
                var user = _context.Users.ToList().FirstOrDefault(user => user.id == requestData.id);
                if (user != null)
                {
                    user.refresh_token = requestData.refresh_token;
                    user.refresh_token_expired_date = requestData.refresh_token_expired_date;
                    _context.Users.Update(user);
                    _context.SaveChanges();

                    return 1;
                }

                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

		public async Task<Function> GetFunctionByCode(string functionCode)
        {
            return _context.Function.FirstOrDefault(f => f.FunctionCode == functionCode);
        }
		public async Task<UserFunction> UserFunction_GetRole(int userId, int functionId)
        {
            return _context.UserFunction.FirstOrDefault(uf => uf.UserId == userId && uf.FunctionId == functionId);
        }
	}
}