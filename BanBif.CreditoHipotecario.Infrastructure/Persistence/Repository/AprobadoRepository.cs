using BanBif.CreditoHipotecario.Application.Interfaces;
using BanBif.CreditoHipotecario.Domain.Entites;
using BanBif.CreditoHipotecario.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace BanBif.CreditoHipotecario.Infrastructure.Persistence.Repository
{
    public class AprobadoRepository : IAprobadoRepository
    {
        private readonly PanelContext _context;

        public AprobadoRepository(PanelContext context)
        {
            _context = context;
        }

        public void Agregar(Aprobado aprobado)
        {
            _context.Set<Aprobado>().Add(aprobado);
        }

        public async Task GuardarAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Aprobado>> ObtenerAsync(int codigoCliente, int codigoSimulacion, CancellationToken cancellationToken)
        {
            return await _context.Set<Aprobado>()
                .AsNoTracking()
                .Where(x =>
                    x.CodigoCliente == codigoCliente &&
                    x.CodigoSimulacion == codigoSimulacion)
                .ToListAsync(cancellationToken);
        }

        public async Task<Aprobado> ObtenerIdAsync(int codigoAprobado, CancellationToken cancellationToken)
        {
            return await _context.Set<Aprobado>()
                .AsNoTracking()
                .Where(x =>
                    x.Id == codigoAprobado
                  )
                .FirstOrDefaultAsync(cancellationToken);
        }

    }
}