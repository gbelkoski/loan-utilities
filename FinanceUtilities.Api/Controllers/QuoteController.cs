using FinanceUtilities.Api.Models;
using FinanceUtilities.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceUtilities.Api.Controllers
{
    [ApiController]
    [Route("api")]
    [AllowAnonymous]
    public class QuoteController : ControllerBase
    {
        private IQuoteRequestService _quoteRequestService;

        public QuoteController(IQuoteRequestService quoteRequestService)
        {
            _quoteRequestService = quoteRequestService;
        }

        [Route("askquote")]
        [HttpPost]
        public virtual ActionResult AskQuote([FromBody] LoanQuoteRequest quoteRequest)
        {
            if (string.IsNullOrEmpty(quoteRequest.Name))
            {
                return BadRequest("Параметарот 'име' е празен.");
            }
            if (string.IsNullOrEmpty(quoteRequest.Email) && string.IsNullOrEmpty(quoteRequest.Phone))
            {
                return BadRequest("Мора да биде внесено барем  едно од полињата 'емаил' или 'телефон'.");
            }
            if(_quoteRequestService.IsSpam(quoteRequest.Email, quoteRequest.Phone, quoteRequest.LoanId))
            {
                return BadRequest("Веќе имате побарано понуда за овој производ. Барањето на понуда за ист производ е огрничено на 30 дена.");
            }
            //loanid must be valid > 0
            //make sure they are not undefined
            bool success = _quoteRequestService.SendLoanQuoteRequest(quoteRequest.Name, quoteRequest.Email, quoteRequest.Phone, quoteRequest.City, quoteRequest.Content, quoteRequest.LoanId, quoteRequest.LoanAmount, quoteRequest.Duration);

            return Ok();
        }
    }
}
