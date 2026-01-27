using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Commands.Credito.ObtenerConfiguracion
{
    public class ConfiguracionResultDto
    {
        public int codigoconfiguracion { get; set; }
        public string configuracion { get; set; } = default!;
        public int maximo { get; set; }
        public int salto { get; set; }
    }
}
