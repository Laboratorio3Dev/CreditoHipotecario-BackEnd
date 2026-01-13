using BanBif.CreditoHipotecario.Domain.Entites;
using Microsoft.EntityFrameworkCore;



namespace BanBif.CreditoHipotecario.Infrastructure.Persistence.Context
{
    public class PanelContext : DbContext
    {
        public PanelContext(DbContextOptions<PanelContext> options)
        : base(options) { }

        public DbSet<CreditoCliente> Clientes { get; set; }
        public DbSet<TipoCambio> TipoCambio { get; set; }
        public DbSet<Simulacion> Simulacion { get; set; }
        public DbSet<Tasa> Tasa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
         typeof(PanelContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
