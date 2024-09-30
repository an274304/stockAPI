using DomainLayer.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IRepositories.Admin.Department
{
    public interface IDepartmentRepo
    {
        IEnumerable<DepartmentMaster> GetAllDepartment();
        DepartmentMaster GetDepartmentById(int DepartmentId);
        int DeleteDepartmentById(int DepartmentId);
        int UpdateDepartment(DepartmentMaster Department);
        int SaveDepartment(DepartmentMaster Department);
    }
}
