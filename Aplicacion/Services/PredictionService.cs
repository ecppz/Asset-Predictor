using Aplicacion.Dtos;
using Aplicacion.Enums;
using Aplicacion.Repositories;
using System.Reflection;

namespace Aplicacion.Services
{
    public class PredictionService
    {
        public object Opcion(List<PredictionDto> datos, ModoDto modoDto)
        {
            var dto = datos.Select(d => d.Valor).ToList();

            switch (modoDto.Type)
            {
                case PredictionType.SmaCrossover:
                    return CalcularSmaCrossover(dto);
                case PredictionType.RegresionLineal:
                    return CalcularRegresion(dto);
                case PredictionType.Momentum:
                    return CalcularMomentum(dto);
                default:
                    return CalcularSmaCrossover(dto);
            }
        }
        public SmaCrossoverDto CalcularSmaCrossover(List<double> datos)
        {
                double smaCorta = datos.TakeLast(5).Average();
                double smaLarga = datos.TakeLast(20).Average();
                string tendencia = smaCorta > smaLarga ? "Alcista" : "Bajista";

            var dto = new SmaCrossoverDto
            {
                SmaCorta = smaCorta,
                SmaLarga = smaLarga,
                Tendencia = tendencia
            };
            PredictionRepository.Instance.PredictionList.SmaCrossover = new List<SmaCrossoverDto> { dto };
            return dto;
        }
        public RegresionDto CalcularRegresion(List<double> datos)
        {
            int n = datos.Count;
            var x = Enumerable.Range(1, n).Select(i => (double)i).ToList();

            double sumX = x.Sum();
            double sumY = datos.Sum();
            double sumXY = x.Zip(datos, (xi, yi) => xi * yi).Sum();
            double sumX2 = x.Select(xi => xi * xi).Sum();

            double pendiente = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
            double interseccion = (sumY - pendiente * sumX) / n;

            double valorPredicho = pendiente * (n + 1) + interseccion;
            string tendencia = valorPredicho > datos.Last() ? "Alcista" : "Bajista";

            var dto = new RegresionDto
            {
                Pendiente = pendiente,
                Interseccion = interseccion,
                ValorPredicho = valorPredicho,
                Tendencia = tendencia
            };
            PredictionRepository.Instance.PredictionList.RegresionLineal = new List<RegresionDto> { dto };
            return dto;
        }


        public List<MomentumDto> CalcularMomentum(List<double> datos)
        {
            const int n = 5;
            var resultados = new List<MomentumDto>();

            for (int t = 0; t < datos.Count; t++)
            {
                double valorActual = datos[t];

                if (t < n)
                {
                    resultados.Add(new MomentumDto
                    {
                        Valor = valorActual,
                        Roc = double.NaN,
                        Tendencia = "n/a"
                    });
                }
                else
                {
                    double valorAnterior = datos[t - n];
                    double roc = ((valorActual / valorAnterior) - 1) * 100;
                    string tendencia = roc > 0 ? "Alcista" : "Bajista";

                    resultados.Add(new MomentumDto
                    {
                        Valor = valorActual,
                        Roc = roc,
                        Tendencia = tendencia
                    });
                }
            }

            PredictionRepository.Instance.PredictionList.Momentum = resultados;
            return resultados;
        }


        public PredictionListDto GetAll()
        {
            return PredictionRepository.Instance.PredictionList;
        }
    }
}