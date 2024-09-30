using ApplicationLayer.IRepositories.Admin.Category;
using ApplicationLayer.IServices.Admin.Category;
using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ApplicationLayer.Implementations.Admin.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IUrlService _urlService;
        private readonly string fileStoragePath;
        private readonly string categoryImgPath;
        private readonly IConfiguration _configuration;

        public CategoryService(ICategoryRepo categoryRepo, IUrlService urlService, IHostEnvironment env, IConfiguration configuration)
        {
            _categoryRepo = categoryRepo;
            _urlService = urlService;
            _configuration = configuration;

            categoryImgPath = _configuration["FileStoragePath:categoryImgPath"];

            fileStoragePath = Path.Combine(env.ContentRootPath, "wwwroot", categoryImgPath);

            if (!Directory.Exists(fileStoragePath))
            {
                Directory.CreateDirectory(fileStoragePath);
            }

        }

        public int DeleteCategoryById(int categoryId)
        {
            return _categoryRepo.DeleteCategoryById(categoryId);
        }

        public IEnumerable<CategoryMaster> GetAllCategory()
        {
            return _categoryRepo.GetAllCategory();
        }

        public CategoryMaster GetCategoryById(int categoryId)
        {
            return _categoryRepo.GetCategoryById(categoryId);
        }

        public int SaveCategory(CategoryMaster category, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(fileStoragePath, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                category.CatImg = Path.Combine(_urlService.GetBaseUrl(), categoryImgPath, file.FileName);
            }

            return _categoryRepo.SaveCategory(category);
        }

        public int UpdateCategory(CategoryMaster category, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(fileStoragePath, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                category.CatImg = Path.Combine(_urlService.GetBaseUrl(), categoryImgPath, file.FileName);
            }

            return _categoryRepo.UpdateCategory(category);
        }

    }
}
