using BanBif.CreditoHipotecario.Application.Commands.Credito.Login;
using BanBif.CreditoHipotecario.Application.Commands.Credito.ObtenerAprobado;
using BanBif.CreditoHipotecario.Application.Commands.Credito.RegistrarOferta;
using BanBif.CreditoHipotecario.Application.Commands.Credito.Simular;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Banbif.CreditoHipotecario.API.Controllers
{
    [Route("api/credito/[controller]")]
    [ApiController]
    public class CreditoController : ControllerBase
    {
        private readonly ISender _sender;

        public CreditoController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(command));
        }

        [HttpPost("simular")]
        public async Task<IActionResult> Simular(
       [FromBody] SimularCommand command,
       CancellationToken cancellationToken)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpPost("obtener-aprobado")]
        public async Task<IActionResult> ObtenerAprobado(
        [FromBody] ObtenerAprobadoQuery query,
        CancellationToken cancellationToken)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result);
        }


        [HttpPost("registrar-oferta")]
        public async Task<IActionResult> RegistrarOferta(
            [FromBody] RegistrarOfertaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(result);
        }
    }
}
