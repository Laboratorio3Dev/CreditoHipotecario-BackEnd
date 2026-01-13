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
    public class CreditoCommandRepository : ICreditoCommandRepository
    {
        private readonly PanelContext _context;

        public CreditoCommandRepository(PanelContext context)
        {
            _context = context;
        }
        public void Agregar(CreditoCliente cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public async Task GuardarAsync(CancellationToken cancellationToke)
        {
            await _context.SaveChangesAsync(cancellationToke);
        }

        public CreditoCliente  ObtenerPorDocumento(string documento)
        {
            return  _context.Clientes.FirstOrDefault(x => x.Documento == documento);
        }

        public async Task<CreditoCliente?> ObtenerAsync(
           int codigoCliente,
           CancellationToken cancellationToken)
        {
            return await _context.Set<CreditoCliente>()
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    x => x.Id == codigoCliente,
                    cancellationToken);
        }
    }
}
