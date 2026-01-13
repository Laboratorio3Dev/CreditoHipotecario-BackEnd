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
    public class SimulacionConfig
        : IEntityTypeConfiguration<Simulacion>
    {
        public void Configure(EntityTypeBuilder<Simulacion> builder)
        {
            builder.ToTable("CREDITO_HIPOTECARIO_SIMULACION");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("CODIGOSIMULACION")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.CodigoCliente)
                .HasColumnName("CODIGOCLIENTE");

            builder.Property(x => x.Moneda)
                .HasColumnName("MONEDA");

            builder.Property(x => x.ValorInmueble)
                .HasColumnName("VALORINMUEBLE");

            builder.Property(x => x.DineroNecesita)
                .HasColumnName("DINERONECESITA");

            builder.Property(x => x.IngresoMensual)
                .HasColumnName("INGRESOMENSUAL");

            builder.Property(x => x.TipoIngreso)
                .HasColumnName("TIPOINGRESO");

            builder.Property(x => x.CompartirCuota)
                .HasColumnName("COMPARTIRCUOTA");

            builder.Property(x => x.InmuebleComprar)
                .HasColumnName("INMUEBLECOMPRAR");

            builder.Property(x => x.FechaRegistro)
                .HasColumnName("FECHAREGISTRO");

            builder.Property(x => x.FlagTerminos)
                .HasColumnName("FLAG_TERMINOS");

            builder.Property(x => x.FlagDatosPersonales)
                .HasColumnName("FLAG_DATOSPERSONALES");

            builder.Property(x => x.CodigoUnicoLog)
                .HasColumnName("CodigoUnicoLog")
                .HasMaxLength(100);

            builder.Property(x => x.PrimeraVivienda)
                .HasColumnName("PRIMERAVIVIENDA");

            builder.Property(x => x.MontoInicial)
                .HasColumnName("MONTOINICIAL");
        }
    }

}
