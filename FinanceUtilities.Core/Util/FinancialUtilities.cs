using FinanceUtilities.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceUtilities.Core
{
    //This class should idealy be part of LoancCalculate (except maybe roundDecimal method) All of these methods are specific for calculating loan parameters
    //Another reason is that this cannot be mocked when trying to test dependant classes
    public static class FinancialUtilities
    {
        public static List<AmortizationLineItem> GetInstalmentsAmortPlan(decimal financedAmount, decimal restAmount, int numberOfInstallments, decimal roundingPrecision, int interestTypeValue, DateTime loanDate, decimal maxAllowedInterestPercentage, List<InterestPeriod> interestPeriods)
        {
            List<AmortizationLineItem> list = new List<AmortizationLineItem>();
            decimal num = financedAmount;
            InterestPeriod interestPeriod = GetInterestPeriod(loanDate, interestPeriods);
            interestPeriod.PeriodBaseAmount = financedAmount;
            int num2;
            for (int i = 0; i < numberOfInstallments; i = num2 + 1)
            {
                DateTime dateTime = loanDate.AddMonths(i);
                InterestPeriod interestPeriod2 = GetInterestPeriod(dateTime, interestPeriods);
                bool flag = interestPeriod2 != interestPeriod;
                if (flag)
                {
                    interestPeriod = interestPeriod2;
                    interestPeriod2.PeriodBaseAmount = num;
                }
                int periodRestInstallments = interestPeriod2.PeriodRestInstallments;
                decimal installmentTotalAmount = GetInstallmentTotalAmount(financedAmount, restAmount, periodRestInstallments, roundingPrecision, interestTypeValue, dateTime, interestPeriods);
                decimal interestPercentage2 = GetInterestPercentage(dateTime, maxAllowedInterestPercentage, interestPeriods);
                decimal installmentInterestAmount = GetInstallmentInterestAmount(num, interestPercentage2, roundingPrecision, interestTypeValue);
                decimal installmentBaseAmount = GetInstallmentBaseAmount(installmentTotalAmount, installmentInterestAmount);
                num -= installmentBaseAmount;
                list.Add(new AmortizationLineItem
                {
                    InstallmentAmount = installmentTotalAmount,
                    InstallmentBaseAmount = installmentBaseAmount,
                    InstallmentInterestAmount = installmentInterestAmount,
                    InstallmentDate = dateTime,
                    InstalmentNo = i + 1,
                    InterestPercentage = interestPercentage2,
                    RemainingAmount = num
                });
                num2 = i;
            }
            return list;
        }

        public static decimal GetInstallmentTotalAmount(decimal financedAmount, decimal restAmount, int numberOfInstallments, decimal roundingPrecision, int interestTypeValue, DateTime periodDate, List<InterestPeriod> interestPeriods)
        {
            InterestPeriod interestPeriod = GetInterestPeriod(periodDate, interestPeriods);
            decimal value = interestPeriod.PeriodRestInstallments;
            decimal interestPercentage2 = interestPeriod.InterestPercentage;
            decimal periodBaseAmount = interestPeriod.PeriodBaseAmount;
            decimal num = interestPercentage2 / 100m / interestTypeValue;
            decimal d = decimal.One - decimal.One / (decimal)Math.Pow((double)(decimal.One + num), (double)value);
            decimal d2 = num / d;
            return RoundDecimal((periodBaseAmount - restAmount) * d2 + restAmount * num, roundingPrecision);
        }

        public static decimal GetInterestTotalAmount(decimal financedAmount, decimal restAmount, decimal interestPercentage, int numberOfInstallments, decimal roundingPrecision, int interestTypeValue, DateTime periodDate, List<InterestPeriod> interestPeriods)
        {
            decimal num = financedAmount;
            List<decimal> list = new List<decimal>();
            decimal installmentTotalAmount = GetInstallmentTotalAmount(financedAmount, restAmount, numberOfInstallments, roundingPrecision, interestTypeValue, periodDate, interestPeriods);
            int num2;
            for (int i = 0; i < numberOfInstallments; i = num2 + 1)
            {
                decimal installmentInterestAmount = GetInstallmentInterestAmount(num, interestPercentage, roundingPrecision, interestTypeValue);
                list.Add(installmentInterestAmount);
                decimal installmentBaseAmount = GetInstallmentBaseAmount(installmentTotalAmount, installmentInterestAmount);
                num -= installmentBaseAmount;
                num2 = i;
            }
            return list.Sum();
        }

        public static decimal RoundDecimal(decimal value, decimal precision)
        {
            bool flag = value == decimal.Zero;
            decimal result;
            if (flag)
            {
                result = Math.Round(value, 2);
            }
            else
            {
                decimal d = value % decimal.One;
                decimal d2 = Math.Floor(value);
                decimal num = 0m;
                decimal d3 = 0m;
                while (d - precision > decimal.Zero)
                {
                    num += precision;
                    d -= precision;
                }
                bool flag2 = d < precision / 2m;
                if (flag2)
                {
                    d3 = 0m;
                }
                else
                {
                    d3 = precision;
                }
                result = d2 + num + d3;
            }
            return result;
        }

        private static decimal GetInstallmentInterestAmount(decimal baseValue, decimal interestPercentage, decimal roundingPrecision, int interestTypeValue)
        {
            return RoundDecimal(baseValue * (interestPercentage / 100m / interestTypeValue), roundingPrecision);
        }

        private static decimal GetInstallmentBaseAmount(decimal installmentTotalAmount, decimal installmentInterestAmount)
        {
            return installmentTotalAmount - installmentInterestAmount;
        }

        private static InterestPeriod GetInterestPeriod(DateTime installmentDate, List<InterestPeriod> interestPeriods)
        {
            bool flag = interestPeriods == null || interestPeriods.Count == 0;
            if (flag)
            {
                throw new Exception("Must insert at least one interest period");
            }
            bool flag2 = installmentDate < interestPeriods.FirstOrDefault<InterestPeriod>().StartDate || installmentDate > interestPeriods.LastOrDefault<InterestPeriod>().EndDate;
            if (flag2)
            {
                throw new Exception("Installment date is not in the interest periods range");
            }
            List<InterestPeriod> list = (from p in interestPeriods
                                         where p.StartDate <= installmentDate && p.EndDate > installmentDate
                                         select p).ToList<InterestPeriod>();
            bool flag3 = list.Count > 1;
            if (flag3)
            {
                throw new Exception("Interest period overlap");
            }
            bool flag4 = list.Count == 0;
            if (flag4)
            {
                throw new Exception("Interest period not found");
            }
            bool flag5 = list.Count == 1;
            if (flag5)
            {
                return list.FirstOrDefault<InterestPeriod>();
            }
            throw new Exception("Somehow we got here");
        }

        private static decimal GetInterestPercentage(DateTime installmentDate, decimal maxAllowedInterestPercentage, List<InterestPeriod> interestPeriods)
        {
            decimal interestPercentage = GetInterestPeriod(installmentDate, interestPeriods).InterestPercentage;
            if (interestPercentage > maxAllowedInterestPercentage)
            {
                return maxAllowedInterestPercentage;
            }

            return interestPercentage;
        }
    }
}
