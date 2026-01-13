using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Commands.Credito.ObtenerAprobado
{
    public class AprobadoResultDto
    {
        public List<CreditoAprobadoDto> Aprobado { get; set; } = new();
    }
}
