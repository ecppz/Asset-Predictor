
using Aplicacion.Dtos;
using Aplicacion.Enums;
using System.ComponentModel.DataAnnotations;

namespace Aplicacion.ViewModels
{
    public class PredictionListViewModel
    {
        public List<NewPredictionViewModel> Datos { get; set; } = new();
        public List<SmaCrossoverDto> SmaCrossover { get; set; } = new();
        public List<RegresionDto> RegresionLineal { get; set; } = new();
        public List<MomentumDto> Momentum { get; set; } = new();
    }
}
