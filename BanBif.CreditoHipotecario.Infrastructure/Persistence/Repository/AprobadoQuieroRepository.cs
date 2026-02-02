using BanBif.CreditoHipotecario.Application.Interfaces;
using BanBif.CreditoHipotecario.Domain.Entites;
using BanBif.CreditoHipotecario.Infrastructure.Persistence.Context;
using BanBif.CreditoHipotecario.Infrastructure.Persistence.Dapper;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Infrastructure.Persistence.Repository
{
    public class AprobadoQuieroRepository : IAprobadoQuieroRepository
    {
        private readonly PanelContext _context;
        private readonly IDapperExecutor _dapper;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        public AprobadoQuieroRepository(PanelContext context, IDapperExecutor dapper, IConfiguration config)
        {
            _context = context;
            _dapper = dapper;
            _connectionString = config.GetConnectionString("Conexion");
        }

        public void Agregar(AprobadoQuiero entity)
        {
            _context.Set<AprobadoQuiero>().Add(entity);
        }

        public async Task<AprobadoQuiero?> ObtenerAsync(
            int codigoQuiero,CancellationToken cancellationToken)
        {
            return await _context.Set<AprobadoQuiero>()
                .FirstOrDefaultAsync(
                    x => x.Id == codigoQuiero,
                    cancellationToken);
        }
        public async Task GuardarAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<string> EjecutarAsignacionEjecutivoAsync(
    int codigoCliente,
    string codigoLog
   )
        {
            try
            {
                await using var connection = new SqlConnection(_connectionString);

                return await connection.ExecuteScalarAsync<string>(
                    "SP_BIFTECARIO_ASIGNACION_EJECUTIVO",
                    new
                    {
                        CODIGOCLIENTE = codigoCliente,
                        CODIGOLOG = codigoLog
                    },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }


    }
}
