using Aplicacion.Dtos;
using System.ComponentModel.DataAnnotations;
using Aplicacion.Validations;

namespace Aplicacion.ViewModels
{
    public class NewPredictionViewModel
    {
        [Required(ErrorMessage = "no puedes dejar este campo vacio")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "no puedes dejar este campo vacio")]
        [NotZero(ErrorMessage = "el valor no puede ser 0")]
        public double Valor { get; set; }
    }
}