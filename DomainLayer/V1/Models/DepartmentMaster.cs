using System;
using System.Collections.Generic;

namespace DomainLayer.V1.Models;

public partial class DepartmentMaster
{
    public int Id { get; set; }

    public int BranchId { get; set; }

    public string? DepName { get; set; }

    public string? DepCode { get; set; }

    public string? DepPrefix { get; set; }

    public string? DepImg { get; set; }

    public bool? Status { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Updated { get; set; }

    public string? UpdatedBy { get; set; }
}
