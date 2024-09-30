using DomainLayer.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IRepositories.Admin.Product
{
    public interface IProductRepo
    {
        IEnumerable<ProductMaster> GetAllProduct();
        ProductMaster GetProductById(int ProductId);
        int DeleteProductById(int ProductId);
        int UpdateProduct(ProductMaster Product);
        int SaveProduct(ProductMaster Product);
    }
}
