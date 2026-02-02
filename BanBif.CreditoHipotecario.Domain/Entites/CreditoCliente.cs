using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Domain.Entites
{
    public class CreditoCliente
    {
        public int Id { get; private set; }
        public string? Documento { get; set; }
        public string? Celular { get; set; }
        public string? Correo { get; set; }

        public bool? Estado { get; set; }

        public string? Nombre { get; set; } 
        public string? Flujo { get; set; }

        public decimal? Monto { get; set; }
        public bool EsCliente { get; set; }

        public decimal? Tasa { get; set; }
        public int? TipoIngreso { get; set; }

        public string? UrlOrigen { get; set; }
        public string? EstadoCivil { get; set; }

        public bool? FlagTerminos { get; set; }
        public bool? DatosPrincipalesCompletos { get; set; }
        public bool? DatosSecundariosCompletos { get; set; }

        public string? Score { get; set; }

        
       // public string? CodigoLog { get; set; }
        public static CreditoCliente Crear(
       string documento,
       string celular,
       string correo,
       int? tipoIngreso,
       string estadocivil
   
            )
        {
            return new CreditoCliente
            {
                Documento = documento,
                Celular = celular,
                Correo = correo,
                TipoIngreso = tipoIngreso,
                EsCliente = false,
                EstadoCivil = estadocivil,
                //CodigoLog=codigoLog
            };
        }

        public void ActualizarContacto(string celular, string correo, int? tipoIngreso ,string estadocivil
       )
        {
            Celular = celular;
            Correo = correo;
            TipoIngreso = tipoIngreso;
            EstadoCivil = estadocivil;
           
        }
    }
}
