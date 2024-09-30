using ApplicationLayer.IRepositories.Admin.Purchase;
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

namespace InfrastructureLayer.Repos.V1.Admin.Purchase
{
    public class PurchaseRepo : IPurchaseRepo
    {
        private string _connectionString;
        public PurchaseRepo(ApplicationDbContext context)
        {
            _connectionString = context.Database.GetConnectionString();
        }
        public int BillSendTOAcctsAndStock(string purchaseOrderNo, string billFileUrl)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("BillSendTOAcctsAndStock", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@purchaseOrderNo", purchaseOrderNo);
                    cmd.Parameters.AddWithValue("@billFileUrl", billFileUrl);

                    conn.Open();

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public PurchaseOrderWitItems GetReceivedItemsForUpdate(string purchaseOrderNo)
        {
            PurchaseOrderWitItems purchaseOrderWitItems = new PurchaseOrderWitItems
            {
                PurchaseItems = new List<PurchaseItem>()
            };

            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetReceivedItemsForUpdate", conn))
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
                                    VendorBillPath = sdr.IsDBNull(sdr.GetOrdinal("vendorBillPath")) ? null : sdr.GetString(sdr.GetOrdinal("vendorBillPath"))
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

        public int ItemsApproveByDirector(string purchaseOrderNo)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("ItemsApproveByDirector", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@purchaseOrderNo", purchaseOrderNo);

                    conn.Open();

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public int ItemsRejectByDirector(string purchaseOrderNo)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("ItemsRejectByDirector", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@purchaseOrderNo", purchaseOrderNo);

                    conn.Open();

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public int ItemsSendToVendor(string purchaseOrderNo)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("ItemsSendToVendor", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@purchaseOrderNo", purchaseOrderNo);

                    conn.Open();

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public PurchaseOrder PurchaseOrder(PurchaseOrderWitItems order)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("InsertPurchaseOrderWithItems", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@PurchaseRemark", order.PurchaseOrder?.PurchaseRemark ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@PurchaseCurrency", order.PurchaseOrder?.PurchaseCurrency ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@PurchaseOrderDt", order.PurchaseOrder?.PurchaseOrderDt ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@PurchaseExpDelDt", order.PurchaseOrder?.PurchaseExpDelDt ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Created", order.PurchaseOrder?.Created ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CreatedBy", order.PurchaseOrder?.CreatedBy ?? (object)DBNull.Value);

            var table = new DataTable();
            table.Columns.Add("CatId", typeof(int));
            table.Columns.Add("CatName", typeof(string));
            table.Columns.Add("ProId", typeof(int));
            table.Columns.Add("ProName", typeof(string));
            table.Columns.Add("VenId", typeof(int));
            table.Columns.Add("VenName", typeof(string));
            table.Columns.Add("ItemName", typeof(string));
            table.Columns.Add("ItemRemark", typeof(string));
            table.Columns.Add("ItemRate", typeof(double));
            table.Columns.Add("ItemQty", typeof(int));

            if (order.PurchaseItems != null)
            {
                foreach (var item in order.PurchaseItems)
                {
                    table.Rows.Add(item.CatId, item.CatName, item.ProId, item.ProName, item.VenId, item.VenName, item.ItemName, item.ItemRemark, item.ItemRate, item.ItemQty);
                }
            }

            var parameter = new SqlParameter("@PurchaseItems", SqlDbType.Structured)
            {
                TypeName = "PurchaseItemType", // Define this type in SQL Server
                Value = table
            };
            command.Parameters.Add(parameter);

            var idParam = new SqlParameter("@NewPurchaseOrderId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(idParam);

            var noParam = new SqlParameter("@NewPurchaseOrderNo", SqlDbType.NVarChar, 50)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(noParam);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return new PurchaseOrder()
            {

                Id = (int)idParam.Value,
                PurchaseOrderNo = (string)noParam.Value

            };

            //return ((int)idParam.Value, (string)noParam.Value);
        }

        public int ReceivedItemsUpdate(PurchaseOrderWitItems updateOrder)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("ReceivedItemsUpdate", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Adding parameters
            command.Parameters.AddWithValue("@purchaseOrderNo", updateOrder.PurchaseOrder?.PurchaseOrderNo ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@vendorBillPath", updateOrder.PurchaseOrder?.VendorBillPath ?? (object)DBNull.Value);

            // Creating DataTable for structured parameter
            var table = new DataTable();
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("itemQty", typeof(int));
            table.Columns.Add("itemRate", typeof(double));
            table.Columns.Add("itemRemark", typeof(string));

            if (updateOrder.PurchaseItems != null)
            {
                foreach (var item in updateOrder.PurchaseItems)
                {
                    table.Rows.Add(item.Id, item.ItemQty, item.ItemRate, item.ItemRemark);
                }
            }

            var parameter = new SqlParameter("@UpdatePurchaseItemType", SqlDbType.Structured)
            {
                TypeName = "UpdatePurchaseItemType", // Ensure this type exists in SQL Server
                Value = table
            };
            command.Parameters.Add(parameter);

            // Adding output parameter if you want to return a value from stored procedure
            var returnParameter = new SqlParameter("@ReturnValue", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(returnParameter);

            connection.Open();
            command.ExecuteNonQuery();

            // Get the return value from the output parameter
            int result = (int)returnParameter.Value;

            return result;
        }


        public int RemoveItemByDirector(int purchaseItemId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("RemoveItemByDirector", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@purchaseItemId", purchaseItemId);

                    conn.Open();

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public int UploadPayedReceiptForBill(PurchaseOrder order)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("UploadPayedReceiptForBill", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@purchaseOrderNo", order.PurchaseOrderNo);
                    cmd.Parameters.AddWithValue("@AcctsBillPayReceipt", order.AcctsBillPayReceipt);

                    conn.Open();

                    return (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
