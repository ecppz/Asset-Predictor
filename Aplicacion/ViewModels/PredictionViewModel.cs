using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.ViewModels
{
    public class PredictionViewModel
    {
        [DataType(DataType.Date)]
        public required DateTime Fecha { get; set; }
        public required double Valor { get; set; }

    }
}
