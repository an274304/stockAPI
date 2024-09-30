using System;
using System.Collections.Generic;

namespace DomainLayer.V1.Models;

public partial class UserTypeMaster
{
    public int Id { get; set; }

    public string? UsTypeName { get; set; }

    public string? UsTypeCode { get; set; }

    public string? UsTypePrefix { get; set; }

    public string? UsTypeImg { get; set; }

    public bool? Status { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Updated { get; set; }

    public string? UpdatedBy { get; set; }
}
