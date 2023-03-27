using FinanceUtilities.Core;
using FinanceUtilities.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Abv.Web.Presentation.Controllers
{
    [ApiController]
    [Route("api")]
    public partial class LoginController : ControllerBase
    {
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]User userParam)
        {
            var user = await _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return Unauthorized();

            return Ok(user);
        }
    }
}
