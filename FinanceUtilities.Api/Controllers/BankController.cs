using FinanceUtilities.Core;
using FinanceUtilities.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinanceUtilities.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class BankController : ControllerBase
    {
        private IBankService _banksService;

        public BankController(IBankService bankService)
        {
            _banksService = bankService;
        }

        // GET: api/Banks
        [Route("banks")]
        public IEnumerable<Bank> Get()
        {
            return _banksService.GetAll();
        }

        // GET: api/Banks/5
        public ActionResult Get(int id)
        {
            return Ok(_banksService.Get(id));
        }

        // POST: api/Banks
        [Authorize]
        public bool Post([FromBody]Bank bank)
        {
            return _banksService.Save(bank);
        }

        // DELETE: api/Banks/5
        [Authorize]
        public bool Delete(int id)
        {
            return _banksService.Delete(id);
        }
    }
}
