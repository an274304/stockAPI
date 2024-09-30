using ApplicationLayer.IRepositories.Admin.Department;
using ApplicationLayer.IServices.Admin.Department;
using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Implementations.Admin.Department
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepo _DepartmentRepo;
        private readonly IUrlService _urlService;
        private readonly string fileStoragePath;
        private readonly string departmentImgPath;
        private readonly IConfiguration _configuration;

        public DepartmentService(IDepartmentRepo DepartmentRepo, IUrlService urlService, IHostEnvironment env, IConfiguration configuration)
        {
            _DepartmentRepo = DepartmentRepo;
            _urlService = urlService;
            _configuration = configuration;

            departmentImgPath = _configuration["FileStoragePath:departmentImgPath"];

            fileStoragePath = Path.Combine(env.ContentRootPath, "wwwroot", departmentImgPath);

            if (!Directory.Exists(fileStoragePath))
            {
                Directory.CreateDirectory(fileStoragePath);
            }
        }
        public int DeleteDepartmentById(int DepartmentId)
        {
            return _DepartmentRepo.DeleteDepartmentById(DepartmentId);
        }

        public IEnumerable<DepartmentMaster> GetAllDepartment()
        {
            return _DepartmentRepo.GetAllDepartment();
        }

        public DepartmentMaster GetDepartmentById(int DepartmentId)
        {
            return _DepartmentRepo.GetDepartmentById(DepartmentId);
        }

        public int SaveDepartment(DepartmentMaster Department, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(fileStoragePath, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                Department.DepImg = Path.Combine(_urlService.GetBaseUrl(), departmentImgPath, file.FileName);
            }
            return _DepartmentRepo.SaveDepartment(Department);
        }

        public int UpdateDepartment(DepartmentMaster Department, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(fileStoragePath, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                Department.DepImg = Path.Combine(_urlService.GetBaseUrl(), departmentImgPath, file.FileName);
            }
            return _DepartmentRepo.UpdateDepartment(Department);
        }
    }
}
