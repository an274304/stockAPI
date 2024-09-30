using ApplicationLayer.IRepositories.Admin.User;
using ApplicationLayer.IServices.Admin.User;
using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ApplicationLayer.Implementations.Admin.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IUrlService _urlService;
        private readonly string fileStoragePath;
        private readonly string userImgPath;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepo userRepo, IUrlService urlService, IHostEnvironment env, IConfiguration configuration)
        {
            _userRepo = userRepo;
            _urlService = urlService;
            _configuration = configuration;

            userImgPath = _configuration["FileStoragePath:userImgPath"];

            fileStoragePath = Path.Combine(env.ContentRootPath, "wwwroot", userImgPath);

            if (!Directory.Exists(fileStoragePath))
            {
                Directory.CreateDirectory(fileStoragePath);
            }

        }

        public int DeleteUserById(int UserId)
        {
            return _userRepo.DeleteUserById(UserId);
        }

        public IEnumerable<UserMaster> GetAllUser()
        {
            return _userRepo.GetAllUser();
        }

        public UserMaster GetUserById(int UserId)
        {
            return _userRepo.GetUserById(UserId);
        }

        public int SaveUser(UserMaster User, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(fileStoragePath, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                User.UsImg = Path.Combine(_urlService.GetBaseUrl(), userImgPath, file.FileName);
            }
            return _userRepo.SaveUser(User);
        }

        public int UpdateUser(UserMaster User, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(fileStoragePath, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                User.UsImg = Path.Combine(_urlService.GetBaseUrl(), userImgPath, file.FileName);
            }
            return _userRepo.UpdateUser(User);
        }
    }
}
