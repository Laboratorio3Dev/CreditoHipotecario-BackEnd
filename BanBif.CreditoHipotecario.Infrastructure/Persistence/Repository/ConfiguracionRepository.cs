using BanBif.CreditoHipotecario.Application.Interfaces;
using BanBif.CreditoHipotecario.Domain.Entites;
using BanBif.CreditoHipotecario.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Infrastructure.Persistence.Repository
{
    public class ConfiguracionRepository : IConfiguracionRepository
    {
        private readonly PanelContext _context;

        public ConfiguracionRepository(PanelContext context)
        {
            _context = context;
        }

        public async Task<List<ConfiguracionSimulador>> ObtenerTodasAsync(
            CancellationToken cancellationToken)
        {
            return await _context.Set<ConfiguracionSimulador>()
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
