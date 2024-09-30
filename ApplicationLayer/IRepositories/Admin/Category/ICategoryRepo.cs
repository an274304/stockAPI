using DomainLayer.V1.Models;

namespace ApplicationLayer.IRepositories.Admin.Category
{
    public interface ICategoryRepo
    {
        IEnumerable<CategoryMaster> GetAllCategory();
        CategoryMaster GetCategoryById(int categoryId);
        int DeleteCategoryById(int categoryId);
        int UpdateCategory(CategoryMaster category);
        int SaveCategory(CategoryMaster category);
    }
}
