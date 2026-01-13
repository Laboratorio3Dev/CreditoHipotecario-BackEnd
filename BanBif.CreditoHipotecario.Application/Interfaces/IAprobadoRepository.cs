using BanBif.CreditoHipotecario.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Interfaces
{
    public interface IAprobadoRepository
    {
        void Agregar(Aprobado aprobado);
        Task GuardarAsync(CancellationToken cancellationToken);
        Task<List<Aprobado>> ObtenerAsync(
       int codigoCliente, int codigoSimulacion,
        CancellationToken cancellationToken);
        Task<Aprobado> ObtenerIdAsync(int codigoAprobado, CancellationToken cancellationToken);
    }
}
