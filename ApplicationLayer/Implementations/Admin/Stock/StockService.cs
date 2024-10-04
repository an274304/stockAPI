using ApplicationLayer.IRepositories.Admin.Stock;
using ApplicationLayer.IServices.Admin.Stock;
using DomainLayer.V1.DTOs;
using DomainLayer.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Implementations.Admin.Stock
{
    public class StockService : IStockService
    {
        private readonly IStockRepo _StockRepo;
        public StockService(IStockRepo StockRepo)
        {
            _StockRepo = StockRepo;

        }

        public List<showAvailableStockTable> GetAvailableStockAtAdmin()
        {
            return _StockRepo.GetAvailableStockAtAdmin();
        }

        public List<PurchaseOrder> GetNewStockAtAdmin()
        {
            return _StockRepo.GetNewStockAtAdmin();
        }

        public PurchaseOrderWitItems GetNewStockItemsAtAdmin(string purchaseOrderNo)
        {
            return _StockRepo.GetNewStockItemsAtAdmin(purchaseOrderNo);
        }

        public List<StockItemMaster> loadUpdatedStockMasterItems(string purchaseOrderNo)
        {
            return _StockRepo.loadUpdatedStockMasterItems(purchaseOrderNo);
        }

        public int UpdateNewStockItem(IEnumerable<UpdateNewStockItem> newStockItems)
        {
            return _StockRepo.UpdateNewStockItem(newStockItems);
        }
    }
}
