using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Domain.Entites
{
    public class Ejecutivo
    {
        public int Id { get; private set; }

        public DateTime Dia { get; private set; }

        public int HoraInicio { get; private set; }
        public int HoraFin { get; private set; }

        public string Codigo { get; private set; } = default!;
        public int Contador { get; private set; }

        private Ejecutivo() { } // EF

        public void IncrementarContador()
        {
            Contador++;
        }
    }
}