using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceUtilities.Core.Settings
{
    public interface ISettings
    {
        decimal MaxAllowedInterestPercentage { get; }
        decimal EurExchangeRate { get; }
    }
}
