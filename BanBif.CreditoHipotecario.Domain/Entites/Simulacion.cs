using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Domain.Entites
{
    public class Simulacion
    {
        public int Id { get; set; } // CODIGOSIMULACION

        public int? CodigoCliente { get; set; }
        public int? Moneda { get; set; }
        public int? ValorInmueble { get; set; }
        public int? DineroNecesita { get; set; }
        public int? IngresoMensual { get; set; }
        public int? TipoIngreso { get; set; }

        public bool? CompartirCuota { get; set; }
        public bool? InmuebleComprar { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public bool? FlagTerminos { get; set; }
        public bool? FlagDatosPersonales { get; set; }

        public string? CodigoUnicoLog { get; set; }
        public int? PrimeraVivienda { get; set; }
        public int? MontoInicial { get; set; }

        // Factory (opcional, recomendado)
        public static Simulacion Crear(
            int codigoCliente,
            bool compartirCuota,
            int dineroNecesita,
            int ingresoMensual,
            bool inmuebleComprar,
            int moneda,
            int tipoIngreso,
            int valorInmueble,
            bool flagDatos,
            bool flagTerminos)
        {
            return new Simulacion
            {
                CodigoCliente = codigoCliente,
                CompartirCuota = compartirCuota,
                DineroNecesita = dineroNecesita,
                IngresoMensual = ingresoMensual,
                InmuebleComprar = inmuebleComprar,
                Moneda = moneda,
                TipoIngreso = tipoIngreso,
                ValorInmueble = valorInmueble,
                FlagDatosPersonales = flagDatos,
                FlagTerminos = flagTerminos,
                FechaRegistro = DateTime.Now
            };
        }
    }
}
