using BanBif.CreditoHipotecario.Application.Interfaces;
using BanBif.CreditoHipotecario.Infrastructure.Persistence.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace BanBif.CreditoHipotecario.Infrastructure.Persistence.Repository
{
    internal class SimulacionSpRepository: ISimulacionSpRepository
    {
        private readonly PanelContext _context;

        public SimulacionSpRepository(PanelContext context)
        {
            _context = context;
        }

        public async Task<decimal> CalcularCuotaAsync(
     decimal? tasa,
     decimal valor,
     int? cuotas,
     CancellationToken cancellationToken)
        {
            var tasaParam = new SqlParameter("@TASA", tasa ?? (object)DBNull.Value);
            var valorParam = new SqlParameter("@VALOR", valor);
            var cuotasParam = new SqlParameter("@CUOTAS", cuotas ?? (object)DBNull.Value);

            var result = _context.Database
                .SqlQueryRaw<decimal>(
                    "EXEC SP_CREDITO_HIPOTECARIO_SIMULAR_CUOTA @TASA, @VALOR, @CUOTAS",
                    tasaParam, valorParam, cuotasParam)
                .AsEnumerable()
                .First(); 

            return result;
        }
    }
}
