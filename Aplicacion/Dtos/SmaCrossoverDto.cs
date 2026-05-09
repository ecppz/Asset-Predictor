using Aplicacion.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dtos
{
    public class SmaCrossoverDto
    {
        public double SmaCorta { get; set; }
        public double SmaLarga { get; set; }
        public string Tendencia { get; set; }
    }
}
