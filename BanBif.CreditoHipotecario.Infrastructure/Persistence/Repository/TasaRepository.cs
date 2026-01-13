using BanBif.CreditoHipotecario.Application.Interfaces;
using BanBif.CreditoHipotecario.Domain.Entites;
using BanBif.CreditoHipotecario.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BanBif.CreditoHipotecario.Infrastructure.Persistence.Repository
{
    public class TasaRepository : ITasaRepository
    {
        private readonly PanelContext _context;

        public TasaRepository(PanelContext context)
        {
            _context = context;
        }

        public async Task<List<Tasa>> ObtenerTodasAsync(
            CancellationToken cancellationToken)
        {
            return await _context.Set<Tasa>()
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
