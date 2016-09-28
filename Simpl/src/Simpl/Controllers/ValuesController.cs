using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simpl.Core.Services;
using Microsoft.AspNetCore.Authorization;

namespace Simpl.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IUserService _userService;

        public ValuesController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("authorizewithoutrole")]
        [Authorize()]
        public async Task<IActionResult> Authorize()
        {
            return await Task.FromResult(new ObjectResult("Athorized without role"));
        }

        [Authorize(Roles = "admin")]
        [HttpGet("authorize")]
        public async Task<IActionResult> AuthorizeWithValidRole()
        {
            return await Task.FromResult(new ObjectResult("Athorized with valid role"));
        }

        [Authorize(Roles = "employee")]
        [HttpGet("authorizewithinvalidrole")]
        public async Task<IActionResult> AuthorizeWithInValidRole()
        {
            return await Task.FromResult(new ObjectResult("Athorized with invalid role"));
        }


        public async Task<IActionResult> UnAuthorize()
        {
            return await Task.FromResult(new ObjectResult("in-require authorize"));
        }
    }
}
