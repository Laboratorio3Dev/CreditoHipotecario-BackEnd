using BanBif.CreditoHipotecario.Application.Common.Responses;
using BanBif.CreditoHipotecario.Application.Interfaces;
using BanBif.CreditoHipotecario.Domain.Entites;
using BanBif.CreditoHipotecario.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Commands.Credito.RegistrarOferta
{
    public class RegistrarOfertaCommandHandler
     : IRequestHandler<RegistrarOfertaCommand, ApiResponse<RegistrarOfertaResultDto>>
    {
        private readonly IAprobadoQuieroRepository _quieroRepo;
        private readonly ICreditoCommandRepository _clienteRepo;
        private readonly IAprobadoRepository _aprobadoRepo;
        private readonly ISimulacionRepository _simulacionRepo;
        private readonly IHorarioRepository _horarioRepo;
        private readonly IPandoraRepository _pandoraRepo;
        private readonly PandoraService _pandoraService;

        public RegistrarOfertaCommandHandler(
            IAprobadoQuieroRepository quieroRepo,
            ICreditoCommandRepository clienteRepo,
            IAprobadoRepository aprobadoRepo,
            ISimulacionRepository simulacionRepo,
            IHorarioRepository horarioRepo,
            IPandoraRepository pandoraRepo,
            PandoraService pandoraService)
        {
            _quieroRepo = quieroRepo;
            _clienteRepo = clienteRepo;
            _aprobadoRepo = aprobadoRepo;
            _simulacionRepo = simulacionRepo;
            _horarioRepo = horarioRepo;
            _pandoraRepo = pandoraRepo;
            _pandoraService = pandoraService;
        }

        //public async Task<ApiResponse<RegistrarOfertaResultDto>> Handle(
        //    RegistrarOfertaCommand cmd,
        //    CancellationToken cancellationToken)
        //{
        //    int ultimoId = 0;

        //    // 1️⃣ Guardar todos
        //    foreach (var item in cmd.codigosaprobados)
        //    {
        //        var quiero = AprobadoQuiero.Crear(
        //            item,
        //            cmd.CodigoCliente,
        //            cmd.Horario,
        //            cmd.Ruta,
        //            cmd.UTM);

        //        _quieroRepo.Agregar(quiero);
        //        // último insertado
        //        ultimoId = quiero.Id; // o trae el último creado
        //    }

        //    await _quieroRepo.GuardarAsync(cancellationToken);



        //    // 2️⃣ SOLO UNA VEZ
        //    var telefono = await _quieroRepo.EjecutarAsignacionEjecutivoAsync(
        //        cmd.CodigoCliente,
        //        cmd.CodigoLog.ToString());

        //    // 3️⃣ respuesta
        //    return ApiResponse<RegistrarOfertaResultDto>.Success(
        //        new RegistrarOfertaResultDto
        //        {
        //            codigoaprobadoquiero = ultimoId,
        //            telefonoEjecutivo = telefono
        //        });

        //    //var aprobado = await _aprobadoRepo.ObtenerIdAsync(cmd.CodigoAprobado, cancellationToken);
        //    //var simulacion = await _simulacionRepo.ObtenerPorIdAsync(aprobado.Id, cancellationToken);

        //    //var ejecutivo = await _horarioRepo.ObtenerEjecutivoDisponibleAsync(
        //    //    quiero.FechaRegistro,
        //    //    cancellationToken);

        //    //// 3️⃣ Crear registro Pandora (DOMINIO)
        //    //var pandora = _pandoraService.CrearRegistro(
        //    //    quiero, cliente, aprobado, simulacion, ejecutivo);

        //    //_pandoraRepo.Agregar(pandora);

        //    //if (ejecutivo != null)
        //    //    ejecutivo.IncrementarContador();

        //    //return ApiResponse<RegistrarOfertaResultDto>.Success(
        //    // new RegistrarOfertaResultDto
        //    // {
        //    //     codigoaprobadoquiero =0
        //    // });


        //}

        public async Task<ApiResponse<RegistrarOfertaResultDto>> Handle(
    RegistrarOfertaCommand cmd,
    CancellationToken cancellationToken)
        {
            var quieroEntities = new List<AprobadoQuiero>();

            // 1️⃣ Crear entidades
            foreach (var item in cmd.codigosaprobados)
            {
                var quiero = AprobadoQuiero.Crear(
                    item,
                    cmd.CodigoCliente,
                    cmd.Horario,
                    cmd.Ruta,
                    cmd.UTM);

                _quieroRepo.Agregar(quiero);
                quieroEntities.Add(quiero);
            }

            // 2️⃣ Guardar TODO junto (1 sola transacción EF)
            await _quieroRepo.GuardarAsync(cancellationToken);

            // 🔥 Ahora los IDs ya existen
            int ultimoId = quieroEntities.Last().Id;

            // 3️⃣ Ejecutar SP UNA SOLA VEZ (fuera de problemas de transacción)
            var telefono = await _quieroRepo.EjecutarAsignacionEjecutivoAsync(
                cmd.CodigoCliente,
                cmd.CodigoLog.ToString());

            // 4️⃣ Respuesta
            return ApiResponse<RegistrarOfertaResultDto>.Success(
                new RegistrarOfertaResultDto
                {
                    codigoaprobadoquiero = ultimoId,
                    telefonoEjecutivo = telefono
                });
        }

    }
}
