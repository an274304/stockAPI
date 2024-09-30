using System;
using System.Collections.Generic;

namespace DomainLayer.V1.Models;

public partial class CurrencyMasterLog
{
    public int Id { get; set; }

    public int CurrId { get; set; }

    public string? PreCurrName { get; set; }

    public string? PreCurrCode { get; set; }

    public string? PreCurrPrefix { get; set; }

    public string? PreCurrSymbol { get; set; }

    public double? PreCurrInrVal { get; set; }

    public DateTime? PreCurrInrValDate { get; set; }

    public string? PreCurrRemark { get; set; }

    public bool? Status { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Updated { get; set; }

    public string? UpdatedBy { get; set; }
}
