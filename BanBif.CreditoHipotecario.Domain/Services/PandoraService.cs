using BanBif.CreditoHipotecario.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Domain.Services
{
    public class PandoraService
    {
        public PandoraRegistro CrearRegistro(
            AprobadoQuiero quiero,
            CreditoCliente cliente,
            Aprobado aprobado,
            Simulacion simulacion,
            Ejecutivo? ejecutivo)
        {
            return new PandoraRegistro
            {
                CodigoAprobadoQuiero = quiero.Id,
                FechaRegistro = quiero.FechaRegistro,
                FechaAsignado = quiero.FechaRegistro,
                Documento = cliente.Documento,
                Celular = cliente.Celular,
                Correo = cliente.Correo,
                NombreCliente = cliente.Nombre,
                TeaAprobada = aprobado.Tea,
                MonedaAprobado = "SOL",
                MontoAprobado = cliente.Monto,
                MonedaSolicitado = simulacion.Moneda == 1 ? "SOL" : "USD",
                MontoSolicitado = aprobado.MontoAprobado,
                Plazo = aprobado.Anios,
                Imagen = quiero.Ruta,
                Status = 0,
                Ingresos = simulacion.IngresoMensual,
                Horario = quiero.Horario,
                TipoIngreso = simulacion.TipoIngreso,
                CompartirCuota = simulacion.CompartirCuota==true ? 1 : 0,
                InmuebleComprar = simulacion.InmuebleComprar == true ? 1 : 0,
                TipoRegistro = 1,
                UsuarioAsignado = ejecutivo?.Codigo ?? "DQUISPE",
                FlagCliente = cliente.EsCliente ? 1 : 0,
                Flujo = cliente.Flujo,
                Ingreso = cliente.TipoIngreso
            };
        }
    }

}
