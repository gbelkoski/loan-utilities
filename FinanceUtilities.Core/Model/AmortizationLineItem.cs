using System;

namespace FinanceUtilities.Core.Models
{
    public class AmortizationLineItem
    {
        public int InstalmentNo
        {
            get;
            set;
        }

        public DateTime InstallmentDate
        {
            get;
            set;
        }

        public decimal InterestPercentage
        {
            get;
            set;
        }

        public decimal InstallmentInterestAmount
        {
            get;
            set;
        }

        public decimal InstallmentBaseAmount
        {
            get;
            set;
        }

        public decimal RemainingAmount
        {
            get;
            set;
        }

        public decimal InstallmentAmount
        {
            get;
            set;
        }
    }
}
