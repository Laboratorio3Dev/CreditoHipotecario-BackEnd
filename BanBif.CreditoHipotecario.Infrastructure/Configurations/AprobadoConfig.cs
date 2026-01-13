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
    public class AprobadoConfig
       : IEntityTypeConfiguration<Aprobado>
    {
        public void Configure(EntityTypeBuilder<Aprobado> builder)
        {
            // =========================
            // TABLE
            // =========================
            builder.ToTable("CREDITO_HIPOTECARIO_APROBADO");

            // =========================
            // PRIMARY KEY
            // =========================
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("CODIGOAPROBADO")
                .ValueGeneratedOnAdd();

            // =========================
            // COLUMNS
            // =========================
            builder.Property(x => x.CodigoCliente)
                .HasColumnName("CODIGOCLIENTE")
                .IsRequired(false);

            builder.Property(x => x.CodigoSimulacion)
                .HasColumnName("CODIGOSIMULACION")
                .IsRequired(false);

            builder.Property(x => x.MontoAprobado)
                .HasColumnName("MONTOAPROBADO")
                .IsRequired(false);

            builder.Property(x => x.Anios)
                .HasColumnName("ANIOS")
                .IsRequired(false);

            builder.Property(x => x.Cuota)
                .HasColumnName("CUOTA")
                .HasPrecision(10, 2)
                .IsRequired(false);

            builder.Property(x => x.Ingresos)
                .HasColumnName("INGRESOS")
                .HasPrecision(10, 2)
                .IsRequired(false);

            builder.Property(x => x.Tea)
                .HasColumnName("TEA")
                .HasPrecision(10, 6)
                .IsRequired(false);
        }
    }
}
