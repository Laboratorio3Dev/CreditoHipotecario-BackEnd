using BanBif.CreditoHipotecario.Application.Interfaces;
using BanBif.CreditoHipotecario.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Infrastructure.Persistence.Repository
{
    internal class TipoCambioRepository : ITipoCambioRepository
    {
        private readonly PanelContext _context;

        public TipoCambioRepository(PanelContext context)
        {
            _context = context;
        }

        public decimal ObtenerTipoCambioActual()
        {
            return _context.TipoCambio
                .Where(x => x.CodigoTipoCambio == 1)
                .Select(x => x.Tipocambio.Value)
                .First();
        }
    }
}
