using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices.Admin.Currency
{
    public interface ICurrencyService
    {
        IEnumerable<CurrencyMaster> GetAllCurrency();
        CurrencyMaster GetCurrencyById(int CurrencyId);
        int DeleteCurrencyById(int CurrencyId);
        int UpdateCurrency(CurrencyMaster Currency, IFormFile file);
        int SaveCurrency(CurrencyMaster Currency, IFormFile file);
    }
}
