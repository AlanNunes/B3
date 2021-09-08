using Microsoft.AspNetCore.Mvc;
using Ordens.Application.DTOs;
using Ordens.Application.DTOs.ListaOrdens;
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

        [HttpGet]
        [Route("ListaOrdens")]
        public async Task<IActionResult> ListaOrdens(ListaOrdensRequestDTO listaOrdens)
        {
            var response = await _appService.ListaOrdens(listaOrdens);
            if (response.ValidationResult.IsValid)
                return Ok(response);
            else
                return BadRequest(response.ValidationResult);
        }

        [HttpPost]
        [Route("EnviaOrdem")]
        public async Task<IActionResult> EnviaOrdem(EnviaOrdemRequestDTO ordem)
        {
            var response = await _appService.EnviaOrdem(ordem);
            if (response.ValidationResult.IsValid)
                return Ok(response);
            else
                return BadRequest(response.ValidationResult);
        }

        [HttpPost]
        [Route("CancelaOrdem")]
        public async Task<IActionResult> CancelaOrdem(CancelaOrdemRequestDTO ordem)
        {
            var response = await _appService.CancelaOrdem(ordem);
            if (response.ValidationResult.IsValid)
                return Ok(response);
            else
                return BadRequest(response.ValidationResult);
        }
    }
}
