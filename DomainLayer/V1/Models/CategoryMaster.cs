using System;
using System.Collections.Generic;

namespace DomainLayer.V1.Models;

public partial class CategoryMaster
{
    public int Id { get; set; }

    public int CatVendorId { get; set; }

    public string? CatName { get; set; }

    public string? CatCode { get; set; }

    public string? CatPrefix { get; set; }

    public string? CatType { get; set; }

    public string? CatImg { get; set; }

    public bool? Status { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Updated { get; set; }

    public string? UpdatedBy { get; set; }
}
