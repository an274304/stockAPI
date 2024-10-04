using ApplicationLayer.IRepositories.Admin.Stock;
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

namespace InfrastructureLayer.Repos.V1.Admin.Stock
{
    public class StockRepo : IStockRepo
    {
        private string _connectionString;
        public StockRepo(ApplicationDbContext context)
        {
            _connectionString = context.Database.GetConnectionString();
        }

        public List<showAvailableStockTable> GetAvailableStockAtAdmin()
        {
            List<showAvailableStockTable> stocks = new List<showAvailableStockTable>();
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("showAvailableStockTable", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            stocks.Add(new showAvailableStockTable()
                            {
                                CategoryName = sdr.IsDBNull(sdr.GetOrdinal("CategoryName")) ? null : sdr.GetString(sdr.GetOrdinal("CategoryName")),
                                ProductName = sdr.IsDBNull(sdr.GetOrdinal("ProductName")) ? null : sdr.GetString(sdr.GetOrdinal("ProductName")),
                                Total = sdr.IsDBNull(sdr.GetOrdinal("Total")) ? default : sdr.GetInt32(sdr.GetOrdinal("Total")),
                                TotalAvailable = sdr.IsDBNull(sdr.GetOrdinal("TotalAvailable")) ? default : sdr.GetInt32(sdr.GetOrdinal("TotalAvailable")),
                                TotalAssigned = sdr.IsDBNull(sdr.GetOrdinal("TotalAssigned")) ? default : sdr.GetInt32(sdr.GetOrdinal("TotalAssigned")),
                                TotalDispose = sdr.IsDBNull(sdr.GetOrdinal("TotalDispose")) ? default : sdr.GetInt32(sdr.GetOrdinal("TotalDispose"))
                            });
                        }
                    }
                }
            }
            return stocks;
        }

        public List<PurchaseOrder> GetNewStockAtAdmin()
        {
            List<PurchaseOrder> orders = new List<PurchaseOrder>();
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetNewStockAtAdmin", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            orders.Add(new PurchaseOrder()
                            {
                                Id = sdr.IsDBNull(sdr.GetOrdinal("Id")) ? default : sdr.GetInt32(sdr.GetOrdinal("Id")),
                                PurchaseOrderNo = sdr.IsDBNull(sdr.GetOrdinal("PurchaseOrderNo")) ? null : sdr.GetString(sdr.GetOrdinal("PurchaseOrderNo")),
                                PurchaseRemark = sdr.IsDBNull(sdr.GetOrdinal("PurchaseRemark")) ? null : sdr.GetString(sdr.GetOrdinal("PurchaseRemark")),
                                PurchaseCurrency = sdr.IsDBNull(sdr.GetOrdinal("PurchaseCurrency")) ? null : sdr.GetString(sdr.GetOrdinal("PurchaseCurrency")),
                                PurchaseOrderDt = sdr.IsDBNull(sdr.GetOrdinal("PurchaseOrderDt")) ? null : sdr.GetDateTime(sdr.GetOrdinal("PurchaseOrderDt")),
                                PurchaseExpDelDt = sdr.IsDBNull(sdr.GetOrdinal("PurchaseExpDelDt")) ? null : sdr.GetDateTime(sdr.GetOrdinal("PurchaseExpDelDt")),
                                IsFromAdminToDirector = sdr.IsDBNull(sdr.GetOrdinal("IsFromAdminToDirector")) ? null : sdr.GetBoolean(sdr.GetOrdinal("IsFromAdminToDirector")),
                                IsFromAdminToVendor = sdr.IsDBNull(sdr.GetOrdinal("IsFromAdminToVendor")) ? null : sdr.GetBoolean(sdr.GetOrdinal("IsFromAdminToVendor")),
                                VendorBillPath = sdr.IsDBNull(sdr.GetOrdinal("VendorBillPath")) ? null : sdr.GetString(sdr.GetOrdinal("VendorBillPath")),
                                IsFromAdminToAccts = sdr.IsDBNull(sdr.GetOrdinal("IsFromAdminToAccts")) ? null : sdr.GetBoolean(sdr.GetOrdinal("IsFromAdminToAccts")),
                                IsFromAdminToStock = sdr.IsDBNull(sdr.GetOrdinal("IsFromAdminToStock")) ? null : sdr.GetBoolean(sdr.GetOrdinal("IsFromAdminToStock")),
                                AcctsBillPayReceipt = sdr.IsDBNull(sdr.GetOrdinal("AcctsBillPayReceipt")) ? null : sdr.GetString(sdr.GetOrdinal("AcctsBillPayReceipt")),
                                IsAcctsBillPayed = sdr.IsDBNull(sdr.GetOrdinal("IsAcctsBillPayed")) ? null : sdr.GetBoolean(sdr.GetOrdinal("IsAcctsBillPayed")),
                                IsAdminNewStockUpdate = sdr.IsDBNull(sdr.GetOrdinal("IsAdminNewStockUpdate")) ? null : sdr.GetBoolean(sdr.GetOrdinal("IsAdminNewStockUpdate")),
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
            return orders;
        }

        public PurchaseOrderWitItems GetNewStockItemsAtAdmin(string purchaseOrderNo)
        {
            PurchaseOrderWitItems purchaseOrderWitItems = new PurchaseOrderWitItems
            {
                PurchaseItems = new List<PurchaseItem>()
            };

            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetNewStockItemsAtAdmin", conn))
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
                                    PurchaseExpDelDt = sdr.IsDBNull(sdr.GetOrdinal("purchaseExpDelDt")) ? null : sdr.GetDateTime(sdr.GetOrdinal("purchaseExpDelDt")),
                                    VendorBillPath = sdr.IsDBNull(sdr.GetOrdinal("vendorBillPath")) ? null : sdr.GetString(sdr.GetOrdinal("vendorBillPath")),
                                    AcctsBillPayReceipt = sdr.IsDBNull(sdr.GetOrdinal("acctsBillPayReceipt")) ? null : sdr.GetString(sdr.GetOrdinal("acctsBillPayReceipt")),
                                    IsAdminNewStockUpdate = sdr.IsDBNull(sdr.GetOrdinal("isAdminNewStockUpdate")) ? null : sdr.GetBoolean(sdr.GetOrdinal("isAdminNewStockUpdate"))
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

        public List<StockItemMaster> loadUpdatedStockMasterItems(string purchaseOrderNo)
        {
            List<StockItemMaster> items = new List<StockItemMaster>();
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("loadUpdatedStockMasterItems", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@purchaseOrderNo", purchaseOrderNo);
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new StockItemMaster()
                            {
                                Id = sdr.IsDBNull(sdr.GetOrdinal("Id")) ? default : sdr.GetInt32(sdr.GetOrdinal("Id")),
                                PurchaseOrderId = sdr.IsDBNull(sdr.GetOrdinal("PurchaseOrderId")) ? default : sdr.GetInt32(sdr.GetOrdinal("PurchaseOrderId")),
                                PurchaseItemId = sdr.IsDBNull(sdr.GetOrdinal("PurchaseItemId")) ? default : sdr.GetInt32(sdr.GetOrdinal("PurchaseItemId")),
                                CatId = sdr.IsDBNull(sdr.GetOrdinal("CatId")) ? default : sdr.GetInt32(sdr.GetOrdinal("CatId")),
                                ProId = sdr.IsDBNull(sdr.GetOrdinal("ProId")) ? default : sdr.GetInt32(sdr.GetOrdinal("ProId")),
                                VenId = sdr.IsDBNull(sdr.GetOrdinal("VenId")) ? default : sdr.GetInt32(sdr.GetOrdinal("VenId")),
                                UserAssignedId = sdr.IsDBNull(sdr.GetOrdinal("UserAssignedId")) ? null : sdr.GetInt32(sdr.GetOrdinal("UserAssignedId")),
                                StockItemCode = sdr.IsDBNull(sdr.GetOrdinal("StockItemCode")) ? null : sdr.GetString(sdr.GetOrdinal("StockItemCode")),
                                StockItemExpDt = sdr.IsDBNull(sdr.GetOrdinal("StockItemExpDt")) ? null : sdr.GetDateTime(sdr.GetOrdinal("StockItemExpDt")),
                                IsAssigned = sdr.IsDBNull(sdr.GetOrdinal("IsAssigned")) ? null : sdr.GetBoolean(sdr.GetOrdinal("IsAssigned")),
                                AssignedDt = sdr.IsDBNull(sdr.GetOrdinal("AssignedDt")) ? null : sdr.GetDateTime(sdr.GetOrdinal("AssignedDt")),
                                IsDispose = sdr.IsDBNull(sdr.GetOrdinal("IsDispose")) ? null : sdr.GetBoolean(sdr.GetOrdinal("IsDispose")),
                                IsDisposeDt = sdr.IsDBNull(sdr.GetOrdinal("IsDisposeDt")) ? null : sdr.GetDateTime(sdr.GetOrdinal("IsDisposeDt")),
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
            return items;
        }

        public int UpdateNewStockItem(IEnumerable<UpdateNewStockItem> newStockItems)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("InsertStockItemsFromDTOs", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Convert IEnumerable<UpdateNewStockItem> to DataTable
                    var table = new DataTable();
                    table.Columns.Add("PurchaseOrderNo", typeof(string));
                    table.Columns.Add("PurchaseItemId", typeof(int));
                    table.Columns.Add("ItemExpiryDt", typeof(DateTime));

                    foreach (var item in newStockItems)
                    {
                        table.Rows.Add(item.PurchaseOrderNo, item.PurchaseItemId, item.ItemExpiryDt);
                    }

                    // Add parameter to command
                    var param = new SqlParameter
                    {
                        ParameterName = "@Items",
                        SqlDbType = SqlDbType.Structured,
                        Value = table,
                        TypeName = "UpdateNewStockItemType"
                    };
                    cmd.Parameters.Add(param);

                    conn.Open();

                    // Execute stored procedure and return result
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

    }
}
