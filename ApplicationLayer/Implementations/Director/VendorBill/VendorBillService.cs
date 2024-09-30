using ApplicationLayer.IRepositories.Director.VendorBill;
using ApplicationLayer.IServices.Director.VendorBill;
using DomainLayer.V1.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Implementations.Director.VendorBill
{
    public class VendorBillService : IVendorBillService
    {
        private readonly IVendorBillRepo _VendorBillRepo;
        public VendorBillService(IVendorBillRepo VendorBillRepo)
        {
            _VendorBillRepo = VendorBillRepo;
        }
        public PurchaseOrderWitItems GetPendingItemsForApprovalAtDirector(string purchaseOrderNo)
        {
            return _VendorBillRepo.GetPendingItemsForApprovalAtDirector(purchaseOrderNo);
        }
    }
}
