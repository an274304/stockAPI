using System;
using System.Collections.Generic;

namespace DomainLayer.V1.Models;

public partial class PurchaseItem
{
    public int Id { get; set; }

    public int PurchaseOrderId { get; set; }

    public string? PurchaseOrderNo { get; set; }

    public int? CatId { get; set; }

    public string? CatName { get; set; }

    public int? ProId { get; set; }

    public string? ProName { get; set; }

    public int? VenId { get; set; }

    public string? VenName { get; set; }

    public string? ItemName { get; set; }

    public string? ItemRemark { get; set; }

    public double? ItemRate { get; set; }

    public int? ItemQty { get; set; }

    public bool? IsApproveItemStatusByDirector { get; set; }

    public bool? Status { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Updated { get; set; }

    public string? UpdatedBy { get; set; }
}
