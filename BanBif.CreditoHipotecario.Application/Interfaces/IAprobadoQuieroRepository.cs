using BanBif.CreditoHipotecario.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Interfaces
{
    public interface IAprobadoQuieroRepository
    {
        void Agregar(AprobadoQuiero entity);
        Task GuardarAsync(CancellationToken cancellationToken);
        Task<AprobadoQuiero?> ObtenerAsync(int codigoQuiero,CancellationToken cancellationToken);
        Task<string> EjecutarAsignacionEjecutivoAsync(int codigoCliente,string codigoLog);
    }
}
