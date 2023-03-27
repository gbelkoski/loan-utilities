using FinanceUtilities.Core.Models;
using System;
using System.Collections.Generic;

namespace FinanceUtilities.Core
{
    public class LoanCalculate : ILoanCalculate
    {
        // TO DO: make these input parameters (up until Number of installments)
        public decimal LoanAmount
        {
            get;
            set;
        }

        public LoanInterestType LoanInterestType
        {
            get;
            set;
        }

        public DateTime LoanDate
        {
            get;
            set;
        }

        public int NumberOfInstallments
        {
            get;
            set;
        }

        public decimal InterestPercentage
        {
            get;
            set;
        }

        public decimal RemainingAmountPercentage
        {
            get;
            set;
        }

        public decimal RemainingAmount
        {
            get;
            set;
        }

        public decimal RoundingPrecision
        {
            get;
            set;
        }

        public decimal CalculationPrecision
        {
            get;
            set;
        }

        public decimal RealFinancedAmount
        {
            get;
            private set;
        }

        public List<AmortizationLineItem> AmortizationItems
        {
            get;
            private set;
        }

        public decimal InstallmentAmount
        {
            get;
            set;
        }

        public decimal InstallmentAmountTotal
        {
            get;
            set;
        }

        public decimal InstallmentInterestAmountTotal
        {
            get;
            set;
        }

        #region Ctor

        //TODO: This class can be turned in a simple method in a service
        // Initialization can be done inside that method. Return type can be LoanTotals.
        // There is even an option to be part of the LoanProduct domain object.
        public LoanCalculate(DateTime startDate)
        {
            // TO DO: initailize these stuff in settings
            this.RemainingAmountPercentage = decimal.Zero;
            this.CalculationPrecision = 0.001m;
            this.RoundingPrecision = 0.01m;
            this.LoanInterestType = LoanInterestType.Yearly;
        }

        #endregion

        #region Methods

        public void CalculateLoan(List<InterestPeriod> interestPeriods, decimal maxAllowedInterestPercentage)
        {
            decimal installmentTotalAmount = 0m;
            decimal installmentInterestTotalAmount = 0m;
            decimal realFinancedSum = 0m;
            decimal financedAmount = 0m;

            if (this.RemainingAmountPercentage != decimal.Zero)
            {
                this.RemainingAmount = this.LoanAmount * (this.RemainingAmountPercentage / 100m);
                //but why? it gets overriden anyway
                financedAmount -= this.RemainingAmount;
            }
            financedAmount = this.LoanAmount;
            realFinancedSum = financedAmount;
            installmentTotalAmount = FinancialUtilities.GetInstallmentTotalAmount(financedAmount, this.RemainingAmount, this.NumberOfInstallments, this.CalculationPrecision, (int)this.LoanInterestType, this.LoanDate, interestPeriods);
            installmentInterestTotalAmount = FinancialUtilities.GetInterestTotalAmount(financedAmount, this.RemainingAmount, this.InterestPercentage, this.NumberOfInstallments, this.CalculationPrecision, (int)this.LoanInterestType, this.LoanDate, interestPeriods);
            this.InstallmentAmount = FinancialUtilities.RoundDecimal(installmentTotalAmount, this.RoundingPrecision);
            this.InstallmentAmountTotal = FinancialUtilities.RoundDecimal(this.InstallmentAmount * this.NumberOfInstallments, this.RoundingPrecision);
            this.InstallmentInterestAmountTotal = FinancialUtilities.RoundDecimal(installmentInterestTotalAmount, this.RoundingPrecision);
            this.RealFinancedAmount = FinancialUtilities.RoundDecimal(realFinancedSum, this.RoundingPrecision);
            this.AmortizationItems = FinancialUtilities.GetInstalmentsAmortPlan(this.RealFinancedAmount, this.RemainingAmount, this.NumberOfInstallments, this.CalculationPrecision, (int)this.LoanInterestType, this.LoanDate, maxAllowedInterestPercentage, interestPeriods);
        }

        #endregion
    }
}