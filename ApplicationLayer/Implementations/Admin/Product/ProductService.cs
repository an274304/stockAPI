using ApplicationLayer.IRepositories.Admin.Product;
using ApplicationLayer.IServices.Admin.Product;
using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Implementations.Admin.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _ProductRepo;
        private readonly IUrlService _urlService;
        private readonly string fileStoragePath;
        private readonly string ProductImgPath;
        private readonly IConfiguration _configuration;

        public ProductService(IProductRepo ProductRepo, IUrlService urlService, IHostEnvironment env, IConfiguration configuration)
        {
            _ProductRepo = ProductRepo;
            _urlService = urlService;
            _configuration = configuration;

            ProductImgPath = _configuration["FileStoragePath:ProductImgPath"];

            fileStoragePath = Path.Combine(env.ContentRootPath, "wwwroot", ProductImgPath);

            if (!Directory.Exists(fileStoragePath))
            {
                Directory.CreateDirectory(fileStoragePath);
            }
        }
        public int DeleteProductById(int ProductId)
        {
            return _ProductRepo.DeleteProductById(ProductId);
        }

        public IEnumerable<ProductMaster> GetAllProduct()
        {
            return _ProductRepo.GetAllProduct();
        }

        public ProductMaster GetProductById(int ProductId)
        {
            return _ProductRepo.GetProductById(ProductId);
        }

        public int SaveProduct(ProductMaster Product, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(fileStoragePath, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                Product.ProImg = Path.Combine(_urlService.GetBaseUrl(), ProductImgPath, file.FileName);
            }
            return _ProductRepo.SaveProduct(Product);
        }

        public int UpdateProduct(ProductMaster Product, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(fileStoragePath, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                Product.ProImg = Path.Combine(_urlService.GetBaseUrl(), ProductImgPath, file.FileName);
            }
            return _ProductRepo.UpdateProduct(Product);
        }
    }
}
