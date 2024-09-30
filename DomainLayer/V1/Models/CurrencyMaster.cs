using System;
using System.Collections.Generic;

namespace DomainLayer.V1.Models;

public partial class CurrencyMaster
{
    public int Id { get; set; }

    public string? CurrName { get; set; }

    public string? CurrCode { get; set; }

    public string? CurrPrefix { get; set; }

    public string? CurrSymbol { get; set; }

    public double? CurrInrVal { get; set; }

    public DateTime? CurrInrValDate { get; set; }

    public bool? Status { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Updated { get; set; }

    public string? UpdatedBy { get; set; }
}
