using BanBif.CreditoHipotecario.Application.Interfaces;
using BanBif.CreditoHipotecario.Domain.Entites;
using BanBif.CreditoHipotecario.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace BanBif.CreditoHipotecario.Infrastructure.Persistence.Repository
{
    public class SimulacionRepository : ISimulacionRepository
    {
        private readonly PanelContext _context;

        public SimulacionRepository(PanelContext context)
        {
            _context = context;
        }

        public void Agregar(Simulacion simulacion)
        {
            _context.Add(simulacion);
        }

        public async Task<Simulacion?> ObtenerPorIdAsync(
        int id,
        CancellationToken cancellationToken)
        {
            return await _context.Set<Simulacion>()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task GuardarAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
