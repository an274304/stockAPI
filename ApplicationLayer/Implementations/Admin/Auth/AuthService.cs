using ApplicationLayer.IRepositories.Admin.Auth;
using ApplicationLayer.IServices.Admin.Auth;
using DomainLayer.AuthDTOs;
using DomainLayer.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Implementations.Admin.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepo _authRepo;

        public AuthService(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }

        public List<UserTypeMaster> GetAllUserType()
        {
            return _authRepo.GetAllUserType();
        }

        public UserMaster Login(LogInDTO logIn)
        {
            return _authRepo.Login(logIn);
        }
    }
}
