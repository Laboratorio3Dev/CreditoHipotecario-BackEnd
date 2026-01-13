using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Domain.Entites
{
    public class PandoraRegistro
    {
        public int Id { get; set; } // PK (si existe)

        public int CodigoAprobadoQuiero { get; set; }

        public DateTime FechaRegistro { get; set; }
        public DateTime FechaAsignado { get; set; }

        public string Documento { get; set; } = default!;
        public string Celular { get; set; } = default!;
        public string Correo { get; set; } = default!;
        public string NombreCliente { get; set; } = default!;

        public decimal? TeaAprobada { get; set; }
        public string MonedaAprobado { get; set; } = default!;
        public decimal? MontoAprobado { get; set; }

        public string MonedaSolicitado { get; set; } = default!;
        public decimal? MontoSolicitado { get; set; }
        public int? Plazo { get; set; }

        public string? Imagen { get; set; }
        public int Status { get; set; }

        public decimal? Ingresos { get; set; }
        public int Horario { get; set; }
        public int? TipoIngreso { get; set; }

        public int? CompartirCuota { get; set; }
        public int? InmuebleComprar { get; set; }

        public int? TipoRegistro { get; set; }

        public string? UsuarioAsignado { get; set; }

        public int FlagCliente { get; set; }

        public string? Flujo { get; set; }
        public int? Ingreso { get; set; }
    }
}
