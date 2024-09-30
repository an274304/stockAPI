using DomainLayer.V1.DTOs;
using DomainLayer.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices.Admin.Stock
{
    public interface IStockService
    {
        int UpdateNewStockItem(IEnumerable<UpdateNewStockItem> newStockItems);
        PurchaseOrderWitItems GetNewStockItemsAtAdmin(string purchaseOrderNo);
        List<PurchaseOrder> GetNewStockAtAdmin();
        List<StockItemMaster> loadUpdatedStockMasterItems(string purchaseOrderNo);
    }
}
