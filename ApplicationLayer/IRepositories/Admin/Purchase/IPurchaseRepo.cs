using DomainLayer.V1.DTOs;
using DomainLayer.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IRepositories.Admin.Purchase
{
    public interface IPurchaseRepo
    {
        PurchaseOrder PurchaseOrder(PurchaseOrderWitItems order);
        int ItemsApproveByDirector(string purchaseOrderNo);
        int ItemsRejectByDirector(string purchaseOrderNo);
        int RemoveItemByDirector(int purchaseItemId);
        int ItemsSendToVendor(string purchaseOrderNo);
        int ReceivedItemsUpdate(PurchaseOrderWitItems updateOrder);
        PurchaseOrderWitItems GetReceivedItemsForUpdate(string purchaseOrderNo);
        //int BillSendTOAcctsAndStock(string purchaseOrderNo);
        int BillSendTOAcctsAndStock(string purchaseOrderNo, string billFileUrl);

        int UploadPayedReceiptForBill(PurchaseOrder order);
    }
}
