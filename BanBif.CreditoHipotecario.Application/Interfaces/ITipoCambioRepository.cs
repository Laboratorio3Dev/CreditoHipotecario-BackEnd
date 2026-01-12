using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Application.Interfaces
{
    public interface ITipoCambioRepository
    {
        decimal ObtenerTipoCambioActual();
    }
}
