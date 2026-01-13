using BanBif.CreditoHipotecario.Application.Common.Responses;
using BanBif.CreditoHipotecario.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Commands.Credito.ObtenerAprobado
{
    public class ObtenerAprobadoQueryHandler
     : IRequestHandler<ObtenerAprobadoQuery, ApiResponse<AprobadoResultDto>>
    {
        private readonly IAprobadoRepository _aprobadoRepo;

        public ObtenerAprobadoQueryHandler(
            IAprobadoRepository aprobadoRepo)
        {
            _aprobadoRepo = aprobadoRepo;
        }

        public async Task<ApiResponse<AprobadoResultDto>> Handle(
            ObtenerAprobadoQuery query,
            CancellationToken cancellationToken)
        {
            var aprobados = await _aprobadoRepo.ObtenerAsync(
                query.CodigoCliente,
                query.CodigoSimulacion,
                cancellationToken);

            var lista = aprobados.Select(x => new CreditoAprobadoDto
            {
                codigoaprobado = x.Id,
                anios = x.Anios ?? 0,
                cuota = x.Cuota ?? 0,
                ingresos = x.Ingresos ?? 0,
                montoaprobado = x.MontoAprobado ?? 0,
                tea = (x.Tea ?? 0) * 100
            }).ToList();

            return ApiResponse<AprobadoResultDto>.Success(
                new AprobadoResultDto
                {
                    Aprobado = lista
                });
        }
    }
}