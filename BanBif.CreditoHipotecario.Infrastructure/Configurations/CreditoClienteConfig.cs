using BanBif.CreditoHipotecario.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace BanBif.CreditoHipotecario.Infrastructure.Configurations
{
    public class CreditoClienteConfig
         : IEntityTypeConfiguration<CreditoCliente>
    {
        public void Configure(EntityTypeBuilder<CreditoCliente> builder)
        {
            builder.ToTable("CREDITO_HIPOTECARIO_CLIENTE");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("CODIGOCLIENTE");

            builder.Property(x => x.Documento)
                 .HasColumnName("DOCUMENTO")
                 .HasMaxLength(20)
                 .IsRequired(false);

            builder.Property(x => x.Celular)
                .HasColumnName("CELULAR")
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(x => x.Correo)
                .HasColumnName("CORREO")
                .HasMaxLength(250)
                .IsRequired(false);

            builder.Property(x => x.Estado)
                .HasColumnName("ESTADO")
                .IsRequired(false);

            builder.Property(x => x.Nombre)
                .HasColumnName("CLIENTE")
                .HasMaxLength(250)
                .IsRequired(false);

            builder.Property(x => x.Flujo)
                .HasColumnName("FLUJO")
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(x => x.Monto)
                .HasColumnName("MONTO")
                .HasPrecision(19, 2)
                .IsRequired(false);

            builder.Property(x => x.EsCliente)
                .HasColumnName("FLAGCLIENTE");
               

            builder.Property(x => x.Tasa)
                .HasColumnName("TASA")
                .HasPrecision(10, 6)
                .IsRequired(false);

            builder.Property(x => x.TipoIngreso)
                .HasColumnName("TIPO_INGRESO")
                .IsRequired(false);

            builder.Property(x => x.UrlOrigen)
                .HasColumnName("URL_ORIGEN")
                .HasMaxLength(300)
                .IsRequired(false);

            builder.Property(x => x.EstadoCivil)
                .HasColumnName("ESTADO_CIVIL")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.FlagTerminos)
                .HasColumnName("FLAG_TERMINOS")
                .IsRequired(false);

            builder.Property(x => x.DatosPrincipalesCompletos)
                .HasColumnName("FLAG_DATOS_PRINCIPALES")
                .IsRequired(false);

            builder.Property(x => x.DatosSecundariosCompletos)
                .HasColumnName("FLAG_DATOS_SECUNDARIOS")
                .IsRequired(false);

            builder.Property(x => x.Score)
                .HasColumnName("SCORE")
                .HasMaxLength(5)
                .IsRequired(false);
        }
    }
}
