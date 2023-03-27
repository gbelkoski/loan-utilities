using System.Collections.Generic;
using FinanceUtilities.Data;
using System.Linq;
using FinanceUtilities.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Web;
using System.Text.RegularExpressions;
using FinanceUtilities.Domain;

namespace FinanceUtilities.Core
{
    public class LoanService : ServiceBase, ILoanService
    {
        public LoanService(IFinanceContext context) : base(context)
        {
        }

        public List<LoanDto> GetAll()
        {
            return _context.LoanProducts
            .Where(l => !l.IsDeleted)
            .Select(loan => new LoanDto()
            {
                Id = loan.Id,
                Name = loan.Name,
                BankName = loan.Bank.Name,
                LoanType = loan.LoanType.Name,
                HasChanges = loan.HasMarkupChanges
            }).ToList();
        }

        public IEnumerable<LoanDto> Get(int? bankId, string loanTypeId, bool showOnlyMarkupChanges)
        {
            var result =  _context.LoanProducts
                .Where(l => (l.BankId == bankId || bankId == null) && !l.IsDeleted
                            && (l.LoanTypeId == loanTypeId || string.IsNullOrEmpty(loanTypeId)))
                .Select(loan => new LoanDto()
                {
                    Id = loan.Id,
                    Name = loan.Name,
                    BankName = loan.Bank.Name,
                    LoanType = loan.LoanType.Name,
                    NewMarkupDate = loan.NewMarkupDate,
                    HasChanges = string.IsNullOrEmpty(loan.NewMarkup) ? true : loan.HasMarkupChanges
                }).ToList();

            if(showOnlyMarkupChanges)
            {
                result = result.Where(r => r.HasChanges).ToList();
            }

            return result;
        }

        public LoanDetailsDto Get(int id)
        {
            LoanDetailsDto loanDetails = new LoanDetailsDto();
            var loan = _context.LoanProducts.Include(l => l.Bank)
                .Include(l=>l.LoanType)
                .Include(l => l.InterestPeriods)
                .Include(l=>l.LoanProductExpenses)
                .FirstOrDefault(l => l.Id == id);
            if (loan != null)
            {
                loanDetails.Id = loan.Id;
                loanDetails.Name = loan.Name;
                loanDetails.BankId = loan.BankId;
                loanDetails.BankName = loan.Bank.Name;
                loanDetails.LoanTypeId = loan.LoanTypeId;
                loanDetails.LoanType = loan.LoanType.Name;
                loanDetails.Link = loan.Link;
                loanDetails.CurrencyCode = loan.CurrencyCode;
                loanDetails.MinimumAmount = loan.MinimumAmount;
                loanDetails.MaximumAmount = loan.MaximumAmount;
                loanDetails.MinDuration = loan.MinDuration;
                loanDetails.MaxDuration = loan.MaxDuration;
                loanDetails.ParticipationPercentage = loan.ParticipationPercentage;
                loanDetails.InterestPeriods = loan.InterestPeriods.Select(i => MapInterestPeriod(i)).ToList();
                loanDetails.LoanExpenses = loan.LoanProductExpenses.Select(e => MapLoanExpense(e)).ToList();
            }
            return loanDetails;
        }

        public LoanMarkupDto GetMarkup(int id)
        {
            LoanMarkupDto markup = new LoanMarkupDto();
            var loan = _context.LoanProducts.Include(l => l.Bank)
                .Include(l => l.LoanType)
                .Include(l => l.InterestPeriods)
                .Include(l => l.LoanProductExpenses)
                .FirstOrDefault(l => l.Id == id);
            if (loan != null)
            {
                var oldM = loan.Markup ?? "";
                var newM = loan.NewMarkup ?? "";
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(oldM);
                markup.OldMarkup = Regex.Replace(HttpUtility.HtmlDecode(doc.DocumentNode.InnerText), @"\t|\r", "");
                doc.LoadHtml(newM);
                markup.NewMarkup = Regex.Replace(HttpUtility.HtmlDecode(doc.DocumentNode.InnerText), @"\t|\r", "");

                markup.OldMarkup = Regex.Replace(markup.OldMarkup, @"[^\s](\n)+|(\n\s)+", "");
                markup.NewMarkup = Regex.Replace(markup.NewMarkup, @"[^\s](\n)+|(\n\s)+", "");
            }
            return markup;
        }

        public bool Save(LoanDetailsDto entity, out string id)
        {
            var existingLoan = _context.LoanProducts
                .Include(l => l.InterestPeriods)
                .Include(l => l.LoanProductExpenses)
                .FirstOrDefault(l => l.Id == entity.Id);
            if (existingLoan == null)
            {
                existingLoan = new LoanProduct();
                _context.LoanProducts.Add(existingLoan);
            }

            existingLoan.Name = entity.Name;
            existingLoan.BankId = entity.BankId;
            existingLoan.LoanTypeId = entity.LoanTypeId;
            existingLoan.MinDuration = entity.MinDuration;
            existingLoan.MaxDuration = entity.MaxDuration;
            existingLoan.MinimumAmount = entity.MinimumAmount;
            existingLoan.MaximumAmount = entity.MaximumAmount;
            existingLoan.CurrencyCode = entity.CurrencyCode;
            existingLoan.ParticipationPercentage = entity.ParticipationPercentage;
            existingLoan.Link = entity.Link;

            UpdateInterestPeriods(existingLoan, entity.InterestPeriods, _context);
            UpdateLoanExpenses(existingLoan, entity.LoanExpenses, _context);

            _context.SaveChanges();
            id = existingLoan.Id.ToString();
            return true;
        }

