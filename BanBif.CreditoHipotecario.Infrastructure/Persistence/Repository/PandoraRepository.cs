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
    public class PandoraRepository : IPandoraRepository
    {
        private readonly PanelContext _context;

        public PandoraRepository(PanelContext context)
        {
            _context = context;
        }

        public void Agregar(PandoraRegistro entity)
        {
            _context.Set<PandoraRegistro>().Add(entity);
        }
    }
}
