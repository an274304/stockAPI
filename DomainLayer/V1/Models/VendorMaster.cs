using System;
using System.Collections.Generic;

namespace DomainLayer.V1.Models;

public partial class VendorMaster
{
    public int Id { get; set; }

    public string? VenName { get; set; }

    public string? VenCode { get; set; }

    public string? VenShopName { get; set; }

    public string? VenImg { get; set; }

    public string? VenAddress { get; set; }

    public string? VenEmail { get; set; }

    public string? VenMob { get; set; }

    public string? VenGstin { get; set; }

    public bool? Status { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Updated { get; set; }

    public string? UpdatedBy { get; set; }
}
