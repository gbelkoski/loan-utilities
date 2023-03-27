using System;
using System.Collections.Generic;
using System.Linq;
using FinanceUtilities.Core.Mappers;
using FinanceUtilities.Core.Models;
using FinanceUtilities.Core.Settings;
using FinanceUtilities.Data;
using FinanceUtilities.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinanceUtilities.Core
{
    public class LoanCompareService : ServiceBase, ILoanCompareService
    {
        private readonly IFinanceContext context;
        readonly ILoanTotalsFactory _loanPublicDetailsDtoFactory;
        readonly IExpensesService _expensesService;
        readonly ISettings _settings;
        readonly ICurrencyUtils _currencyUtils;

        public LoanCompareService(IFinanceContext context, ILoanTotalsFactory loanPublicDetailsDtoFactory, IExpensesService expensesService, ISettings settings, ICurrencyUtils currencyUtils) : base(context)
        {
            this.context = context;
            _loanPublicDetailsDtoFactory = loanPublicDetailsDtoFactory;
            _expensesService = expensesService;
            _settings = settings;
            _currencyUtils = currencyUtils;
        }

        public List<LoanTotals> CalculateLoanProductTotals(int years, decimal amount, bool willChangeBank, string currencyCode, string loanTypeId, int? bankId)
        {
            List<LoanTotals> result = new List<LoanTotals>();

            //convert amount in local currency (MKD)
            var amountLcy = _currencyUtils.ConvertToLcy(amount, currencyCode);

            var loanProducts = _context.LoanProducts
                .Where(l => !l.IsDeleted)
                .Include(l => l.InterestPeriods)
                .Include(l => l.Bank)
                .Include(l => l.LoanProductExpenses)
                .ThenInclude(l => l.ExpenseType)
                .Include(l => l.LoanProductExpenses)
                .Include(l => l.Currency)
                .Where(l => l.LoanTypeId == loanTypeId
                && (l.MaximumAmount * l.Currency.ExchangeRate) >= amountLcy
                && l.MaxDuration >= years * 12).ToList();
            foreach (var lProduct in loanProducts)
            {
                try
                {
                    var periods = GetPeriods(lProduct, amountLcy, years, currencyCode, willChangeBank, bankId);
                    if (periods.Any())
                    {
                        periods.FirstOrDefault().StartDate = DateTime.Now;
                        periods.LastOrDefault().Years = years - periods.Where(p => p != periods.LastOrDefault()).Sum(p => p.Years);
                        periods = RefreshPeriods(periods);

                        var calculation = CalculateLoanProduct(lProduct, amount, periods, years, currencyCode);
                        result.Add(calculation);
                    }
                }
                catch (Exception e)
                {
                    Log4Net.Log.Error(e.Message);
                    Log4Net.Log.Error(e.StackTrace);
                }
            }

            return result;
        }

        public List<AmortizationLineItem> CalculateLoanAmortPlan(int loanId, decimal amount, int years, string currencyCode, bool willChangeBank, int? bankId)
        {
            var loanProduct = _context.LoanProducts.Include(l => l.InterestPeriods)
                .ThenInclude(i => i.Currency).FirstOrDefault(l => l.Id == loanId);

            var periods = GetPeriods(loanProduct, amount, years, currencyCode, willChangeBank, bankId);

            if (periods.Any())
            {
                periods.FirstOrDefault().StartDate = DateTime.Now;
                periods.LastOrDefault().Years = years - periods.Where(p => p != periods.LastOrDefault()).Sum(p => p.Years);
                periods = RefreshPeriods(periods);
            }

            LoanCalculate loanCalculate = new LoanCalculate(DateTime.Now);

            //TODO: you are setting object state here. What for?
            loanCalculate.LoanAmount = amount;
            loanCalculate.NumberOfInstallments = years * 12;
            loanCalculate.LoanDate = DateTime.Now;
            loanCalculate.InterestPercentage = periods.Any() ? periods.FirstOrDefault().InterestPercentage : decimal.Zero;
            loanCalculate.CalculateLoan(periods, _settings.MaxAllowedInterestPercentage);

            return loanCalculate.AmortizationItems;
        }

        private LoanTotals CalculateLoanProduct(LoanProduct loan, decimal amount, List<Core.InterestPeriod> periods, int years, string currency)
        {
            LoanCalculate loanCalculate = new LoanCalculate(DateTime.Now);

            //TODO: you are setting object state here. What for?
            loanCalculate.LoanAmount = amount;
            loanCalculate.NumberOfInstallments = years * 12;
            loanCalculate.LoanDate = DateTime.Now;
            loanCalculate.InterestPercentage = periods.FirstOrDefault().InterestPercentage;

            loanCalculate.CalculateLoan(periods, _settings.MaxAllowedInterestPercentage);

            //calculate the expennses
            decimal totalBaseAndInterest = Math.Round(loanCalculate.AmortizationItems.Sum(a => a.InstallmentAmount), 0);
            decimal totalInterest = Math.Round(loanCalculate.AmortizationItems.Sum(a => a.InstallmentInterestAmount), 0);

            //string interestPercentageInfo = GetInterestPercentageInfo(periods);
            string installmentInfo = GetInstallmentInfo(loanCalculate.AmortizationItems.Select(a => a.InstallmentAmount).Distinct().ToList(), periods, "EUR");

            var expenses = _expensesService.CalculateExpenses(loan, amount, years, currency);

            return _loanPublicDetailsDtoFactory.CreateItem(loan, installmentInfo, currency, totalInterest, totalBaseAndInterest, amount, expenses);
        }

        private string GetInstallmentInfo(List<decimal> amounts, List<InterestPeriod> periods, string currencyCode)
        {
            string result = string.Empty;
            if (!amounts.Any()) return result;
            foreach (var period in periods)
            {
                int index = periods.IndexOf(period);
                if (period == periods.FirstOrDefault())
                {
                    if(period.Years == 1)
                    {
                        result += $"{period.InterestPercentage}% или <b>{amounts.ElementAt(index).ToString("N0")}</b> {currencyCode} првата година. <br />";
                    }
                    else
                    {
                        result += $"{period.InterestPercentage}% или <b>{amounts.ElementAt(index).ToString("N0")}</b> {currencyCode} првите {period.Years} години. <br />";
                    }
                }
                else
                {
                    // TO DO: make a proper fix
                    string amount = "";
                    if (index >= 2 && amounts.Count <= 2) {
                   
                        amount = amounts.ElementAt(1).ToString("N0");
                    }
                    else
                    {
                        amount = amounts.ElementAt(index).ToString("N0");
                    }
                    result += $"{period.InterestPercentage}% или <b>{amount}</b> {currencyCode} наредни {period.Years} години. <br />";
                }
            }
            return result;
        }

        private List<InterestPeriod> RefreshPeriods(List<InterestPeriod> interestPeriods)
        {
            List<InterestPeriod> result = new List<InterestPeriod>();

            int periodRestInstallments = interestPeriods.Sum(a => a.NumberOfInstallments);
            InterestPeriod interestPeriod = interestPeriods.FirstOrDefault();
            interestPeriod.StartDate = DateTime.Now;
            interestPeriod.PeriodRestInstallments = periodRestInstallments;
            result.Add(interestPeriod);
            foreach (InterestPeriod current in interestPeriods.Skip(1))
            {
                current.StartDate = interestPeriod.EndDate;
                current.PeriodRestInstallments = interestPeriod.PeriodRestInstallments - interestPeriod.NumberOfInstallments;
                interestPeriod = current;
                result.Add(current);
            }

            return result;
        }

        private List<InterestPeriod> GetPeriods(LoanProduct lProduct, decimal amount, int years, string currencyCode, bool willChangeBank, int? bankId)
        {
            List<InterestPeriod> result = new List<InterestPeriod>();

            var eligiblePeriods =  lProduct.InterestPeriods
                        .Where(ip => 
                            (ip.IsBankClient == willChangeBank || (ip.LoanProduct.BankId == bankId && bankId != null))
                            && ((ip.LoanAmountFrom == null || (ip.LoanAmountFrom * ip.Currency.ExchangeRate <= amount)) 
                            && amount <= ip.LoanAmountTo * ip.Currency.ExchangeRate)
                            && ((ip.DurationFrom == null || ip.DurationFrom <= years * 12) && years * 12 <= ip.DurationTo))
                        .OrderBy(ip => ip.OrderNo)
                        .Select(p => new InterestPeriod()
                        {
                            InterestPercentage = ResolvePeriodInterestPercentage(p),
                            Years = (int)Decimal.Ceiling((decimal)p.Duration / 12)
                        }).ToList();

            foreach(var period in eligiblePeriods)
            {
                if(years > 0)
                {
                    result.Add(period);
                    if(period.Years == 0)
                    {
                        years = 0;
                    }
                    years -= period.Years;
                }
            }

            return result;
        }

        private decimal ResolvePeriodInterestPercentage(Domain.InterestPeriod period)
        {
            var percentage = period.InterestPercentage + (period.ReferenceInterest != null ? period.ReferenceInterest.Rate : 0);

            if(period.Maximum != 0 && percentage > period.Maximum)
            {
                percentage = period.Maximum;
            }
            else if(period.Minimum != 0 && percentage < period.Minimum)
            {
                percentage = period.Minimum;
            }

            if(percentage > _settings.MaxAllowedInterestPercentage)
            {
                percentage = _settings.MaxAllowedInterestPercentage;
            }

            return percentage;
        }

    }
}
