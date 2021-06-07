using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mink.Domain.Models.Dtos;
using Mink.Services.Contracts.Interfaces;

namespace Mink.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UriController : ControllerBase
    {
        private readonly IUriService _uriService;

        public UriController(IUriService uriService)
        {
            _uriService = uriService;
        }

        [HttpPost]
        public async Task<ActionResult> Minify([FromBody] MinifiedUriDto uri)
        {
            var result = await _uriService.CreateMinifiedUri(uri);
            if (result.IsSuccess)
            {
                return Ok(new { data = result.Result });
            }

            return BadRequest(new { error = result.Message });
        }

        [HttpGet]
        public IEnumerable<int> GetUris()
        {
            return Enumerable.Range(1, 5).ToArray();
        }
    }
}