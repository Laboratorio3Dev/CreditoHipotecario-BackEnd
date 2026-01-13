using BanBif.CreditoHipotecario.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Infrastructure.Configurations
{
    public class PandoraRegistroConfig
     : IEntityTypeConfiguration<PandoraRegistro>
    {
        public void Configure(EntityTypeBuilder<PandoraRegistro> builder)
        {
            builder.ToTable("PANDORA_ADH_registros");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id"); // ajusta si el nombre es otro

            builder.Property(x => x.CodigoAprobadoQuiero)
                .HasColumnName("codigoaprobadoquiero");

            builder.Property(x => x.FechaRegistro)
                .HasColumnName("f_registro");

            builder.Property(x => x.FechaAsignado)
                .HasColumnName("f_asignado");

            builder.Property(x => x.Documento)
                .HasColumnName("documento");

            builder.Property(x => x.Celular)
                .HasColumnName("celular");

            builder.Property(x => x.Correo)
                .HasColumnName("correo");

            builder.Property(x => x.NombreCliente)
                .HasColumnName("nombre_cliente");

            builder.Property(x => x.TeaAprobada)
                .HasColumnName("tea_aprobada");

            builder.Property(x => x.MonedaAprobado)
                .HasColumnName("moneda_aprobado");

            builder.Property(x => x.MontoAprobado)
                .HasColumnName("monto_aprobado");

            builder.Property(x => x.MonedaSolicitado)
                .HasColumnName("moneda_solicitado");

            builder.Property(x => x.MontoSolicitado)
                .HasColumnName("monto_solicitado");

            builder.Property(x => x.Plazo)
                .HasColumnName("plazo");

            builder.Property(x => x.Imagen)
                .HasColumnName("imagen");

            builder.Property(x => x.Status)
                .HasColumnName("status");

            builder.Property(x => x.Ingresos)
                .HasColumnName("ingresos");

            builder.Property(x => x.Horario)
                .HasColumnName("horario");

            builder.Property(x => x.TipoIngreso)
                .HasColumnName("tipo_ingreso");

            builder.Property(x => x.CompartirCuota)
                .HasColumnName("compartir_cuota");

            builder.Property(x => x.InmuebleComprar)
                .HasColumnName("inmueble_comprar");

            builder.Property(x => x.TipoRegistro)
                .HasColumnName("tipo_registro");

            builder.Property(x => x.UsuarioAsignado)
                .HasColumnName("idusuario_asignado");

            builder.Property(x => x.FlagCliente)
                .HasColumnName("flag_cliente");

            builder.Property(x => x.Flujo)
                .HasColumnName("FLUJO");

            builder.Property(x => x.Ingreso)
                .HasColumnName("INGRESO");
        }
    }
}
