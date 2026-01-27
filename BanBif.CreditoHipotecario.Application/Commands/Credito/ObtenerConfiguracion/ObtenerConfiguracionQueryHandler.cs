using BanBif.CreditoHipotecario.Application.Common.Responses;
using BanBif.CreditoHipotecario.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Commands.Credito.ObtenerConfiguracion
{
    public class ObtenerConfiguracionQueryHandler
     : IRequestHandler<
         ObtenerConfiguracionQuery,
         ApiResponse<List<ConfiguracionResultDto>>>
    {
        private readonly IConfiguracionRepository _repo;

        public ObtenerConfiguracionQueryHandler(
            IConfiguracionRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse<List<ConfiguracionResultDto>>> Handle(
            ObtenerConfiguracionQuery query,
            CancellationToken cancellationToken)
        {
            var configuraciones =
                await _repo.ObtenerTodasAsync(cancellationToken);

            var result = configuraciones.Select(x => new ConfiguracionResultDto
            {
                codigoconfiguracion = x.Id,
                configuracion = x.Nombre,
                maximo = x.Maximo ?? 0,
                salto = x.Salto ?? 0
            }).ToList();

            return ApiResponse<List<ConfiguracionResultDto>>.Success(result);
        }
    }
}
