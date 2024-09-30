using ApplicationLayer.IRepositories.Admin.User;
using DomainLayer.V1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repos.V1.Admin.User
{
    public class UserRepo : IUserRepo
    {
        private string _connectionString;
        public UserRepo(ApplicationDbContext context)
        {
            _connectionString = context.Database.GetConnectionString();
        }
        public int DeleteUserById(int UserId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("DeleteUserById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);

                    conn.Open();

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public IEnumerable<UserMaster> GetAllUser()
        {
            List<UserMaster> Users = new List<UserMaster>();
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetAllUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Users.Add(new UserMaster()
                            {

                                Id = sdr.IsDBNull(sdr.GetOrdinal("Id")) ? default : sdr.GetInt32(sdr.GetOrdinal("Id")),
                                UsTypeId = sdr.IsDBNull(sdr.GetOrdinal("UsTypeId")) ? default : sdr.GetInt32(sdr.GetOrdinal("UsTypeId")),
                                UsBranchId = sdr.IsDBNull(sdr.GetOrdinal("UsBranchId")) ? default : sdr.GetInt32(sdr.GetOrdinal("UsBranchId")),
                                UsDepartmentId = sdr.IsDBNull(sdr.GetOrdinal("UsDepartmentId")) ? default : sdr.GetInt32(sdr.GetOrdinal("UsDepartmentId")),
                                UsName = sdr.IsDBNull(sdr.GetOrdinal("UsName")) ? null : sdr.GetString(sdr.GetOrdinal("UsName")),
                                UsCode = sdr.IsDBNull(sdr.GetOrdinal("UsCode")) ? null : sdr.GetString(sdr.GetOrdinal("UsCode")),
                                UsPrefix = sdr.IsDBNull(sdr.GetOrdinal("UsPrefix")) ? null : sdr.GetString(sdr.GetOrdinal("UsPrefix")),
                                UsTypeName = sdr.IsDBNull(sdr.GetOrdinal("UsTypeName")) ? null : sdr.GetString(sdr.GetOrdinal("UsTypeName")),
                                UsImg = sdr.IsDBNull(sdr.GetOrdinal("UsImg")) ? null : sdr.GetString(sdr.GetOrdinal("UsImg")),
                                UsAddress = sdr.IsDBNull(sdr.GetOrdinal("UsAddress")) ? null : sdr.GetString(sdr.GetOrdinal("UsAddress")),
                                UsEmail = sdr.IsDBNull(sdr.GetOrdinal("UsEmail")) ? null : sdr.GetString(sdr.GetOrdinal("UsEmail")),
                                UsMob = sdr.IsDBNull(sdr.GetOrdinal("UsMob")) ? null : sdr.GetString(sdr.GetOrdinal("UsMob")),
                                UsGstin = sdr.IsDBNull(sdr.GetOrdinal("UsGstin")) ? null : sdr.GetString(sdr.GetOrdinal("UsGstin")),
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
            return Users;
        }

        public UserMaster GetUserById(int UserId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetUserById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            return new UserMaster
                            {
                                Id = sdr.IsDBNull(sdr.GetOrdinal("Id")) ? default : sdr.GetInt32(sdr.GetOrdinal("Id")),
                                UsTypeId = sdr.IsDBNull(sdr.GetOrdinal("UsTypeId")) ? default : sdr.GetInt32(sdr.GetOrdinal("UsTypeId")),
                                UsBranchId = sdr.IsDBNull(sdr.GetOrdinal("UsBranchId")) ? default : sdr.GetInt32(sdr.GetOrdinal("UsBranchId")),
                                UsDepartmentId = sdr.IsDBNull(sdr.GetOrdinal("UsDepartmentId")) ? default : sdr.GetInt32(sdr.GetOrdinal("UsDepartmentId")),
                                UsName = sdr.IsDBNull(sdr.GetOrdinal("UsName")) ? null : sdr.GetString(sdr.GetOrdinal("UsName")),
                                UsCode = sdr.IsDBNull(sdr.GetOrdinal("UsCode")) ? null : sdr.GetString(sdr.GetOrdinal("UsCode")),
                                UsPrefix = sdr.IsDBNull(sdr.GetOrdinal("UsPrefix")) ? null : sdr.GetString(sdr.GetOrdinal("UsPrefix")),
                                UsTypeName = sdr.IsDBNull(sdr.GetOrdinal("UsTypeName")) ? null : sdr.GetString(sdr.GetOrdinal("UsTypeName")),
                                UsImg = sdr.IsDBNull(sdr.GetOrdinal("UsImg")) ? null : sdr.GetString(sdr.GetOrdinal("UsImg")),
                                UsAddress = sdr.IsDBNull(sdr.GetOrdinal("UsAddress")) ? null : sdr.GetString(sdr.GetOrdinal("UsAddress")),
                                UsEmail = sdr.IsDBNull(sdr.GetOrdinal("UsEmail")) ? null : sdr.GetString(sdr.GetOrdinal("UsEmail")),
                                UsMob = sdr.IsDBNull(sdr.GetOrdinal("UsMob")) ? null : sdr.GetString(sdr.GetOrdinal("UsMob")),
                                UsGstin = sdr.IsDBNull(sdr.GetOrdinal("UsGstin")) ? null : sdr.GetString(sdr.GetOrdinal("UsGstin")),
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

        public int SaveUser(UserMaster user)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("SaveUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure
                    //cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.Parameters.AddWithValue("@UsTypeId", (object)user.UsTypeId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsBranchId", (object)user.UsBranchId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsDepartmentId", (object)user.UsDepartmentId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsName", (object)user.UsName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsCode", (object)user.UsCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsPrefix", (object)user.UsPrefix ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsTypeName", (object)user.UsTypeName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsImg", (object)user.UsImg ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsAddress", (object)user.UsAddress ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsEmail", (object)user.UsEmail ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsMob", (object)user.UsMob ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsGstin", (object)user.UsGstin ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Created", (object)user.Created ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBy", (object)user.CreatedBy ?? DBNull.Value);

                    conn.Open();

                    // Execute the stored procedure and get the ID of the inserted record
                    return (int)cmd.ExecuteScalar();
                }
            }
        }


        public int UpdateUser(UserMaster User)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("UpdateUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure
                    cmd.Parameters.AddWithValue("@Id", User.Id);
                    cmd.Parameters.AddWithValue("@UsTypeId", (object)User.UsTypeId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsBranchId", (object)User.UsBranchId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsDepartmentId", (object)User.UsDepartmentId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsName", (object)User.UsName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsCode", (object)User.UsCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsPrefix", (object)User.UsPrefix ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsTypeName", (object)User.UsTypeName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsImg", (object)User.UsImg ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsAddress", (object)User.UsAddress ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsEmail", (object)User.UsEmail ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsMob", (object)User.UsMob ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsGstin", (object)User.UsGstin ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Updated", DateTime.Now);
                    cmd.Parameters.AddWithValue("@UpdatedBy", (object)User.UpdatedBy ?? DBNull.Value);

                    conn.Open();

                    // Execute the stored procedure and get the number of rows affected
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
