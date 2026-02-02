using BanBif.CreditoHipotecario.Infrastructure.Persistence.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Infrastructure.Persistence.Dapper
{
    public class DapperExecutor: IDapperExecutor
    {
        private readonly PanelContext _context;

        public DapperExecutor(PanelContext context)
        {
            _context = context;
        }

        public async Task<T> ExecuteScalarAsync<T>(
            string sp,
            object param
            )
        {
            var connection = _context.Database.GetDbConnection();

            return await connection.ExecuteScalarAsync<T>(
                sp,
                param,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(
            string sp,
            object param)
        {
            var connection = _context.Database.GetDbConnection();

            return await connection.QueryAsync<T>(
                sp,
                param,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
