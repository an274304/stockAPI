using DomainLayer.V1.DTOs;
using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Http;

namespace ApplicationLayer.IServices.Admin.Purchase
{
    public interface IPurchaseService
    {
        PurchaseOrder PurchaseOrder(PurchaseOrderWitItems order);
        int ItemsApproveByDirector(string purchaseOrderNo);
        int ItemsRejectByDirector(string purchaseOrderNo);
        int RemoveItemByDirector(int purchaseItemId);
        int ItemsSendToVendor(string purchaseOrderNo);
        int ReceivedItemsUpdate(PurchaseOrderWitItems updateOrder);
        PurchaseOrderWitItems GetReceivedItemsForUpdate(string purchaseOrderNo);
        int BillSendTOAcctsAndStock(string purchaseOrderNo, IFormFile file);
        int UploadPayedReceiptForBill(string purchaseOrderNo, IFormFile file);
    }
}
