using ApplicationLayer.IRepositories.Admin.Department;
using DomainLayer.V1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repos.V1.Admin.Department
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private string _connectionString;
        public DepartmentRepo(ApplicationDbContext context)
        {
            _connectionString = context.Database.GetConnectionString();
        }
        public int DeleteDepartmentById(int DepartmentId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("DeleteDepartmentById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DepartmentId", DepartmentId);

                    conn.Open();

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public IEnumerable<DepartmentMaster> GetAllDepartment()
        {
            List<DepartmentMaster> categories = new List<DepartmentMaster>();
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetAllDepartment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            categories.Add(new DepartmentMaster()
                            {
                                Id = sdr.IsDBNull(sdr.GetOrdinal("Id")) ? default : sdr.GetInt32(sdr.GetOrdinal("Id")),
                                BranchId = sdr.IsDBNull(sdr.GetOrdinal("BranchId")) ? default : sdr.GetInt32(sdr.GetOrdinal("BranchId")),
                                DepName = sdr.IsDBNull(sdr.GetOrdinal("DepName")) ? null : sdr.GetString(sdr.GetOrdinal("DepName")),
                                DepCode = sdr.IsDBNull(sdr.GetOrdinal("DepCode")) ? null : sdr.GetString(sdr.GetOrdinal("DepCode")),
                                DepPrefix = sdr.IsDBNull(sdr.GetOrdinal("DepPrefix")) ? null : sdr.GetString(sdr.GetOrdinal("DepPrefix")),
                                DepImg = sdr.IsDBNull(sdr.GetOrdinal("DepImg")) ? null : sdr.GetString(sdr.GetOrdinal("DepImg")),
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
            return categories;
        }

        public DepartmentMaster GetDepartmentById(int DepartmentId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetDepartmentById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DepartmentId", DepartmentId);
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            return new DepartmentMaster()
                            {
                                Id = sdr.IsDBNull(sdr.GetOrdinal("Id")) ? default : sdr.GetInt32(sdr.GetOrdinal("Id")),
                                BranchId = sdr.IsDBNull(sdr.GetOrdinal("BranchId")) ? default : sdr.GetInt32(sdr.GetOrdinal("BranchId")),
                                DepName = sdr.IsDBNull(sdr.GetOrdinal("DepName")) ? null : sdr.GetString(sdr.GetOrdinal("DepName")),
                                DepCode = sdr.IsDBNull(sdr.GetOrdinal("DepCode")) ? null : sdr.GetString(sdr.GetOrdinal("DepCode")),
                                DepPrefix = sdr.IsDBNull(sdr.GetOrdinal("DepPrefix")) ? null : sdr.GetString(sdr.GetOrdinal("DepPrefix")),
                                DepImg = sdr.IsDBNull(sdr.GetOrdinal("DepImg")) ? null : sdr.GetString(sdr.GetOrdinal("DepImg")),
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

        public int SaveDepartment(DepartmentMaster department)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("SaveDepartment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure
                    cmd.Parameters.AddWithValue("@BranchId", department.BranchId);
                    cmd.Parameters.AddWithValue("@DepName", (object)department.DepName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DepCode", (object)department.DepCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DepPrefix", (object)department.DepPrefix ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DepImg", (object)department.DepImg ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Created", (object)department.Created ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBy", (object)department.CreatedBy ?? DBNull.Value);

                    conn.Open();

                    // Execute the stored procedure and get the number of rows affected
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public int UpdateDepartment(DepartmentMaster department)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("UpdateDepartment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure
                    cmd.Parameters.AddWithValue("@Id", department.Id); // Identifier for the record to update
                    cmd.Parameters.AddWithValue("@BranchId", department.BranchId);
                    cmd.Parameters.AddWithValue("@DepName", (object)department.DepName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DepCode", (object)department.DepCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DepPrefix", (object)department.DepPrefix ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DepImg", (object)department.DepImg ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Updated", (object)department.Updated ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UpdatedBy", (object)department.UpdatedBy ?? DBNull.Value);

                    conn.Open();

                    // Execute the stored procedure and get the number of rows affected
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

    }
}
