using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Domain.Entites
{
    public class AprobadoQuiero
    {
        public int Id { get; private set; } // CODIGOAPROBADOQUIERO

        public int CodigoAprobado { get; private set; }
        public int CodigoCliente { get; private set; }

        public int Horario { get; private set; }
        public string? Ruta { get; private set; }
        public DateTime FechaRegistro { get; private set; }
        public string? UTM { get; private set; }

        private AprobadoQuiero() { } // EF

        public static AprobadoQuiero Crear(
            int codigoAprobado,
            int codigoCliente,
            int horario,
            string? ruta,
            string? utm)
        {
            return new AprobadoQuiero
            {
                CodigoAprobado = codigoAprobado,
                CodigoCliente = codigoCliente,
                Horario = horario,
                Ruta = ruta,
                UTM = utm,
                FechaRegistro = DateTime.Now
            };
        }


        public void Actualizar(int horario, string? ruta)
        {
            if (horario != 0)
                Horario = horario;

            if (!string.IsNullOrWhiteSpace(ruta))
                Ruta = ruta;
        }
    }
}
