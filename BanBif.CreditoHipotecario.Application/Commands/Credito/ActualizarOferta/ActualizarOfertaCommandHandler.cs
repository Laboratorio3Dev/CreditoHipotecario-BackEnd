using BanBif.CreditoHipotecario.Application.Common.Responses;
using BanBif.CreditoHipotecario.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Commands.Credito.ActualizarOferta
{
    public class ActualizarOfertaCommandHandler
    : IRequestHandler<ActualizarOfertaCommand, ApiResponse<ActualizarOfertaResultDto>>
    {
        private readonly IAprobadoQuieroRepository _quieroRepo;

        public ActualizarOfertaCommandHandler(
            IAprobadoQuieroRepository quieroRepo)
        {
            _quieroRepo = quieroRepo;
        }

        public async Task<ApiResponse<ActualizarOfertaResultDto>> Handle(
            ActualizarOfertaCommand cmd,
            CancellationToken cancellationToken)
        {
            var quiero = await _quieroRepo.ObtenerAsync(
                cmd.CodigoQuiero,
                cancellationToken);

            if (quiero == null)
                throw new Exception("Oferta no encontrada");

            quiero.Actualizar(cmd.Horario, cmd.Ruta);

            await _quieroRepo.GuardarAsync(cancellationToken);

            return ApiResponse<ActualizarOfertaResultDto>.Success(
                new ActualizarOfertaResultDto
                {
                    codigoaprobadoquiero = quiero.Id
                });
        }
    }
}
