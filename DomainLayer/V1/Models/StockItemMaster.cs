using System;
using System.Collections.Generic;

namespace DomainLayer.V1.Models;

public partial class StockItemMaster
{
    public int Id { get; set; }

    public int PurchaseOrderId { get; set; }

    public int PurchaseItemId { get; set; }

    public int CatId { get; set; }

    public int ProId { get; set; }

    public int VenId { get; set; }

    public int? UserAssignedId { get; set; }

    public string? StockItemCode { get; set; }

    public DateTime? StockItemExpDt { get; set; }

    public bool? IsAssigned { get; set; }

    public DateTime? AssignedDt { get; set; }

    public bool? IsDispose { get; set; }

    public DateTime? IsDisposeDt { get; set; }

    public bool? Status { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Updated { get; set; }

    public string? UpdatedBy { get; set; }
}
