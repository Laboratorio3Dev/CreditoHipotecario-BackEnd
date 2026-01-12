using BanBif.CreditoHipotecario.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Commands.Credito.Login
{
    public class LoginCommand : IRequest<ApiResponse<LoginResultDto>>
    {
        public string Documento { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public int? TipoIngreso { get; set; }
    }
}
