using ApplicationLayer.IRepositories.Admin.Vendor;
using ApplicationLayer.IServices.Admin.Vendor;
using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ApplicationLayer.Implementations.Admin.Vendor
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepo _vendorRepo;
        private readonly IUrlService _urlService;
        private readonly string fileStoragePath;
        private readonly string vendorImgPath;
        private readonly IConfiguration _configuration;

        public VendorService(IVendorRepo vendorRepo, IUrlService urlService, IHostEnvironment env, IConfiguration configuration)
        {
            _vendorRepo = vendorRepo;
            _urlService = urlService;
            _configuration = configuration;

            vendorImgPath = _configuration["FileStoragePath:vendorImgPath"];

            fileStoragePath = Path.Combine(env.ContentRootPath, "wwwroot", vendorImgPath);

            if (!Directory.Exists(fileStoragePath))
            {
                Directory.CreateDirectory(fileStoragePath);
            }
        }

        public int DeleteVendorById(int VendorId)
        {
            return _vendorRepo.DeleteVendorById(VendorId);
        }

        public IEnumerable<VendorMaster> GetAllVendor()
        {
            return _vendorRepo.GetAllVendor();
        }

        public VendorMaster GetVendorById(int VendorId)
        {
            return _vendorRepo.GetVendorById(VendorId);
        }

        public int SaveVendor(VendorMaster Vendor, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(fileStoragePath, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                Vendor.VenImg = Path.Combine(_urlService.GetBaseUrl(), vendorImgPath, file.FileName);
            }
            return _vendorRepo.SaveVendor(Vendor);
        }

        public int UpdateVendor(VendorMaster Vendor, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(fileStoragePath, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                Vendor.VenImg = Path.Combine(_urlService.GetBaseUrl(), vendorImgPath, file.FileName);
            }
            return _vendorRepo.UpdateVendor(Vendor);
        }
    }
}
