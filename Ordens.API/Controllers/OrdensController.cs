using Microsoft.AspNetCore.Mvc;
using Ordens.Application.DTOs;
using Ordens.Application.Interfaces;
using System.Threading.Tasks;

namespace Ordens.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdensController : ControllerBase
    {
        private readonly IOrdemAppService _appService;

        public OrdensController(IOrdemAppService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        public async Task<IActionResult> EnviaOrdem(EnviaOrdemRequestDTO ordem)
        {
            var response = await _appService.EnviaOrdem(ordem);
            return Ok(response);
        }
    }
}
