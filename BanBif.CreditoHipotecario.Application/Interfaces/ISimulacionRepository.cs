using BanBif.CreditoHipotecario.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Interfaces
{
    public interface ISimulacionRepository
    {
        void Agregar(Simulacion simulacion);
        Task<Simulacion?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken);
        Task GuardarAsync(CancellationToken cancellationToken);
    }
}
