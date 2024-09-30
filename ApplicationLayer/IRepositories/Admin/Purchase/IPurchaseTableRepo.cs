using DomainLayer.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IRepositories.Admin.Purchase
{
    public interface IPurchaseTableRepo
    {
        public List<PurchaseOrder> GetApprovalPendingOrderAtAdmin();
        public List<PurchaseOrder> GetRejectedOrderAtAdmin();
        public List<PurchaseOrder> GetApprovedOrderAtAdmin();
        public List<PurchaseOrder> GetWaitingOrderAtAdmin();
        public List<PurchaseOrder> GetOrderToApproveAtDirector();
    }
}
