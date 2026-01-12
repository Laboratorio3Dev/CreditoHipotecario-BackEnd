using BanBif.CreditoHipotecario.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Interfaces
{
    public interface ICreditoCommandRepository
    {
        CreditoCliente ObtenerPorDocumento(string documento);
        void Agregar(CreditoCliente cliente);
        Task GuardarAsync(CancellationToken cancellationToke);
    }
}
