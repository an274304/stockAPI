using DomainLayer.V1.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices.Director.VendorBill
{
    public interface IVendorBillService
    {
        public PurchaseOrderWitItems GetPendingItemsForApprovalAtDirector(string purchaseOrderNo);
    }
}
