using DomainLayer.V1.Models;

namespace ApplicationLayer.IServices.Admin.Purchase
{
    public interface IPurchaseTableService
    {
        public List<PurchaseOrder> GetApprovalPendingOrderAtAdmin();
        public List<PurchaseOrder> GetRejectedOrderAtAdmin();
        public List<PurchaseOrder> GetApprovedOrderAtAdmin();
        public List<PurchaseOrder> GetWaitingOrderAtAdmin();
        public List<PurchaseOrder> GetOrderToApproveAtDirector();
    }
}
