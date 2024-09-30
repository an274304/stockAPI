using System;
using System.Collections.Generic;

namespace DomainLayer.V1.Models;

public partial class UserMaster
{
    public int Id { get; set; }

    public int UsTypeId { get; set; }

    public int UsBranchId { get; set; }

    public int UsDepartmentId { get; set; }

    public string? UsName { get; set; }

    public string? UsCode { get; set; }

    public string? UsPrefix { get; set; }

    public string? UsTypeName { get; set; }

    public string? UsImg { get; set; }

    public string? UsAddress { get; set; }

    public string? UsEmail { get; set; }

    public string? UsMob { get; set; }

    public string? UsGstin { get; set; }

    public bool? Status { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Updated { get; set; }

    public string? UpdatedBy { get; set; }

    public string? UsPassword { get; set; }
}
