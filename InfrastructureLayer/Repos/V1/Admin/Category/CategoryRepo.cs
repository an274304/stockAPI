using ApplicationLayer.IRepositories.Admin.Category;
using DomainLayer.V1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repos.V1.Admin.Category
{
    public class CategoryRepo : ICategoryRepo
    {
        private string _connectionString;
        public CategoryRepo(ApplicationDbContext context)
        {
            _connectionString = context.Database.GetConnectionString();
        }
        public int DeleteCategoryById(int categoryId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("DeleteCategoryById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                    conn.Open();

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public IEnumerable<CategoryMaster> GetAllCategory()
        {
            List<CategoryMaster> categories = new List<CategoryMaster>();
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetAllCategory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            categories.Add(new CategoryMaster()
                            {

                                Id = sdr.IsDBNull(sdr.GetOrdinal("id")) ? default : sdr.GetInt32(sdr.GetOrdinal("id")),
                                CatVendorId = sdr.IsDBNull(sdr.GetOrdinal("CatVendorId")) ? default : sdr.GetInt32(sdr.GetOrdinal("CatVendorId")),
                                CatName = sdr.IsDBNull(sdr.GetOrdinal("CatName")) ? null : sdr.GetString(sdr.GetOrdinal("CatName")),
                                CatCode = sdr.IsDBNull(sdr.GetOrdinal("CatCode")) ? null : sdr.GetString(sdr.GetOrdinal("CatCode")),
                                CatPrefix = sdr.IsDBNull(sdr.GetOrdinal("CatPrefix")) ? null : sdr.GetString(sdr.GetOrdinal("CatPrefix")),
                                CatType = sdr.IsDBNull(sdr.GetOrdinal("CatType")) ? null : sdr.GetString(sdr.GetOrdinal("CatType")),
                                CatImg = sdr.IsDBNull(sdr.GetOrdinal("CatImg")) ? null : sdr.GetString(sdr.GetOrdinal("CatImg")),
                                Status = sdr.IsDBNull(sdr.GetOrdinal("Status")) ? default : sdr.GetBoolean(sdr.GetOrdinal("Status")),
                                Created = sdr.IsDBNull(sdr.GetOrdinal("Created")) ? default : sdr.GetDateTime(sdr.GetOrdinal("Created")),
                                CreatedBy = sdr.IsDBNull(sdr.GetOrdinal("CreatedBy")) ? null : sdr.GetString(sdr.GetOrdinal("CreatedBy")),
                                Updated = sdr.IsDBNull(sdr.GetOrdinal("Updated")) ? default : sdr.GetDateTime(sdr.GetOrdinal("Updated")),
                                UpdatedBy = sdr.IsDBNull(sdr.GetOrdinal("UpdatedBy")) ? null : sdr.GetString(sdr.GetOrdinal("UpdatedBy"))
                            });
                        }
                    }
                }
            }
            return categories;
        }

        public CategoryMaster GetCategoryById(int categoryId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetCategoryById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@categoryId", categoryId);
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            return new CategoryMaster()
                            {
                                Id = sdr.IsDBNull(sdr.GetOrdinal("id")) ? default : sdr.GetInt32(sdr.GetOrdinal("id")),
                                CatVendorId = sdr.IsDBNull(sdr.GetOrdinal("CatVendorId")) ? default : sdr.GetInt32(sdr.GetOrdinal("CatVendorId")),
                                CatName = sdr.IsDBNull(sdr.GetOrdinal("CatName")) ? null : sdr.GetString(sdr.GetOrdinal("CatName")),
                                CatCode = sdr.IsDBNull(sdr.GetOrdinal("CatCode")) ? null : sdr.GetString(sdr.GetOrdinal("CatCode")),
                                CatPrefix = sdr.IsDBNull(sdr.GetOrdinal("CatPrefix")) ? null : sdr.GetString(sdr.GetOrdinal("CatPrefix")),
                                CatType = sdr.IsDBNull(sdr.GetOrdinal("CatType")) ? null : sdr.GetString(sdr.GetOrdinal("CatType")),
                                CatImg = sdr.IsDBNull(sdr.GetOrdinal("CatImg")) ? null : sdr.GetString(sdr.GetOrdinal("CatImg")),
                                Status = sdr.IsDBNull(sdr.GetOrdinal("Status")) ? default : sdr.GetBoolean(sdr.GetOrdinal("Status")),
                                Created = sdr.IsDBNull(sdr.GetOrdinal("Created")) ? default : sdr.GetDateTime(sdr.GetOrdinal("Created")),
                                CreatedBy = sdr.IsDBNull(sdr.GetOrdinal("CreatedBy")) ? null : sdr.GetString(sdr.GetOrdinal("CreatedBy")),
                                Updated = sdr.IsDBNull(sdr.GetOrdinal("Updated")) ? default : sdr.GetDateTime(sdr.GetOrdinal("Updated")),
                                UpdatedBy = sdr.IsDBNull(sdr.GetOrdinal("UpdatedBy")) ? null : sdr.GetString(sdr.GetOrdinal("UpdatedBy"))
                            };
                        }
                    }
                }
            }
            return null;
        }

        public int SaveCategory(CategoryMaster category)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("SaveCategory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure
                    cmd.Parameters.AddWithValue("@CatVendorId", category.CatVendorId);
                    cmd.Parameters.AddWithValue("@CatName", (object)category.CatName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CatCode", (object)category.CatCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CatPrefix", (object)category.CatPrefix ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CatType", (object)category.CatType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CatImg", (object)category.CatImg ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Created", category.Created);
                    cmd.Parameters.AddWithValue("@CreatedBy", (object)category.CreatedBy ?? DBNull.Value);

                    conn.Open();

                    // Execute the stored procedure and get the number of rows inserted
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public int UpdateCategory(CategoryMaster category)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("UpdateCategory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure
                    cmd.Parameters.AddWithValue("@CategoryId", category.Id); // Identifier for the record to update
                    cmd.Parameters.AddWithValue("@CatVendorId", category.CatVendorId);
                    cmd.Parameters.AddWithValue("@CatName", (object)category.CatName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CatCode", (object)category.CatCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CatPrefix", (object)category.CatPrefix ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CatType", (object)category.CatType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CatImg", (object)category.CatImg ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Updated", category.Updated);
                    cmd.Parameters.AddWithValue("@UpdatedBy", (object)category.UpdatedBy ?? DBNull.Value);

                    conn.Open();

                    // Execute the stored procedure and get the number of rows affected
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
