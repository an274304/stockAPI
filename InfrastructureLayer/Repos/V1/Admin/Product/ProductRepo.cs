using ApplicationLayer.IRepositories.Admin.Product;
using DomainLayer.V1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repos.V1.Admin.Product
{
    public class ProductRepo : IProductRepo
    {
        private string _connectionString;
        public ProductRepo(ApplicationDbContext context)
        {
            _connectionString = context.Database.GetConnectionString();
        }
        public int DeleteProductById(int ProductId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("DeleteProductById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", ProductId);

                    conn.Open();

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public IEnumerable<ProductMaster> GetAllProduct()
        {
            List<ProductMaster> products = new List<ProductMaster>();
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetAllProduct", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            products.Add(new ProductMaster()
                            {
                                Id = sdr.IsDBNull(sdr.GetOrdinal("Id")) ? default : sdr.GetInt32(sdr.GetOrdinal("Id")),
                                CatId = sdr.IsDBNull(sdr.GetOrdinal("CatId")) ? default : sdr.GetInt32(sdr.GetOrdinal("CatId")),
                                ProName = sdr.IsDBNull(sdr.GetOrdinal("ProName")) ? null : sdr.GetString(sdr.GetOrdinal("ProName")),
                                ProCode = sdr.IsDBNull(sdr.GetOrdinal("ProCode")) ? null : sdr.GetString(sdr.GetOrdinal("ProCode")),
                                ProPrefix = sdr.IsDBNull(sdr.GetOrdinal("ProPrefix")) ? null : sdr.GetString(sdr.GetOrdinal("ProPrefix")),
                                ProType = sdr.IsDBNull(sdr.GetOrdinal("ProType")) ? null : sdr.GetString(sdr.GetOrdinal("ProType")),
                                ProImg = sdr.IsDBNull(sdr.GetOrdinal("ProImg")) ? null : sdr.GetString(sdr.GetOrdinal("ProImg")),
                                ProBuyDt = sdr.IsDBNull(sdr.GetOrdinal("ProBuyDt")) ? null : sdr.GetDateTime(sdr.GetOrdinal("ProBuyDt")),
                                ProExpDt = sdr.IsDBNull(sdr.GetOrdinal("ProExpDt")) ? null : sdr.GetDateTime(sdr.GetOrdinal("ProExpDt")),
                                Status = sdr.IsDBNull(sdr.GetOrdinal("Status")) ? null : sdr.GetBoolean(sdr.GetOrdinal("Status")),
                                Created = sdr.IsDBNull(sdr.GetOrdinal("Created")) ? null : sdr.GetDateTime(sdr.GetOrdinal("Created")),
                                CreatedBy = sdr.IsDBNull(sdr.GetOrdinal("CreatedBy")) ? null : sdr.GetString(sdr.GetOrdinal("CreatedBy")),
                                Updated = sdr.IsDBNull(sdr.GetOrdinal("Updated")) ? null : sdr.GetDateTime(sdr.GetOrdinal("Updated")),
                                UpdatedBy = sdr.IsDBNull(sdr.GetOrdinal("UpdatedBy")) ? null : sdr.GetString(sdr.GetOrdinal("UpdatedBy"))
                            });
                        }
                    }
                }
            }
            return products;
        }

        public ProductMaster GetProductById(int ProductId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetProductById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", ProductId);
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            return new ProductMaster()
                            {
                                Id = sdr.IsDBNull(sdr.GetOrdinal("Id")) ? default : sdr.GetInt32(sdr.GetOrdinal("Id")),
                                CatId = sdr.IsDBNull(sdr.GetOrdinal("CatId")) ? default : sdr.GetInt32(sdr.GetOrdinal("CatId")),
                                ProName = sdr.IsDBNull(sdr.GetOrdinal("ProName")) ? null : sdr.GetString(sdr.GetOrdinal("ProName")),
                                ProCode = sdr.IsDBNull(sdr.GetOrdinal("ProCode")) ? null : sdr.GetString(sdr.GetOrdinal("ProCode")),
                                ProPrefix = sdr.IsDBNull(sdr.GetOrdinal("ProPrefix")) ? null : sdr.GetString(sdr.GetOrdinal("ProPrefix")),
                                ProType = sdr.IsDBNull(sdr.GetOrdinal("ProType")) ? null : sdr.GetString(sdr.GetOrdinal("ProType")),
                                ProImg = sdr.IsDBNull(sdr.GetOrdinal("ProImg")) ? null : sdr.GetString(sdr.GetOrdinal("ProImg")),
                                ProBuyDt = sdr.IsDBNull(sdr.GetOrdinal("ProBuyDt")) ? null : sdr.GetDateTime(sdr.GetOrdinal("ProBuyDt")),
                                ProExpDt = sdr.IsDBNull(sdr.GetOrdinal("ProExpDt")) ? null : sdr.GetDateTime(sdr.GetOrdinal("ProExpDt")),
                                Status = sdr.IsDBNull(sdr.GetOrdinal("Status")) ? null : sdr.GetBoolean(sdr.GetOrdinal("Status")),
                                Created = sdr.IsDBNull(sdr.GetOrdinal("Created")) ? null : sdr.GetDateTime(sdr.GetOrdinal("Created")),
                                CreatedBy = sdr.IsDBNull(sdr.GetOrdinal("CreatedBy")) ? null : sdr.GetString(sdr.GetOrdinal("CreatedBy")),
                                Updated = sdr.IsDBNull(sdr.GetOrdinal("Updated")) ? null : sdr.GetDateTime(sdr.GetOrdinal("Updated")),
                                UpdatedBy = sdr.IsDBNull(sdr.GetOrdinal("UpdatedBy")) ? null : sdr.GetString(sdr.GetOrdinal("UpdatedBy"))
                            };
                        }
                    }
                }
            }
            return null;
        }

        public int SaveProduct(ProductMaster Product)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("SaveProduct", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure
                    cmd.Parameters.AddWithValue("@CatId", Product.CatId);
                    cmd.Parameters.AddWithValue("@ProName", (object)Product.ProName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProCode", (object)Product.ProCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProPrefix", (object)Product.ProPrefix ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProImg", (object)Product.ProImg ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Created", (object)Product.Created ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBy", (object)Product.CreatedBy ?? DBNull.Value);

                    conn.Open();

                    // Execute the stored procedure and get the number of rows affected
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public int UpdateProduct(ProductMaster Product)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("UpdateProduct", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure
                    cmd.Parameters.AddWithValue("@ProId", Product.Id); // Identifier for the record to update
                    cmd.Parameters.AddWithValue("@CatId", Product.CatId);
                    cmd.Parameters.AddWithValue("@ProName", (object)Product.ProName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProCode", (object)Product.ProCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProPrefix", (object)Product.ProPrefix ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProImg", (object)Product.ProImg ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Updated", (object)Product.Updated ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UpdatedBy", (object)Product.UpdatedBy ?? DBNull.Value);

                    conn.Open();

                    // Execute the stored procedure and get the number of rows affected
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
