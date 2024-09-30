using DomainLayer.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IRepositories.Admin.Branch
{
    public interface IBranchRepo
    {
        IEnumerable<BranchMaster> GetAllBranch();
        BranchMaster GetBranchById(int BranchId);
        int DeleteBranchById(int BranchId);
        int UpdateBranch(BranchMaster Branch);
        int SaveBranch(BranchMaster Branch);
    }
}
