using Aplicacion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dtos
{
    public class PredictionListDto
    {
        public List<SmaCrossoverDto> SmaCrossover { get; set; } = new();
        public List<RegresionDto> RegresionLineal { get; set; } = new();
        public List<MomentumDto> Momentum { get; set; } = new();
    }
}
