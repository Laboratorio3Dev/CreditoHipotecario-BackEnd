using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Domain.Entites
{
    public class Aprobado
    {
        public int Id { get; set; }

        public int? CodigoCliente { get; set; }
        public int? CodigoSimulacion { get; set; }

        public int? Anios { get; set; }
        public decimal? Cuota { get; set; }
        public decimal? Ingresos { get; set; }
        public int? MontoAprobado { get; set; }
        public decimal? Tea { get; set; }

        public static Aprobado Crear(
            int codigoCliente,
            int codigoSimulacion,
            int? anios,
            decimal cuota,
            decimal ingresos,
            int montoAprobado,
            decimal? tea)
        {
            return new Aprobado
            {
                CodigoCliente = codigoCliente,
                CodigoSimulacion = codigoSimulacion,
                Anios = anios,
                Cuota = cuota,
                Ingresos = ingresos,
                MontoAprobado = montoAprobado,
                Tea = tea
            };
        }
    }
}
