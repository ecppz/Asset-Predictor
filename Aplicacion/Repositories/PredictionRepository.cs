using Aplicacion.Dtos;
using System.Collections.Generic;

namespace Aplicacion.Repositories
{
    public class PredictionRepository
    {
        private static PredictionRepository _instance;
        public static PredictionRepository Instance => _instance ??= new PredictionRepository();

        public PredictionListDto PredictionList { get; set; } = new()
        {
            SmaCrossover = new(),
            RegresionLineal = new(),
            Momentum = new()
        };
    }


}
