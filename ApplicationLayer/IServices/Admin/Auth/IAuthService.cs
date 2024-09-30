using DomainLayer.AuthDTOs;
using DomainLayer.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices.Admin.Auth
{
    public interface IAuthService
    {
        UserMaster Login(LogInDTO logIn);
        List<UserTypeMaster> GetAllUserType();
    }
}
