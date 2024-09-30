using DomainLayer.V1.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IRepositories.Director.VendorBill
{
    public interface IVendorBillRepo
    {
        public PurchaseOrderWitItems GetPendingItemsForApprovalAtDirector(string purchaseOrderNo);
    }
}
