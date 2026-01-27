using BanBif.CreditoHipotecario.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Commands.Credito.ActualizarOferta
{
    public class ActualizarOfertaCommand
    : IRequest<ApiResponse<ActualizarOfertaResultDto>>
    {
        public int CodigoQuiero { get; set; }
        public int Horario { get; set; }
        public string? Ruta { get; set; }
    }
}
