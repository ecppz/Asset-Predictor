using Aplicacion.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.ViewModels
{
    public class ModoViewModel
    {
        [Range(1, 3, ErrorMessage = "modo no valido")]
        public PredictionType Type { get; set; }
    }
}
