using FinanceUtilities.Api.Models;
using FinanceUtilities.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceUtilities.Api.Controllers
{
    [ApiController]
    [Route("api")]
    [AllowAnonymous]
    public class ContactController : ControllerBase
    {
        private IEmailService _emailService;

        public ContactController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [Route("sendcontactmail")]
        [HttpPost]
        public virtual ActionResult SendContactMail([FromBody] ContactRequest contactRequest)
        {
            if (string.IsNullOrEmpty(contactRequest.Name))
            {
                return BadRequest("Параметарот 'име' е празен.");

            }
            if (string.IsNullOrEmpty(contactRequest.Email) && string.IsNullOrEmpty(contactRequest.Phone))
            {
                return BadRequest("Мора да биде внесено барем  едно од полињата 'емаил' или 'телефон'.");
            }

            bool success = _emailService.SendContactMail(contactRequest.Name, contactRequest.Email, contactRequest.Phone, contactRequest.Content);

            return Ok();
        }
    }
}