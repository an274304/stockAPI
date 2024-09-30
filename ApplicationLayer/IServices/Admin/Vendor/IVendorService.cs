using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices.Admin.Vendor
{
    public interface IVendorService
    {
        IEnumerable<VendorMaster> GetAllVendor();
        VendorMaster GetVendorById(int VendorId);
        int DeleteVendorById(int VendorId);
        int UpdateVendor(VendorMaster Vendor, IFormFile file);
        int SaveVendor(VendorMaster Vendor, IFormFile file);
    }
}
