using FinanceUtilities.Core;
using FinanceUtilities.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinanceUtilities.Api.Controllers
{
    [Authorize]
    [Route("api")]
    public class LoanController : ControllerBase
    {
        private ILoanService _loanService;
        private ILoanScraperService _loanScraperService;

        public LoanController(ILoanService loanService, ILoanScraperService loanScraperService)
        {
            _loanService = loanService;
            _loanScraperService = loanScraperService;
        }

        [Route("loans")]
        public virtual IEnumerable<LoanDto> GetLoans(int? bankId, string loanTypeId, bool showOnlyMarkupChanges)
        {
            return _loanService.Get(bankId, loanTypeId, showOnlyMarkupChanges);
        }

        [Route("loans/{id}")]
        public virtual LoanDetailsDto GetLoan(int id)
        {
            return _loanService.Get(id);
        }

        [Route("loanmarkup/{id}")]
        public virtual LoanMarkupDto GetLoanMarkup(int id)
        {
            return _loanService.GetMarkup(id);
        }

        [HttpPost]
        [Route("loan")]
        public virtual ObjectResult UpdateLoan([FromBody] LoanDetailsDto loanProduct)
        {
            string id = "";
            _loanService.Save(loanProduct, out id);
            return Ok(id);
        }

        [HttpDelete]
        [Route("loans/{id}")]
        public virtual ActionResult DeleteLoan(string id)
        {
            int loanId = 0;
            int.TryParse(id, out loanId);
            if(loanId <= 0)
            {
                return BadRequest("Id is not valid");
            }

            _loanService.Delete(loanId);

            return Ok();
        }

        [Route("updateloanmarkup")]
        public virtual ActionResult UpdateLoanMarkup(int id)
        {
            bool result = _loanScraperService.UpdateLoanMarkup(id);
            return Ok(result);
        }

        [Route("scrapeloans")]
        public virtual ActionResult SrapeLoans()
        {
            _loanScraperService.ScrapeAllLoanProducts();
            return Ok();
        }

        [Route("markupdated")]
        public virtual ActionResult MarkUpdated(int id)
        {
            _loanScraperService.LoanUpdateDone(id);
            return Ok();
        }
    }
}
