using ApplicationLayer.IRepositories.Admin.Purchase;
using ApplicationLayer.IRepositories.Director.VendorBill;
using ApplicationLayer.IServices.Director.VendorBill;
using DomainLayer.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Implementations.Director.VendorBill
{
    public class VendorBillTableService : IVendorBillTableService
    {
        private readonly IVendorBillTableRepo _vendorBillTableRepo;
        public VendorBillTableService(IVendorBillTableRepo vendorBillTableRepo)
        {
            _vendorBillTableRepo = vendorBillTableRepo;
        }
        public List<PurchaseOrder> GetApprovedBillAtDirector()
        {
            return _vendorBillTableRepo.GetApprovedBillAtDirector();
        }

        public List<PurchaseOrder> GetPendingBillAtDirector()
        {
            return _vendorBillTableRepo.GetPendingBillAtDirector();
        }

        public List<PurchaseOrder> GetRejectedBillAtDirector()
        {
            return _vendorBillTableRepo.GetRejectedBillAtDirector();
        }
    }
}
