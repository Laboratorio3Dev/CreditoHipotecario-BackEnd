using BanBif.CreditoHipotecario.Application.Common.Responses;
using BanBif.CreditoHipotecario.Application.Interfaces;
using BanBif.CreditoHipotecario.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Commands.Credito.Simular
{
    public class SimularCommandHandler
    : IRequestHandler<SimularCommand, ApiResponse<SimularResultDto>>
    {
        private readonly ISimulacionRepository _simulacionRepo;
        private readonly ITasaRepository _tasaRepo;
        private readonly IAprobadoRepository _aprobadoRepo;
        private readonly ISimulacionSpRepository _spRepo;

        public SimularCommandHandler(
            ISimulacionRepository simulacionRepo,
            ITasaRepository tasaRepo,
            IAprobadoRepository aprobadoRepo,
            ISimulacionSpRepository spRepo)
        {
            _simulacionRepo = simulacionRepo;
            _tasaRepo = tasaRepo;
            _aprobadoRepo = aprobadoRepo;
            _spRepo = spRepo;
        }

        public async Task<ApiResponse<SimularResultDto>> Handle(
            SimularCommand cmd,
            CancellationToken cancellationToken)
        {
        
            var simulacion = Simulacion.Crear(
                cmd.CodigoCliente,
                cmd.CompartirCuota,
                cmd.DineroNecesita,
                cmd.IngresoMensual,
                cmd.InmuebleComprar,
                cmd.Moneda,
                cmd.TipoIngreso,
                cmd.ValorInmueble,
                cmd.FlagDatos,
                cmd.FlagTerminos
            );

            _simulacionRepo.Agregar(simulacion);
            // await _simulacionRepo.GuardarAsync(cancellationToken);

            // 🔴 Guardas para obtener el ID
            await _simulacionRepo.GuardarAsync(cancellationToken);

            // 2️⃣ Obtener tasas
            var tasas = await _tasaRepo.ObtenerTodasAsync(cancellationToken);

            foreach (var tasa in tasas)
            {
                // 3️⃣ Ejecutar SP
                var cuota = await _spRepo.CalcularCuotaAsync(
                    tasa.Valor,
                    cmd.DineroNecesita,
                    tasa.Plazo * 12,
                    cancellationToken);

                var ingresoSugerido = (cuota / 40) * 100;

                var aprobado = Aprobado.Crear(
                    cmd.CodigoCliente,
                    simulacion.Id,
                    tasa.Plazo,
                    cuota,
                    ingresoSugerido,
                    cmd.DineroNecesita,
                    tasa.Valor
                );

                _aprobadoRepo.Agregar(aprobado);
            
            }

         

            return ApiResponse<SimularResultDto>.Success(
                new SimularResultDto
                {
                    CodigoSimulacion = simulacion.Id
                });
        }
    }
}
