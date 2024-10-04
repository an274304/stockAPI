using ApplicationLayer.IRepositories.Account.VendorBill;
using ApplicationLayer.IRepositories.Director.VendorBill;
using ApplicationLayer.IServices.Account.VendorBill;
using DomainLayer.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Implementations.Account.VendorBill
{
    public class VendorBillTableAccountService : IVendorBillTableAccountService
    {
        private readonly IVendorBillTableAccountRepo _vendorBillTableAccountRepo;
        public VendorBillTableAccountService(IVendorBillTableAccountRepo vendorBillTableAccountRepo)
        {
            _vendorBillTableAccountRepo = vendorBillTableAccountRepo;
        }
        public List<PurchaseOrder> GetPayedBillAtAccount()
        {
           return _vendorBillTableAccountRepo.GetPayedBillAtAccount();
        }

        public List<PurchaseOrder> GetPendingBillAtAccount()
        {
            return _vendorBillTableAccountRepo.GetPendingBillAtAccount();
        }
    }
}
