using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Commands.Credito.Login
{
    public class LoginResultDto
    {
        public int CodigoCliente { get; set; }
        public string Cliente { get; set; }
        public string Flujo { get; set; }
        public decimal? MontoAprobado { get; set; }
        public bool FlagCliente { get; set; }
        public decimal? MontoAprobadoDolares { get; set; }
    }
}
