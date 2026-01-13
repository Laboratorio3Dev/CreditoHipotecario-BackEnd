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
    public class TasaConfig
         : IEntityTypeConfiguration<Tasa>
    {
        public void Configure(EntityTypeBuilder<Tasa> builder)
        {
            // =========================
            // TABLE
            // =========================
            builder.ToTable("CREDITO_HIPOTECARIO_TASA");

            // =========================
            // PRIMARY KEY
            // =========================
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("CODIGOTASA")
                .ValueGeneratedOnAdd();

            // =========================
            // COLUMNS
            // =========================
            builder.Property(x => x.Plazo)
                .HasColumnName("PLAZO")
                .IsRequired(false);

            builder.Property(x => x.Valor)
                .HasColumnName("TASA")
                .HasPrecision(10, 6)
                .IsRequired(false);
        }
    }
}
