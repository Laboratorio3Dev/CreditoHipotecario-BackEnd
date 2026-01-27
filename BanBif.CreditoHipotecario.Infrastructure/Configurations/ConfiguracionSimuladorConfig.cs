using BanBif.CreditoHipotecario.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BanBif.CreditoHipotecario.Infrastructure.Configurations
{
  

    public class ConfiguracionSimuladorConfig
    : IEntityTypeConfiguration<ConfiguracionSimulador>
    {
        public void Configure(EntityTypeBuilder<ConfiguracionSimulador> builder)
        {
            builder.ToTable("CREDITO_HIPOTECARIO_SIMULADOR_CONF");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("CODIGOCONFIGURACION");

            builder.Property(x => x.Nombre)
                .HasColumnName("CONFIGURACION");

            builder.Property(x => x.Maximo)
                .HasColumnName("VALORMAXIMO");

            builder.Property(x => x.Salto)
                .HasColumnName("SALTO");
        }
    }
}
