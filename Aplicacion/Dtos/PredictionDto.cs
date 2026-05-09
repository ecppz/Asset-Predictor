using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dtos
{
    public class PredictionDto
    {
        public required DateTime Fecha { get; set; }
        public required double Valor { get; set; }
    }
}
