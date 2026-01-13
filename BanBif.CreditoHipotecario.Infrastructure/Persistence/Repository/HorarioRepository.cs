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
    public class HorarioRepository : IHorarioRepository
    {
        private readonly PanelContext _context;

        public HorarioRepository(PanelContext context)
        {
            _context = context;
        }

        public async Task<Ejecutivo?> ObtenerEjecutivoDisponibleAsync(
            DateTime fechaRegistro,
            CancellationToken cancellationToken)
        {
            var horaMinutos =
                fechaRegistro.Hour * 100 + fechaRegistro.Minute;

            var fecha = fechaRegistro.Date;

            return await _context.Set<Ejecutivo>()
                .Where(x =>
                    x.Dia == fecha &&
                    x.HoraInicio <= horaMinutos &&
                    x.HoraFin >= horaMinutos)
                .OrderBy(x => x.Contador)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
