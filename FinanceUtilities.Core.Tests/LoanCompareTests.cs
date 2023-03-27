using FinanceUtilities.Core.Mappers;
using FinanceUtilities.Core.Settings;
using FinanceUtilities.Data;
using FinanceUtilities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace FinanceUtilities.Core.Tests
{
    [TestClass]
    public class LoanCompareTests
    {
        IQueryable<LoanProduct> loanWithSingleVariableInterestPeriod = new List<LoanProduct>
            {
                new LoanProduct {
                    Name = "Zelen kredit",
                    BankId = 2,
                    CurrencyCode = "MKD",
                    Currency = new Currency() { Code = "MKD", ExchangeRate = 1, Name = "Denar" },
                    LoanTypeId = "Ecol",
                    ParticipationPercentage = 0,
                    MaximumAmount = 20000,
                    MaxDuration = 60,
                    InterestPeriods = new List<Domain.InterestPeriod>()
                    {
                        new Domain.InterestPeriod() {

                            IRType = IRType.Variable,
                            ReferenceInterestId = "NB01MK",
                            InterestPercentage = 3,
                            OrderNo = 1,
                            IsBankClient = true,
                            CurrencyCode  = "MKD",
                            LoanAmountFrom = 0,
                            LoanAmountTo = 20000,
                            DurationFrom = 0,
                            DurationTo = 60
                        }
                    }
                }
            }.AsQueryable();

        ILoanCompareService subject;
        Mock<ILoanTotalsFactory> mockLoanTotalsFactory;
        Mock<DbSet<LoanProduct>> mockDbSet;
        Mock<IFinanceContext> mockDbContext;
        Mock<ISettings> mockSettings;
        Mock<ICurrencyUtils> mockCurrencyUtils;
        Mock<IExpensesService> mockExpensesService;

        [TestInitialize]
        public void Init()
        {
            mockDbSet = new Mock<DbSet<LoanProduct>>();
            mockDbSet.As<IQueryable<LoanProduct>>().Setup(m => m.Provider).Returns(loanWithSingleVariableInterestPeriod.Provider);
            mockDbSet.As<IQueryable<LoanProduct>>().Setup(m => m.Expression).Returns(loanWithSingleVariableInterestPeriod.Expression);
            mockDbSet.As<IQueryable<LoanProduct>>().Setup(m => m.ElementType).Returns(loanWithSingleVariableInterestPeriod.ElementType);
            mockDbSet.As<IQueryable<LoanProduct>>().Setup(m => m.GetEnumerator()).Returns(loanWithSingleVariableInterestPeriod.GetEnumerator());

            mockDbContext = new Mock<IFinanceContext>();
            mockDbContext.Setup(m => m.LoanProducts).Returns(mockDbSet.Object);

            mockLoanTotalsFactory = new Mock<ILoanTotalsFactory>();

            mockSettings = new Mock<ISettings>();

            mockCurrencyUtils = new Mock<ICurrencyUtils>();

            mockExpensesService = new Mock<IExpensesService>();

            subject = new LoanCompareService(mockDbContext.Object, mockLoanTotalsFactory.Object, mockExpensesService.Object, mockSettings.Object, mockCurrencyUtils.Object);
        }

        [TestMethod]
        public void LoanCalculate_LoanWithSingleVariableInterestPeriod_MatchTotalValue()
        {
            var result = subject.CalculateLoanProductTotals(5, 15000, true, "MKD", "Ecol", null);

            Assert.AreEqual(result.Count(), 1);
            Assert.AreEqual(result.FirstOrDefault().Total, "16,172");
        }
    }
}
