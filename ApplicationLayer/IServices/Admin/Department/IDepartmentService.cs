using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices.Admin.Department
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentMaster> GetAllDepartment();
        DepartmentMaster GetDepartmentById(int DepartmentId);
        int DeleteDepartmentById(int DepartmentId);
        int UpdateDepartment(DepartmentMaster Department, IFormFile file);
        int SaveDepartment(DepartmentMaster Department, IFormFile file);
    }
}
