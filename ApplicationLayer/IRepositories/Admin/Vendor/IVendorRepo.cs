using DomainLayer.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IRepositories.Admin.Vendor
{
    public interface IVendorRepo
    {
        IEnumerable<VendorMaster> GetAllVendor();
        VendorMaster GetVendorById(int VendorId);
        int DeleteVendorById(int VendorId);
        int UpdateVendor(VendorMaster Vendor);
        int SaveVendor(VendorMaster Vendor);
    }
}
