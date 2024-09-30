using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices.Admin.User
{
    public interface IUserService
    {
        IEnumerable<UserMaster> GetAllUser();
        UserMaster GetUserById(int UserId);
        int DeleteUserById(int UserId);
        int UpdateUser(UserMaster User, IFormFile file);
        int SaveUser(UserMaster User, IFormFile file);
    }
}
