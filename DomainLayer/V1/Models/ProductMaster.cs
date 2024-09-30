using System;
using System.Collections.Generic;

namespace DomainLayer.V1.Models;

public partial class ProductMaster
{
    public int Id { get; set; }

    public int CatId { get; set; }

    public string? ProName { get; set; }

    public string? ProCode { get; set; }

    public string? ProPrefix { get; set; }

    public string? ProType { get; set; }

    public string? ProImg { get; set; }

    public DateTime? ProBuyDt { get; set; }

    public DateTime? ProExpDt { get; set; }

    public bool? Status { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Updated { get; set; }

    public string? UpdatedBy { get; set; }
}
