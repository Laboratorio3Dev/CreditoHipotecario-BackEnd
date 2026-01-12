using BanBif.CreditoHipotecario.Application.Interfaces;
using BanBif.CreditoHipotecario.Infrastructure.Persistence.Context;
using BanBif.CreditoHipotecario.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<PanelContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("ConexionNPS")));

            // Repositories
            services.AddScoped<ICreditoCommandRepository, CreditoCommandRepository>();
            services.AddScoped<ITipoCambioRepository, TipoCambioRepository>();

            return services;
        }
    }
}
