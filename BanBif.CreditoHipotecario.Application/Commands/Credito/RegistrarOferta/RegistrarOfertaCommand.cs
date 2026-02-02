using BanBif.CreditoHipotecario.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Commands.Credito.RegistrarOferta
{
    public class RegistrarOfertaCommand
    : IRequest<ApiResponse<RegistrarOfertaResultDto>>
    {
        public int CodigoAprobado { get; set; }
        public int CodigoCliente { get; set; }
        public int Horario { get; set; }
        public string? Ruta { get; set; }
        public string? UTM { get; set; }
        public List<int> codigosaprobados { get; set; }
        public string CodigoLog { get; set; }
    }
}
