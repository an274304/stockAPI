using ApplicationLayer.IRepositories.Admin.Branch;
using DomainLayer.V1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repos.V1.Admin.Branch
{
    public class BranchRepo : IBranchRepo
    {
        private string _connectionString;
        public BranchRepo(ApplicationDbContext context)
        {
            _connectionString = context.Database.GetConnectionString();
        }
        public int DeleteBranchById(int BranchId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("DeleteBranchById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BranchId", BranchId);

                    conn.Open();

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public IEnumerable<BranchMaster> GetAllBranch()
        {
            List<BranchMaster> categories = new List<BranchMaster>();
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetAllBranch", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            categories.Add(new BranchMaster()
                            {
                                Id = sdr.IsDBNull(sdr.GetOrdinal("Id")) ? default : sdr.GetInt32(sdr.GetOrdinal("Id")),
                                BranchName = sdr.IsDBNull(sdr.GetOrdinal("BranchName")) ? null : sdr.GetString(sdr.GetOrdinal("BranchName")),
                                BranchCode = sdr.IsDBNull(sdr.GetOrdinal("BranchCode")) ? null : sdr.GetString(sdr.GetOrdinal("BranchCode")),
                                BranchPrefix = sdr.IsDBNull(sdr.GetOrdinal("BranchPrefix")) ? null : sdr.GetString(sdr.GetOrdinal("BranchPrefix")),
                                BranchImg = sdr.IsDBNull(sdr.GetOrdinal("BranchImg")) ? null : sdr.GetString(sdr.GetOrdinal("BranchImg")),
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

        public BranchMaster GetBranchById(int BranchId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetBranchById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BranchId", BranchId);
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            return new BranchMaster()
                            {
                                Id = sdr.IsDBNull(sdr.GetOrdinal("Id")) ? default : sdr.GetInt32(sdr.GetOrdinal("Id")),
                                BranchName = sdr.IsDBNull(sdr.GetOrdinal("BranchName")) ? null : sdr.GetString(sdr.GetOrdinal("BranchName")),
                                BranchCode = sdr.IsDBNull(sdr.GetOrdinal("BranchCode")) ? null : sdr.GetString(sdr.GetOrdinal("BranchCode")),
                                BranchPrefix = sdr.IsDBNull(sdr.GetOrdinal("BranchPrefix")) ? null : sdr.GetString(sdr.GetOrdinal("BranchPrefix")),
                                BranchImg = sdr.IsDBNull(sdr.GetOrdinal("BranchImg")) ? null : sdr.GetString(sdr.GetOrdinal("BranchImg")),
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

        public int SaveBranch(BranchMaster Branch)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("SaveBranch", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure
                    cmd.Parameters.AddWithValue("@BranchName", (object)Branch.BranchName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BranchCode", (object)Branch.BranchCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BranchPrefix", (object)Branch.BranchPrefix ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BranchImg", (object)Branch.BranchImg ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Created", Branch.Created.HasValue ? Branch.Created.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBy", (object)Branch.CreatedBy ?? DBNull.Value);

                    conn.Open();

                    // Execute the stored procedure and get the number of rows inserted
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public int UpdateBranch(BranchMaster Branch)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("UpdateBranch", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure
                    cmd.Parameters.AddWithValue("@BranchId", Branch.Id); // Identifier for the record to update
                    cmd.Parameters.AddWithValue("@BranchName", (object)Branch.BranchName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BranchCode", (object)Branch.BranchCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BranchPrefix", (object)Branch.BranchPrefix ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BranchImg", (object)Branch.BranchImg ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Updated", (object)Branch.Updated ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UpdatedBy", (object)Branch.UpdatedBy ?? DBNull.Value);

                    conn.Open();

                    // Execute the stored procedure and get the number of rows affected
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

    }
}
