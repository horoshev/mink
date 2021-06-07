using Microsoft.AspNetCore.Mvc;
using Mink.Services.Contracts.Interfaces;

namespace Mink.Api.Controllers
{
    [Route("r")]
    [ApiController]
    public class RedirectController : ControllerBase
    {
        private readonly IUriService _uriService;

        public RedirectController(IUriService uriService)
        {
            _uriService = uriService;
        }

        [HttpGet("{key}")]
        public IActionResult Resolve(string key)
        {
            var resolve = _uriService.ResolveKey(key);
            if (resolve.IsSuccess)
            {
                return Redirect(resolve.Result);
            }

            return BadRequest(resolve.Message);
        }
    }
}