using ApplicationLayer.IRepositories.Admin.Currency;
using DomainLayer.V1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repos.V1.Admin.Currency
{
    public class CurrencyRepo : ICurrencyRepo
    {
        private string _connectionString;
        public CurrencyRepo(ApplicationDbContext context)
        {
            _connectionString = context.Database.GetConnectionString();
        }
        public int DeleteCurrencyById(int CurrencyId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("DeleteCurrencyById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CurrencyId", CurrencyId);

                    conn.Open();

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public IEnumerable<CurrencyMaster> GetAllCurrency()
        {
            List<CurrencyMaster> currencies = new List<CurrencyMaster>();

            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetAllCurrency", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            var idOrdinal = sdr.GetOrdinal("Id");
                            var currNameOrdinal = sdr.GetOrdinal("CurrName");
                            var currCodeOrdinal = sdr.GetOrdinal("CurrCode");
                            var currPrefixOrdinal = sdr.GetOrdinal("CurrPrefix");
                            var currSymbolOrdinal = sdr.GetOrdinal("CurrSymbol");
                            var currInrValOrdinal = sdr.GetOrdinal("CurrInrVal");
                            var currInrValDateOrdinal = sdr.GetOrdinal("CurrInrValDate");
                            var statusOrdinal = sdr.GetOrdinal("Status");
                            var createdOrdinal = sdr.GetOrdinal("Created");
                            var createdByOrdinal = sdr.GetOrdinal("CreatedBy");
                            var updatedOrdinal = sdr.GetOrdinal("Updated");
                            var updatedByOrdinal = sdr.GetOrdinal("UpdatedBy");

                            currencies.Add(new CurrencyMaster()
                            {
                                Id = sdr.IsDBNull(idOrdinal) ? default : sdr.GetInt32(idOrdinal),
                                CurrName = sdr.IsDBNull(currNameOrdinal) ? null : sdr.GetString(currNameOrdinal),
                                CurrCode = sdr.IsDBNull(currCodeOrdinal) ? null : sdr.GetString(currCodeOrdinal),
                                CurrPrefix = sdr.IsDBNull(currPrefixOrdinal) ? null : sdr.GetString(currPrefixOrdinal),
                                CurrSymbol = sdr.IsDBNull(currSymbolOrdinal) ? null : sdr.GetString(currSymbolOrdinal),
                                CurrInrVal = sdr.IsDBNull(currInrValOrdinal) ? null : sdr.GetDouble(currInrValOrdinal),
                                CurrInrValDate = sdr.IsDBNull(currInrValDateOrdinal) ? null : sdr.GetDateTime(currInrValDateOrdinal),
                                Status = sdr.IsDBNull(statusOrdinal) ? null : sdr.GetBoolean(statusOrdinal),
                                Created = sdr.IsDBNull(createdOrdinal) ? null : sdr.GetDateTime(createdOrdinal),
                                CreatedBy = sdr.IsDBNull(createdByOrdinal) ? null : sdr.GetString(createdByOrdinal),
                                Updated = sdr.IsDBNull(updatedOrdinal) ? null : sdr.GetDateTime(updatedOrdinal),
                                UpdatedBy = sdr.IsDBNull(updatedByOrdinal) ? null : sdr.GetString(updatedByOrdinal)
                            });
                        }
                    }
                }
            }
            return currencies;
        }

        public CurrencyMaster GetCurrencyById(int currencyId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetCurrencyById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CurrencyId", currencyId);
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            var idOrdinal = sdr.GetOrdinal("Id");
                            var currNameOrdinal = sdr.GetOrdinal("CurrName");
                            var currCodeOrdinal = sdr.GetOrdinal("CurrCode");
                            var currPrefixOrdinal = sdr.GetOrdinal("CurrPrefix");
                            var currSymbolOrdinal = sdr.GetOrdinal("CurrSymbol");
                            var currInrValOrdinal = sdr.GetOrdinal("CurrInrVal");
                            var currInrValDateOrdinal = sdr.GetOrdinal("CurrInrValDate");
                            var statusOrdinal = sdr.GetOrdinal("Status");
                            var createdOrdinal = sdr.GetOrdinal("Created");
                            var createdByOrdinal = sdr.GetOrdinal("CreatedBy");
                            var updatedOrdinal = sdr.GetOrdinal("Updated");
                            var updatedByOrdinal = sdr.GetOrdinal("UpdatedBy");

                            return new CurrencyMaster
                            {
                                Id = sdr.IsDBNull(idOrdinal) ? default : sdr.GetInt32(idOrdinal),
                                CurrName = sdr.IsDBNull(currNameOrdinal) ? null : sdr.GetString(currNameOrdinal),
                                CurrCode = sdr.IsDBNull(currCodeOrdinal) ? null : sdr.GetString(currCodeOrdinal),
                                CurrPrefix = sdr.IsDBNull(currPrefixOrdinal) ? null : sdr.GetString(currPrefixOrdinal),
                                CurrSymbol = sdr.IsDBNull(currSymbolOrdinal) ? null : sdr.GetString(currSymbolOrdinal),
                                CurrInrVal = sdr.IsDBNull(currInrValOrdinal) ? null : sdr.GetDouble(currInrValOrdinal),
                                CurrInrValDate = sdr.IsDBNull(currInrValDateOrdinal) ? null : sdr.GetDateTime(currInrValDateOrdinal),
                                Status = sdr.IsDBNull(statusOrdinal) ? null : sdr.GetBoolean(statusOrdinal),
                                Created = sdr.IsDBNull(createdOrdinal) ? null : sdr.GetDateTime(createdOrdinal),
                                CreatedBy = sdr.IsDBNull(createdByOrdinal) ? null : sdr.GetString(createdByOrdinal),
                                Updated = sdr.IsDBNull(updatedOrdinal) ? null : sdr.GetDateTime(updatedOrdinal),
                                UpdatedBy = sdr.IsDBNull(updatedByOrdinal) ? null : sdr.GetString(updatedByOrdinal)
                            };
                        }
                    }
                }
            }

            return null;
        }


        public int SaveCurrency(CurrencyMaster Currency)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("SaveCurrency", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure except Id
                    cmd.Parameters.AddWithValue("@CurrName", (object)Currency.CurrName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CurrCode", (object)Currency.CurrCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CurrPrefix", (object)Currency.CurrPrefix ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CurrSymbol", (object)Currency.CurrSymbol ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CurrInrVal", (object)Currency.CurrInrVal ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CurrInrValDate", (object)Currency.CurrInrValDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Created", DateTime.Now);
                    cmd.Parameters.AddWithValue("@CreatedBy", (object)Currency.CreatedBy ?? DBNull.Value);

                    conn.Open();

                    // Execute the stored procedure and get the number of rows inserted
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public int UpdateCurrency(CurrencyMaster currency)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("UpdateCurrency", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the stored procedure
                    cmd.Parameters.AddWithValue("@CurrencyId", currency.Id); // Identifier for the record to update
                    cmd.Parameters.AddWithValue("@CurrName", (object)currency.CurrName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CurrCode", (object)currency.CurrCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CurrPrefix", (object)currency.CurrPrefix ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CurrSymbol", (object)currency.CurrSymbol ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CurrInrVal", (object)currency.CurrInrVal ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CurrInrValDate", (object)currency.CurrInrValDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Updated", currency.Updated ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@UpdatedBy", (object)currency.UpdatedBy ?? DBNull.Value);

                    conn.Open();

                    // Execute the stored procedure and get the number of rows affected
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

    }
}
