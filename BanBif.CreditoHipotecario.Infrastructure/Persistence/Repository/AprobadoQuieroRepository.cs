using BanBif.CreditoHipotecario.Application.Interfaces;
using BanBif.CreditoHipotecario.Domain.Entites;
using BanBif.CreditoHipotecario.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Infrastructure.Persistence.Repository
{
    public class AprobadoQuieroRepository : IAprobadoQuieroRepository
    {
        private readonly PanelContext _context;

        public AprobadoQuieroRepository(PanelContext context)
        {
            _context = context;
        }

        public void Agregar(AprobadoQuiero entity)
        {
            _context.Set<AprobadoQuiero>().Add(entity);
        }

        public async Task GuardarAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
