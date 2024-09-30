using ApplicationLayer.IRepositories.Admin.Currency;
using ApplicationLayer.IServices.Admin.Currency;
using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ApplicationLayer.Implementations.Admin.Currency
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepo _currencyRepo;
        private readonly IUrlService _urlService;
        private readonly string fileStoragePath;
        private readonly string currencyImgPath;
        private readonly IConfiguration _configuration;

        public CurrencyService(ICurrencyRepo currencyRepo, IUrlService urlService, IHostEnvironment env, IConfiguration configuration)
        {
            _currencyRepo = currencyRepo;
            _urlService = urlService;
            _configuration = configuration;

            currencyImgPath = _configuration["FileStoragePath:currencyImgPath"];

            fileStoragePath = Path.Combine(env.ContentRootPath, "wwwroot", currencyImgPath);

            if (!Directory.Exists(fileStoragePath))
            {
                Directory.CreateDirectory(fileStoragePath);
            }
        }

        public int DeleteCurrencyById(int CurrencyId)
        {
            return _currencyRepo.DeleteCurrencyById(CurrencyId);
        }

        public IEnumerable<CurrencyMaster> GetAllCurrency()
        {
            return _currencyRepo.GetAllCurrency();
        }

        public CurrencyMaster GetCurrencyById(int CurrencyId)
        {
            return _currencyRepo.GetCurrencyById(CurrencyId);
        }

        public int SaveCurrency(CurrencyMaster Currency, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(fileStoragePath, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                Currency.CurrSymbol = Path.Combine(_urlService.GetBaseUrl(), currencyImgPath, file.FileName);
            }
            return _currencyRepo.SaveCurrency(Currency);
        }

        public int UpdateCurrency(CurrencyMaster Currency, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(fileStoragePath, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                Currency.CurrSymbol = Path.Combine(_urlService.GetBaseUrl(), currencyImgPath, file.FileName);
            }
            return _currencyRepo.UpdateCurrency(Currency);
        }
    }
}
