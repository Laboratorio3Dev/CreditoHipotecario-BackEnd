using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Domain.Entites
{
    public class ConfiguracionSimulador
    {
        public int Id { get; private set; }          
        public string Nombre { get; private set; } = default!;
        public int? Maximo { get; private set; }
        public int? Salto { get; private set; }

        private ConfiguracionSimulador() { } 
    }
}
