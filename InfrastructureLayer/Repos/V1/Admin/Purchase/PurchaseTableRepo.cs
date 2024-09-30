using ApplicationLayer.IRepositories.Admin.Purchase;
using DomainLayer.V1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InfrastructureLayer.Repos.V1.Admin.Purchase
{
    public class PurchaseTableRepo : IPurchaseTableRepo
    {
        private string _connectionString;
        public PurchaseTableRepo(ApplicationDbContext context)
        {
            _connectionString = context.Database.GetConnectionString();
        }

        public List<PurchaseOrder> GetApprovalPendingOrderAtAdmin()
        {
            List<PurchaseOrder> purchaseOrder = new List<PurchaseOrder>();
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetApprovalPendingOrderAtAdmin", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            purchaseOrder.Add(new PurchaseOrder()
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
            return purchaseOrder;
        }

        public List<PurchaseOrder> GetApprovedOrderAtAdmin()
        {
            List<PurchaseOrder> purchaseOrder = new List<PurchaseOrder>();
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetApprovedOrderAtAdmin", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            purchaseOrder.Add(new PurchaseOrder()
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
            return purchaseOrder;
        }

        public List<PurchaseOrder> GetRejectedOrderAtAdmin()
        {
            List<PurchaseOrder> purchaseOrder = new List<PurchaseOrder>();
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetRejectedOrderAtAdmin", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            purchaseOrder.Add(new PurchaseOrder()
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
            return purchaseOrder;
        }

        public List<PurchaseOrder> GetWaitingOrderAtAdmin()
        {
            List<PurchaseOrder> purchaseOrder = new List<PurchaseOrder>();
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetWaitingOrderAtAdmin", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            purchaseOrder.Add(new PurchaseOrder()
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
            return purchaseOrder;
        }

        public List<PurchaseOrder> GetOrderToApproveAtDirector()
        {
            List<PurchaseOrder> purchaseOrder = new List<PurchaseOrder>();
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetOrderToApproveAtDirector", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            purchaseOrder.Add(new PurchaseOrder()
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
            return purchaseOrder;
        }
    }
}
