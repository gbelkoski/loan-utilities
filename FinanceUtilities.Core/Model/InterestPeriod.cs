using System;

namespace FinanceUtilities.Core
{
    public class InterestPeriod
    {
        public int Years
        {
            get;
            set;
        }

        public DateTime StartDate
        {
            get;
            set;
        }

        public DateTime EndDate
        {
            get
            {
                return this.StartDate.AddYears(this.Years);
            }
        }

        public int NumberOfInstallments
        {
            get
            {
                return this.Years * 12;
            }
        }

        public int PeriodRestInstallments
        {
            get;
            set;
        }

        public decimal InterestPercentage
        {
            get;
            set;
        }

        public decimal PeriodBaseAmount
        {
            get;
            set;
        }

        public decimal InstallmentAmount { get; set; }
    }
}