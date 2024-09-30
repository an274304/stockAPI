using Microsoft.AspNetCore.Http;
using DomainLayer.V1.Models;

namespace ApplicationLayer.IServices.Admin.Category
{
    public interface ICategoryService
    {
        IEnumerable<CategoryMaster> GetAllCategory();
        CategoryMaster GetCategoryById(int categoryId);
        int DeleteCategoryById(int categoryId);
        int UpdateCategory(CategoryMaster category, IFormFile file);
        int SaveCategory(CategoryMaster category, IFormFile file);
    }
}
