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
    public class AprobadoQuieroConfig
     : IEntityTypeConfiguration<AprobadoQuiero>
    {
        public void Configure(EntityTypeBuilder<AprobadoQuiero> builder)
        {
            builder.ToTable("CREDITO_HIPOTECARIO_APROBADO_QUIERO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("CODIGOAPROBADOQUIERO")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.CodigoAprobado)
                .HasColumnName("CODIGOAPROBADO");

            builder.Property(x => x.CodigoCliente)
                .HasColumnName("CODIGOCLIENTE");

            builder.Property(x => x.Horario)
                .HasColumnName("HORARIO");

            builder.Property(x => x.Ruta)
                .HasColumnName("RUTA");

            builder.Property(x => x.FechaRegistro)
                .HasColumnName("FECHAREGISTRO");

            builder.Property(x => x.UTM)
                .HasColumnName("UTM");
        }
    }
}
