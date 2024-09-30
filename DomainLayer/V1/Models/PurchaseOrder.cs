using System;
using System.Collections.Generic;

namespace DomainLayer.V1.Models;

public partial class PurchaseOrder
{
    public int Id { get; set; }

    public string? PurchaseOrderNo { get; set; }

    public string? PurchaseRemark { get; set; }

    public string? PurchaseCurrency { get; set; }

    public DateTime? PurchaseOrderDt { get; set; }

    public DateTime? PurchaseExpDelDt { get; set; }

    public bool? IsFromAdminToDirector { get; set; }

    public bool? IsFromAdminToVendor { get; set; }

    public string? VendorBillPath { get; set; }

    public bool? IsFromAdminToAccts { get; set; }

    public bool? IsFromAdminToStock { get; set; }

    public string? AcctsBillPayReceipt { get; set; }

    public bool? IsAcctsBillPayed { get; set; }

    public bool? IsAdminNewStockUpdate { get; set; }

    public bool? Status { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Updated { get; set; }

    public string? UpdatedBy { get; set; }
}
