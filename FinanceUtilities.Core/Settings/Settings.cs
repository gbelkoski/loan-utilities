using FinanceUtilities.Data;
using FinanceUtilities.Domain;
using System;
using System.Linq;

namespace FinanceUtilities.Core.Settings
{
    public class Settings : ISettings
    {
        readonly IFinanceContext _context;
        readonly GlobalSettings _settings;

        public Settings(IFinanceContext context)
        {
            _context = context;
            _settings = context.GlobalSettings.FirstOrDefault();
        }

        decimal? _maxAllowedInterestPercentage;
        public decimal MaxAllowedInterestPercentage
        {
            get
            {
                if (_settings == null) throw new Exception("Global settings cannot be initialized");
                if (_maxAllowedInterestPercentage == null)
                {
                    _maxAllowedInterestPercentage = _settings.MaxAllowedInterestPercentage;
                }
                return _maxAllowedInterestPercentage.Value;
            }
        }


        private decimal _eurExchangeRate;
        public decimal EurExchangeRate
        {
            get 
            {
                if(_eurExchangeRate == 0)
                {
                    if (_context == null) throw new Exception("EurExchangeRate settings cannot be initialized");
                    var eurCurrency = _context.Currencies.FirstOrDefault(c=>c.Code=="EUR");
                    if (eurCurrency==null) throw new Exception("EurExchangeRate settings cannot be initialized");
                    _eurExchangeRate = eurCurrency.ExchangeRate;
                }
                return _eurExchangeRate; 
            }
        }
        
    }
}
