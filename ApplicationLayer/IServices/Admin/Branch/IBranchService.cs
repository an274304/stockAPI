using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices.Admin.Branch
{
    public interface IBranchService
    {
        IEnumerable<BranchMaster> GetAllBranch();
        BranchMaster GetBranchById(int BranchId);
        int DeleteBranchById(int BranchId);
        int UpdateBranch(BranchMaster Branch, IFormFile file);
        int SaveBranch(BranchMaster Branch, IFormFile file);
    }
}
