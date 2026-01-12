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
    public class TipoCambioConfig : IEntityTypeConfiguration<TipoCambio>
    {
        public void Configure(EntityTypeBuilder<TipoCambio> builder)
        {
            builder.ToTable("CREDITO_HIPOTECARIO_TIPO_CAMBIO");

            builder.HasKey(x => x.CodigoTipoCambio);

            builder.Property(x => x.CodigoTipoCambio)
                .HasColumnName("CODIGOTIPOCAMBIO");

            builder.Property(x => x.Tipocambio)
                .HasColumnName("TIPOCAMBIO");
        }
    }

}
