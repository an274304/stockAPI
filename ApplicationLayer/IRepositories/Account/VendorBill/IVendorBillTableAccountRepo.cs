using DomainLayer.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IRepositories.Account.VendorBill
{
    public interface IVendorBillTableAccountRepo
    {
        public List<PurchaseOrder> GetPendingBillAtAccount();
        public List<PurchaseOrder> GetPayedBillAtAccount();
    }
}
