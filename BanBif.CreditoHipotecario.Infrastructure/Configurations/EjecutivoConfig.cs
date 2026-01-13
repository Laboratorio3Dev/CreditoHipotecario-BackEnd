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
    public class EjecutivoConfig : IEntityTypeConfiguration<Ejecutivo>
    {
        public void Configure(EntityTypeBuilder<Ejecutivo> builder)
        {
            builder.ToTable("CREDITO_HIPOTECARIO_HORARIO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("CODIGOHORARIO"); // ajusta si el PK se llama distinto

            builder.Property(x => x.Dia)
                .HasColumnName("DIA");

            builder.Property(x => x.HoraInicio)
                .HasColumnName("HORA_INICIO");

            builder.Property(x => x.HoraFin)
                .HasColumnName("HORA_FIN");

            builder.Property(x => x.Codigo)
                .HasColumnName("EJECUTIVO");

            builder.Property(x => x.Contador)
                .HasColumnName("CONTADOR");
        }
    }
}
