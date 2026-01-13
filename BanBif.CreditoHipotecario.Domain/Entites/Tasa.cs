using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Domain.Entites
{
    public class Tasa
    {
        public int Id { get; set; }
        public decimal? Valor { get; set; }
        public int? Plazo { get; set; }
    }
}
