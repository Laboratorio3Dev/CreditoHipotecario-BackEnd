using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Interfaces
{
    public interface ISimulacionSpRepository
    {
        Task<decimal> CalcularCuotaAsync(
        decimal? tasa,
        decimal valor,
        int? cuotas,
        CancellationToken cancellationToken);
    }
}
