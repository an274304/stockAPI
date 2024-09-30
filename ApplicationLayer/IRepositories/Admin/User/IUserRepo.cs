using DomainLayer.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IRepositories.Admin.User
{
    public interface IUserRepo
    {
        IEnumerable<UserMaster> GetAllUser();
        UserMaster GetUserById(int UserId);
        int DeleteUserById(int UserId);
        int UpdateUser(UserMaster User);
        int SaveUser(UserMaster User);
    }
}
