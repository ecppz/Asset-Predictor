using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dtos
{
    public class RegresionDto
    {
        public double Pendiente { get; set; }
        public double Interseccion { get; set; }
        public double ValorPredicho { get; set; }
        public string Tendencia { get; set; }
    }
}
