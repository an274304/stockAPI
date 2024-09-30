using ApplicationLayer.IRepositories.Admin.Purchase;
using ApplicationLayer.IServices.Admin.Purchase;
using DomainLayer.V1.DTOs;
using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ApplicationLayer.Implementations.Admin.Purchase
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepo _purchaseRepo;
        private readonly IUrlService _urlService;
        private readonly string fileStoragePath;
        private readonly string BillFilePath;
        private readonly string BillReceiptFilePath;
        private readonly IConfiguration _configuration;
        public PurchaseService(IPurchaseRepo purchaseRepo, IUrlService urlService, IHostEnvironment env, IConfiguration configuration)
        {
            _purchaseRepo = purchaseRepo;
            _urlService = urlService;
            _configuration = configuration;

            BillReceiptFilePath = _configuration["FileStoragePath:BillReceiptFilePath"];
            BillFilePath = _configuration["FileStoragePath:BillFilePath"];

            fileStoragePath = Path.Combine(env.ContentRootPath, "wwwroot");


        }
        public int BillSendTOAcctsAndStock(string purchaseOrderNo, IFormFile file)
        {
            string fileUrl = string.Empty;
            if (!Directory.Exists(Path.Combine(fileStoragePath, BillFilePath)))
            {
                Directory.CreateDirectory(Path.Combine(fileStoragePath, BillFilePath));
            }

            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(fileStoragePath, BillFilePath, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                fileUrl = Path.Combine(_urlService.GetBaseUrl(), BillFilePath, file.FileName);
            }

            return _purchaseRepo.BillSendTOAcctsAndStock(purchaseOrderNo, fileUrl);
        }

        public PurchaseOrderWitItems GetReceivedItemsForUpdate(string purchaseOrderNo)
        {
            return _purchaseRepo.GetReceivedItemsForUpdate(purchaseOrderNo);
        }

        public int ItemsApproveByDirector(string purchaseOrderNo)
        {
            return _purchaseRepo.ItemsApproveByDirector(purchaseOrderNo);
        }

        public int ItemsRejectByDirector(string purchaseOrderNo)
        {
            return _purchaseRepo.ItemsRejectByDirector(purchaseOrderNo);
        }

        public int ItemsSendToVendor(string purchaseOrderNo)
        {
            return _purchaseRepo.ItemsSendToVendor(purchaseOrderNo);
        }

        public PurchaseOrder PurchaseOrder(PurchaseOrderWitItems order)
        {
            return _purchaseRepo.PurchaseOrder(order);
        }

        public int ReceivedItemsUpdate(PurchaseOrderWitItems updateOrder)
        {
            return _purchaseRepo.ReceivedItemsUpdate(updateOrder);
        }

        public int RemoveItemByDirector(int purchaseItemId)
        {
            return _purchaseRepo.RemoveItemByDirector(purchaseItemId);
        }

        public int UploadPayedReceiptForBill(PurchaseOrder order)
        {
            return _purchaseRepo.UploadPayedReceiptForBill(order);
        }
    }
}