        public bool Delete(int id)
        {
            var loan = _context.LoanProducts.FirstOrDefault(e => e.Id == id);
            loan.IsDeleted = true;
            _context.SaveChanges();

            return true;
        }

        private void UpdateInterestPeriods(LoanProduct loan, List<LoanInterestPeriod> interestPeriods, IFinanceContext context)
        {
            var ids = interestPeriods.Where(i => i.Id > 0).Select(i => i.Id).ToList();

            var periodsToDelete = loan.InterestPeriods?.Where(i => !ids.Contains(i.Id)).ToList();

            foreach (var periodModel in interestPeriods)
            {
                Domain.InterestPeriod interestPeriod;
                if (periodModel.Id < 0)
                {
                    interestPeriod = new Domain.InterestPeriod();
                    loan.InterestPeriods.Add(interestPeriod);
                }
                else
                {
                    interestPeriod = loan.InterestPeriods.FirstOrDefault(li => li.Id == periodModel.Id);
                }

                MapInterestPeriod(periodModel, loan.Id, interestPeriod);
            }

            context.InterestPeriods.RemoveRange(periodsToDelete);
        }

        private void UpdateLoanExpenses(LoanProduct loan, List<LoanExpense> loanExpenses, IFinanceContext context)
        {
            var ids = loanExpenses.Where(i => i.Id > 0).Select(i => i.Id).ToList();

            var expensesToDelete = loan.LoanProductExpenses.Where(i => !ids.Contains(i.Id)).ToList();

            foreach (var expenseModel in loanExpenses)
            {
                Domain.LoanProductExpenseType loanExpense;
                if (expenseModel.Id < 0)
                {
                    loanExpense = new Domain.LoanProductExpenseType();
                    loan.LoanProductExpenses.Add(loanExpense);
                }
                else
                {
                    loanExpense = loan.LoanProductExpenses.FirstOrDefault(li => li.Id == expenseModel.Id);
                }

                MapLoanExpense(expenseModel, loan.Id, loanExpense);
            }

            context.LoanProductExpenseTypes.RemoveRange(expensesToDelete);
        }


        private LoanInterestPeriod MapInterestPeriod(Domain.InterestPeriod ip)
        {
            LoanInterestPeriod result = new LoanInterestPeriod();

            result.Id = ip.Id;
            result.Duration = ip.Duration;
            result.InterestPercentage = ip.InterestPercentage;
            result.IRType = ip.IRType;
            result.ReferenceInterestId = ip.ReferenceInterestId;
            result.OrderNo = ip.OrderNo;

            result.IsBankClient = ip.IsBankClient;
            result.CurrencyCode = ip.CurrencyCode;
            result.LoanAmountFrom = ip.LoanAmountFrom;
            result.LoanAmountTo = ip.LoanAmountTo;
            result.Minimum = ip.Minimum;
            result.Maximum = ip.Maximum;
            result.DurationFrom = ip.DurationFrom;
            result.DurationTo = ip.DurationTo;

            return result;
        }

        private void MapInterestPeriod(LoanInterestPeriod source, int loanId, Domain.InterestPeriod target)
        {
            target.LoanProductId = loanId;
            target.Duration = source.Duration;
            target.InterestPercentage = source.InterestPercentage; 
            target.IRType = source.IRType;
            target.ReferenceInterestId = source.ReferenceInterestId;
            target.OrderNo = source.OrderNo;

            target.IsBankClient = source.IsBankClient;
            target.CurrencyCode = source.CurrencyCode;
            target.LoanAmountFrom = source.LoanAmountFrom;
            target.LoanAmountTo = source.LoanAmountTo;
            target.Minimum = source.Minimum;
            target.Maximum = source.Maximum;
            target.DurationFrom = source.DurationFrom;
            target.DurationTo = source.DurationTo;
        }

        private LoanExpense MapLoanExpense(Domain.LoanProductExpenseType expense)
        {
            LoanExpense result = new LoanExpense();

            result.Id = expense.Id;
            result.ExpenseTypeId = expense.ExpenseTypeId;
            result.Percentage = expense.Percentage;
            result.Amount = expense.Amount;
            result.Reccuring = expense.Reccuring;
            result.RecurmentType = expense.RecurmentType;

            result.IsBankClient = expense.IsBankClient;
            result.CurrencyCode = expense.CurrencyCode;
            result.LoanAmountFrom = expense.LoanAmountFrom;
            result.LoanAmountTo = expense.LoanAmountTo;
            result.Minimum = expense.Minimum;
            result.Maximum = expense.Maximum;
            result.DurationFrom = expense.DurationFrom;
            result.DurationTo = expense.DurationTo;

            return result;
        }

        private void MapLoanExpense(LoanExpense source, int loanId, LoanProductExpenseType target)
        {
            target.LoanProductId = loanId;
            target.ExpenseTypeId = source.ExpenseTypeId;
            target.Percentage = source.Percentage;
            target.Amount = source.Amount;
            target.Reccuring = source.Reccuring;
            target.RecurmentType = source.RecurmentType;

            target.IsBankClient = source.IsBankClient;
            target.CurrencyCode = source.CurrencyCode;
            target.LoanAmountFrom = source.LoanAmountFrom;
            target.LoanAmountTo = source.LoanAmountTo;
            target.Minimum = source.Minimum;
            target.Maximum = source.Maximum;
            target.DurationFrom = source.DurationFrom;
            target.DurationTo = source.DurationTo;
        }
    }
}
