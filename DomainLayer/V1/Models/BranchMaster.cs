using System;
using System.Collections.Generic;

namespace DomainLayer.V1.Models;

public partial class BranchMaster
{
    public int Id { get; set; }

    public string? BranchName { get; set; }

    public string? BranchCode { get; set; }

    public string? BranchPrefix { get; set; }

    public string? BranchImg { get; set; }

    public bool? Status { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Updated { get; set; }

    public string? UpdatedBy { get; set; }
}
