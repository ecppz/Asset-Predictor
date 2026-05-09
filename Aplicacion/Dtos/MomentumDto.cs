using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dtos
{
    public class MomentumDto
    {
        public DateTime Fecha { get; set; }
        public double Valor { get; set; } // El valor actual
        public double Roc { get; set; }   // Rate of Change calculado
        public string Tendencia { get; set; } // "Alcista" o "Bajista"
    }

}
