using BanBif.CreditoHipotecario.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Commands.Credito.Simular
{
    public class SimularCommand
     : IRequest<ApiResponse<SimularResultDto>>
    {
        public int CodigoCliente { get; set; }
        public bool CompartirCuota { get; set; }
        public int DineroNecesita { get; set; }
        public int IngresoMensual { get; set; }
        public bool InmuebleComprar { get; set; }
        public int Moneda { get; set; }
        public int TipoIngreso { get; set; }
        public int ValorInmueble { get; set; }
        public bool FlagDatos { get; set; }
        public bool FlagTerminos { get; set; }
    }
}
