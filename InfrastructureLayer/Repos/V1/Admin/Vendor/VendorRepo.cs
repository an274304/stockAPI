using ApplicationLayer.IRepositories.Admin.Vendor;
using DomainLayer.V1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repos.V1.Admin.Vendor
{
    public class VendorRepo : IVendorRepo
    {
        private string _connectionString;
        public VendorRepo(ApplicationDbContext context)
        {
            _connectionString = context.Database.GetConnectionString();
        }
        public int DeleteVendorById(int VendorId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("DeleteVendorById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VendorId", VendorId);

                    conn.Open();

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public IEnumerable<VendorMaster> GetAllVendor()
        {
            List<VendorMaster> vendors = new List<VendorMaster>();
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetAllVendor", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            vendors.Add(new VendorMaster()
                            {

                                Id = sdr.IsDBNull(sdr.GetOrdinal("Id")) ? default : sdr.GetInt32(sdr.GetOrdinal("Id")),
                                VenName = sdr.IsDBNull(sdr.GetOrdinal("VenName")) ? null : sdr.GetString(sdr.GetOrdinal("VenName")),
                                VenCode = sdr.IsDBNull(sdr.GetOrdinal("VenCode")) ? null : sdr.GetString(sdr.GetOrdinal("VenCode")),
                                VenShopName = sdr.IsDBNull(sdr.GetOrdinal("VenShopName")) ? null : sdr.GetString(sdr.GetOrdinal("VenShopName")),
                                VenImg = sdr.IsDBNull(sdr.GetOrdinal("VenImg")) ? null : sdr.GetString(sdr.GetOrdinal("VenImg")),
                                VenAddress = sdr.IsDBNull(sdr.GetOrdinal("VenAddress")) ? null : sdr.GetString(sdr.GetOrdinal("VenAddress")),
                                VenEmail = sdr.IsDBNull(sdr.GetOrdinal("VenEmail")) ? null : sdr.GetString(sdr.GetOrdinal("VenEmail")),
                                VenMob = sdr.IsDBNull(sdr.GetOrdinal("VenMob")) ? null : sdr.GetString(sdr.GetOrdinal("VenMob")),
                                VenGstin = sdr.IsDBNull(sdr.GetOrdinal("VenGstin")) ? null : sdr.GetString(sdr.GetOrdinal("VenGstin")),
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
            return vendors;
        }

        public VendorMaster GetVendorById(int VendorId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetVendorById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VendorId", VendorId);
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            return new VendorMaster
                            {
                                Id = sdr.IsDBNull(sdr.GetOrdinal("Id")) ? default : sdr.GetInt32(sdr.GetOrdinal("Id")),
                                VenName = sdr.IsDBNull(sdr.GetOrdinal("VenName")) ? null : sdr.GetString(sdr.GetOrdinal("VenName")),
                                VenCode = sdr.IsDBNull(sdr.GetOrdinal("VenCode")) ? null : sdr.GetString(sdr.GetOrdinal("VenCode")),
                                VenShopName = sdr.IsDBNull(sdr.GetOrdinal("VenShopName")) ? null : sdr.GetString(sdr.GetOrdinal("VenShopName")),
                                VenImg = sdr.IsDBNull(sdr.GetOrdinal("VenImg")) ? null : sdr.GetString(sdr.GetOrdinal("VenImg")),
                                VenAddress = sdr.IsDBNull(sdr.GetOrdinal("VenAddress")) ? null : sdr.GetString(sdr.GetOrdinal("VenAddress")),
                                VenEmail = sdr.IsDBNull(sdr.GetOrdinal("VenEmail")) ? null : sdr.GetString(sdr.GetOrdinal("VenEmail")),
                                VenMob = sdr.IsDBNull(sdr.GetOrdinal("VenMob")) ? null : sdr.GetString(sdr.GetOrdinal("VenMob")),
                                VenGstin = sdr.IsDBNull(sdr.GetOrdinal("VenGstin")) ? null : sdr.GetString(sdr.GetOrdinal("VenGstin")),
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

        public int SaveVendor(VendorMaster Vendor)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("SaveVendor", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure
                    cmd.Parameters.AddWithValue("@VenName", (object)Vendor.VenName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VenCode", (object)Vendor.VenCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VenShopName", (object)Vendor.VenShopName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VenImg", (object)Vendor.VenImg ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VenAddress", (object)Vendor.VenAddress ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VenEmail", (object)Vendor.VenEmail ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VenMob", (object)Vendor.VenMob ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VenGstin", (object)Vendor.VenGstin ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Created", (object)Vendor.Created ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBy", (object)Vendor.CreatedBy ?? DBNull.Value);

                    conn.Open();

                    // Execute the stored procedure and get the number of rows inserted
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public int UpdateVendor(VendorMaster Vendor)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("UpdateVendor", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure
                    cmd.Parameters.AddWithValue("@Id", Vendor.Id);
                    cmd.Parameters.AddWithValue("@VenName", (object)Vendor.VenName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VenCode", (object)Vendor.VenCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VenShopName", (object)Vendor.VenShopName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VenImg", (object)Vendor.VenImg ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VenAddress", (object)Vendor.VenAddress ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VenEmail", (object)Vendor.VenEmail ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VenMob", (object)Vendor.VenMob ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VenGstin", (object)Vendor.VenGstin ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Updated", DateTime.Now);
                    cmd.Parameters.AddWithValue("@UpdatedBy", (object)Vendor.UpdatedBy ?? DBNull.Value);

                    conn.Open();

                    // Execute the stored procedure and get the number of rows affected
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
