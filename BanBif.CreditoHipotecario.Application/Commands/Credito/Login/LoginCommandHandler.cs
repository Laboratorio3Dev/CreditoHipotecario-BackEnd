using BanBif.CreditoHipotecario.Application.Common.Responses;
using BanBif.CreditoHipotecario.Application.Interfaces;
using BanBif.CreditoHipotecario.Domain.Entites;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Commands.Credito.Login
{
    public class LoginCommandHandler
    : IRequestHandler<LoginCommand, ApiResponse<LoginResultDto>>
    {
        private readonly ICreditoCommandRepository _repo;
        private readonly ITipoCambioRepository _tipoCambioRepo;
        private readonly ILogger<LoginCommandHandler> _logger;
        public LoginCommandHandler(ICreditoCommandRepository repo, ITipoCambioRepository tipoCambioRepo, ILogger<LoginCommandHandler> logger)
        {
            _repo = repo;
            _tipoCambioRepo = tipoCambioRepo;
            _logger = logger;
        }


        public async Task<ApiResponse<LoginResultDto>> Handle(
       LoginCommand cmd,
       CancellationToken cancellationToken)
        {
            _logger.LogInformation("Login intento: {Documento}", cmd.Documento);
            var cliente = _repo.ObtenerPorDocumento(cmd.Documento);

            if (cliente == null)
            {
                cliente = CreditoCliente.Crear(
                    cmd.Documento,
                    cmd.Celular,
                    cmd.Correo,
                    cmd.TipoIngreso,
                    cmd.Estadocivil
                    );

                _repo.Agregar(cliente);
                await _repo.GuardarAsync(cancellationToken);

                return ApiResponse<LoginResultDto>.Success(
                    new LoginResultDto
                    {
                        CodigoCliente = cliente.Id,
                        FlagCliente = false,
                        Cliente = ""
                    });
            }

            cliente.ActualizarContacto(cmd.Celular, cmd.Correo, cmd.TipoIngreso,cmd.Estadocivil);
            await _repo.GuardarAsync(cancellationToken);

            if (!cliente.EsCliente)
            {
                return ApiResponse<LoginResultDto>.Success(
                    new LoginResultDto
                    {
                        CodigoCliente = cliente.Id,
                        FlagCliente = false,
                        Cliente = ""
                    });
            }

            var tipoCambio = _tipoCambioRepo.ObtenerTipoCambioActual();

            return ApiResponse<LoginResultDto>.Success(
                new LoginResultDto
                {
                    CodigoCliente = cliente.Id,
                    Cliente = cliente.Flujo,
                    Flujo = cliente.Flujo,
                    MontoAprobado = cliente.Monto,
                    FlagCliente = true,
                    MontoAprobadoDolares = cliente.Monto / tipoCambio
                });
        }
    }
}
