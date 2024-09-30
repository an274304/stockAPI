using DomainLayer.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices.Director.VendorBill
{
    public interface IVendorBillTableService
    {
        public List<PurchaseOrder> GetPendingBillAtDirector();
        public List<PurchaseOrder> GetApprovedBillAtDirector();
        public List<PurchaseOrder> GetRejectedBillAtDirector();
    }
}
