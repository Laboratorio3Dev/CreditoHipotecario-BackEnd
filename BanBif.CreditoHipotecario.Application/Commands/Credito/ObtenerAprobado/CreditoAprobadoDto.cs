using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Commands.Credito.ObtenerAprobado
{
    public class CreditoAprobadoDto
    {
        public int codigoaprobado { get; set; }
        public int anios { get; set; }
        public decimal cuota { get; set; }
        public decimal ingresos { get; set; }
        public int montoaprobado { get; set; }
        public decimal tea { get; set; }
    }
}
