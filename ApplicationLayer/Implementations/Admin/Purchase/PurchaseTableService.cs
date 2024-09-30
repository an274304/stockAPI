using ApplicationLayer.IRepositories.Admin.Purchase;
using ApplicationLayer.IServices.Admin.Purchase;
using DomainLayer.V1.Models;

namespace ApplicationLayer.Implementations.Admin.Purchase
{
    public class PurchaseTableService : IPurchaseTableService
    {
        private readonly IPurchaseTableRepo _PurchaseTableRepo;
        public PurchaseTableService(IPurchaseTableRepo purchaseTableRepo)
        {
            _PurchaseTableRepo = purchaseTableRepo;
        }
        public List<PurchaseOrder> GetApprovalPendingOrderAtAdmin()
        {
            return _PurchaseTableRepo.GetApprovalPendingOrderAtAdmin();
        }

        public List<PurchaseOrder> GetApprovedOrderAtAdmin()
        {
            return _PurchaseTableRepo.GetApprovedOrderAtAdmin();
        }

        public List<PurchaseOrder> GetOrderToApproveAtDirector()
        {
            return _PurchaseTableRepo.GetApprovedOrderAtAdmin();
        }

        public List<PurchaseOrder> GetRejectedOrderAtAdmin()
        {
            return _PurchaseTableRepo.GetRejectedOrderAtAdmin();
        }

        public List<PurchaseOrder> GetWaitingOrderAtAdmin()
        {
            return _PurchaseTableRepo.GetWaitingOrderAtAdmin();
        }
    }
}
