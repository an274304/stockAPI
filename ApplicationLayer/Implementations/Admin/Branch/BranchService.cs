using ApplicationLayer.IRepositories.Admin.Branch;
using ApplicationLayer.IServices.Admin.Branch;
using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ApplicationLayer.Implementations.Admin.Branch
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepo _BranchRepo;
        private readonly IUrlService _urlService;
        private readonly string fileStoragePath;
        private readonly string branchImgPath;
        private readonly IConfiguration _configuration;

        public BranchService(IBranchRepo BranchRepo, IUrlService urlService, IHostEnvironment env, IConfiguration configuration)
        {
            _BranchRepo = BranchRepo;
            _urlService = urlService;
            _configuration = configuration;

            branchImgPath = _configuration["FileStoragePath:branchImgPath"];

            fileStoragePath = Path.Combine(env.ContentRootPath, "wwwroot", branchImgPath);

            if (!Directory.Exists(fileStoragePath))
            {
                Directory.CreateDirectory(fileStoragePath);
            }
        }
        public int DeleteBranchById(int BranchId)
        {
            return _BranchRepo.DeleteBranchById(BranchId);
        }

        public IEnumerable<BranchMaster> GetAllBranch()
        {
            return _BranchRepo.GetAllBranch();
        }

        public BranchMaster GetBranchById(int BranchId)
        {
            return _BranchRepo.GetBranchById(BranchId);
        }

        public int SaveBranch(BranchMaster Branch, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(fileStoragePath, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                Branch.BranchImg = Path.Combine(_urlService.GetBaseUrl(), branchImgPath, file.FileName);
            }
            return _BranchRepo.SaveBranch(Branch);
        }

        public int UpdateBranch(BranchMaster Branch, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(fileStoragePath, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                Branch.BranchImg = Path.Combine(_urlService.GetBaseUrl(), branchImgPath, file.FileName);
            }
            return _BranchRepo.UpdateBranch(Branch);
        }
    }
}
