using ApplicationLayer.IRepositories.Director.VendorBill;
using DomainLayer.V1.DTOs;
using DomainLayer.V1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repos.V1.Director.VendorBill
{
    public class VendorBillRepo : IVendorBillRepo
    {
        private string _connectionString;
        public VendorBillRepo(ApplicationDbContext context)
        {
            _connectionString = context.Database.GetConnectionString();
        }
        public PurchaseOrderWitItems GetPendingItemsForApprovalAtDirector(string purchaseOrderNo)
        {
            PurchaseOrderWitItems purchaseOrderWitItems = new PurchaseOrderWitItems
            {
                PurchaseItems = new List<PurchaseItem>()
            };

            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetPendingItemsForApprovalAtDirector", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@purchaseOrderNo", purchaseOrderNo);

                    conn.Open();

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        // Initialize the purchase order variable
                        PurchaseOrder purchaseOrder = null;

                        while (sdr.Read())
                        {
                            // Check if purchase order is already set
                            if (purchaseOrder == null)
                            {
                                purchaseOrder = new PurchaseOrder
                                {
                                    Id = sdr.GetInt32(sdr.GetOrdinal("PurchaseOrderID")),
                                    PurchaseOrderNo = sdr.GetString(sdr.GetOrdinal("purchaseOrderNo")),
                                    PurchaseRemark = sdr.IsDBNull(sdr.GetOrdinal("purchaseRemark")) ? null : sdr.GetString(sdr.GetOrdinal("purchaseRemark")),
                                    PurchaseCurrency = sdr.IsDBNull(sdr.GetOrdinal("purchaseCurrency")) ? null : sdr.GetString(sdr.GetOrdinal("purchaseCurrency")),
                                    PurchaseOrderDt = sdr.IsDBNull(sdr.GetOrdinal("purchaseOrderDt")) ? null : sdr.GetDateTime(sdr.GetOrdinal("purchaseOrderDt")),
                                    PurchaseExpDelDt = sdr.IsDBNull(sdr.GetOrdinal("purchaseExpDelDt")) ? null : sdr.GetDateTime(sdr.GetOrdinal("purchaseExpDelDt"))
                                };
                            }

                            // Read purchase items for the same purchase order
                            if (!sdr.IsDBNull(sdr.GetOrdinal("PurchaseItemID")))
                            {
                                var purchaseItem = new PurchaseItem
                                {
                                    Id = sdr.GetInt32(sdr.GetOrdinal("PurchaseItemID")),
                                    ProName = sdr.IsDBNull(sdr.GetOrdinal("proName")) ? null : sdr.GetString(sdr.GetOrdinal("proName")),
                                    ItemRemark = sdr.IsDBNull(sdr.GetOrdinal("itemRemark")) ? null : sdr.GetString(sdr.GetOrdinal("itemRemark")),
                                    ItemRate = sdr.IsDBNull(sdr.GetOrdinal("itemRate")) ? null : sdr.GetDouble(sdr.GetOrdinal("itemRate")),
                                    ItemQty = sdr.IsDBNull(sdr.GetOrdinal("itemQty")) ? null : sdr.GetInt32(sdr.GetOrdinal("itemQty"))
                                };

                                purchaseOrderWitItems.PurchaseItems.Add(purchaseItem);
                            }
                        }

                        // Assign the purchase order to the result
                        purchaseOrderWitItems.PurchaseOrder = purchaseOrder;
                    }
                }
            }

            return purchaseOrderWitItems;
        }
    }
}
