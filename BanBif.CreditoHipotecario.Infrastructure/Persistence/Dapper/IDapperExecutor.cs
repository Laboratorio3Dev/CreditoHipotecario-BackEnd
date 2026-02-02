using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Infrastructure.Persistence.Dapper
{
    public interface IDapperExecutor
    {
        Task<T> ExecuteScalarAsync<T>(
            string sp,
            object param);

        Task<IEnumerable<T>> QueryAsync<T>(
            string sp,
            object param);
    }

}
