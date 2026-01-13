using BanBif.CreditoHipotecario.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Commands.Credito.ObtenerAprobado
{
    public class ObtenerAprobadoQuery
     : IRequest<ApiResponse<AprobadoResultDto>>
    {
        public int CodigoCliente { get; set; }
        public int CodigoSimulacion { get; set; }
    }
}
