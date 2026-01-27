using BanBif.CreditoHipotecario.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Commands.Credito.ObtenerConfiguracion
{
    public class ObtenerConfiguracionQuery
     : IRequest<ApiResponse<List<ConfiguracionResultDto>>>
    {
    }
}