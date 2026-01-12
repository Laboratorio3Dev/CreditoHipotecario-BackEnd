using BanBif.CreditoHipotecario.Application.Commands.Credito.Login;
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
    }
}
