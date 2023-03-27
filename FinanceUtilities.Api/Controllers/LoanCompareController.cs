using FinanceUtilities.Core;
using FinanceUtilities.Core.Model;
using FinanceUtilities.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FinanceUtilities.Api.Controllers
{
    [ApiController]
    [Route("api")]
    [AllowAnonymous]
    public class LoanCompareController : ControllerBase
    {
        private ILoanCompareService _loanCompareService;
        private IEntityService<LoanType, LoanType> _loanTypeService;
        private IEntityService<IdName, ExpenseType> _expenseTypeService;
        private IEntityService<IdName, ReferenceInterest> _referenceInterestService;

        public LoanCompareController(ILoanCompareService loanCompareService,
            IEntityService<LoanType, LoanType> loanTypeService,
            IEntityService<IdName, ExpenseType> expenseTypeService,
            IEntityService<IdName, ReferenceInterest> referenceInterestService)
        {
            _loanCompareService = loanCompareService;
            _loanTypeService = loanTypeService;
            _expenseTypeService = expenseTypeService;
            _referenceInterestService = referenceInterestService;
        }

        [Route("calculatetotal")]
        [HttpGet]
        public virtual ActionResult CalculateTotal(decimal amount, int years, string loanType, string currency)
        {
            if (amount <= 0 || years <= 0)
            {
                return BadRequest("Arguments out of range");
            }

            var result = _loanCompareService.CalculateLoanProductTotals(years, amount, true, currency, loanType, -1).OrderBy(l => l.TotalAmount);

            return Ok(result);
        }

        [Route("amortizationSchedule")]
        [HttpGet]
        public virtual ActionResult CalculateAmortizationSchedule(decimal amount, int years, int loanId, int? bankId, string currency, bool willChangeBank)
        {
            var result = _loanCompareService.CalculateLoanAmortPlan(loanId, amount, years, currency, willChangeBank, bankId);

            return Ok(result);
        }

        [Route("loantypes")]
        public virtual ActionResult GetLoanTypes()
        {
            return Ok(_loanTypeService.GetAll());
        }

        [Route("expensetypes")]
        public virtual ActionResult GetExpenseTypes()
        {
            return Ok(_expenseTypeService.GetAll());
        }

        [Route("referenceinterests")]
        public virtual ActionResult GetReferenceInterestRates()
        {
            return Ok(_referenceInterestService.GetAll());
        }
    }
}
