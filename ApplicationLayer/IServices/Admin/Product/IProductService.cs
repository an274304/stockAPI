using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices.Admin.Product
{
    public interface IProductService
    {
        IEnumerable<ProductMaster> GetAllProduct();
        ProductMaster GetProductById(int ProductId);
        int DeleteProductById(int ProductId);
        int UpdateProduct(ProductMaster Product, IFormFile file);
        int SaveProduct(ProductMaster Product, IFormFile file);
    }
}
