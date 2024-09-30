using DomainLayer.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IRepositories.Admin.Currency
{
    public interface ICurrencyRepo
    {
        IEnumerable<CurrencyMaster> GetAllCurrency();
        CurrencyMaster GetCurrencyById(int CurrencyId);
        int DeleteCurrencyById(int CurrencyId);
        int UpdateCurrency(CurrencyMaster Currency);
        int SaveCurrency(CurrencyMaster Currency);
    }
}
