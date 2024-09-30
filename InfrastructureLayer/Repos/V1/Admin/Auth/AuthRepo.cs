using ApplicationLayer.IRepositories.Admin.Auth;
using DomainLayer.AuthDTOs;
using DomainLayer.V1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repos.V1.Admin.Auth
{
    public class AuthRepo : IAuthRepo
    {
        private string _connectionString;
        public AuthRepo(ApplicationDbContext context)
        {
            _connectionString = context.Database.GetConnectionString();
        }

        public List<UserTypeMaster> GetAllUserType()
        {
            List<UserTypeMaster> userTypes = new List<UserTypeMaster>();
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetAllUserType", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            userTypes.Add(new UserTypeMaster()
                            {
                                Id = sdr.IsDBNull(sdr.GetOrdinal("Id")) ? default : sdr.GetInt32(sdr.GetOrdinal("Id")),
                                UsTypeName = sdr.IsDBNull(sdr.GetOrdinal("UsTypeName")) ? null : sdr.GetString(sdr.GetOrdinal("UsTypeName")),
                                UsTypeCode = sdr.IsDBNull(sdr.GetOrdinal("UsTypeCode")) ? null : sdr.GetString(sdr.GetOrdinal("UsTypeCode")),
                                UsTypePrefix = sdr.IsDBNull(sdr.GetOrdinal("UsTypePrefix")) ? null : sdr.GetString(sdr.GetOrdinal("UsTypePrefix")),
                                UsTypeImg = sdr.IsDBNull(sdr.GetOrdinal("UsTypeImg")) ? null : sdr.GetString(sdr.GetOrdinal("UsTypeImg")),
                                Status = sdr.IsDBNull(sdr.GetOrdinal("Status")) ? (bool?)null : sdr.GetBoolean(sdr.GetOrdinal("Status")),
                                Created = sdr.IsDBNull(sdr.GetOrdinal("Created")) ? (DateTime?)null : sdr.GetDateTime(sdr.GetOrdinal("Created")),
                                CreatedBy = sdr.IsDBNull(sdr.GetOrdinal("CreatedBy")) ? null : sdr.GetString(sdr.GetOrdinal("CreatedBy")),
                                Updated = sdr.IsDBNull(sdr.GetOrdinal("Updated")) ? (DateTime?)null : sdr.GetDateTime(sdr.GetOrdinal("Updated")),
                                UpdatedBy = sdr.IsDBNull(sdr.GetOrdinal("UpdatedBy")) ? null : sdr.GetString(sdr.GetOrdinal("UpdatedBy"))
                            });
                        }
                    }
                }
            }
            return userTypes;
        }

        public UserMaster Login(LogInDTO logIn)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("Login", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", logIn.email);
                    cmd.Parameters.AddWithValue("@Password", logIn.password);

                    conn.Open();

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            return new UserMaster
                            {
                                Id = sdr.GetInt32(sdr.GetOrdinal("id")),
                                UsTypeId = sdr.GetInt32(sdr.GetOrdinal("usTypeId")),
                                UsBranchId = sdr.GetInt32(sdr.GetOrdinal("usBranchId")),
                                UsDepartmentId = sdr.GetInt32(sdr.GetOrdinal("usDepartmentId")),
                                UsName = sdr["usName"] as string,
                                UsCode = sdr["usCode"] as string,
                                UsPrefix = sdr["usPrefix"] as string,
                                UsTypeName = sdr["usTypeName"] as string,
                                UsImg = sdr["usImg"] as string,
                                UsAddress = sdr["usAddress"] as string,
                                UsEmail = sdr["usEmail"] as string,
                                UsMob = sdr["usMob"] as string,
                                UsGstin = sdr["usGSTIN"] as string,
                                Status = sdr["status"] as bool?,
                                Created = sdr["created"] as DateTime?,
                                CreatedBy = sdr["createdBy"] as string,
                                Updated = sdr["updated"] as DateTime?,
                                UpdatedBy = sdr["updatedBy"] as string,
                                UsPassword = sdr["usPassword"] as string
                            };
                        }

                        return null; // No user found with the provided credentials
                    }
                }
            }
        }

    }
}