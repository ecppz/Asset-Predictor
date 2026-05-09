using Aplicacion.Dtos;
using Aplicacion.Services;
using Aplicacion.ViewModels;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Predictor.Controllers
{
    public class PredictionController : Controller
    {
        private readonly PredictionService services;
        private readonly PredictionModo modo;

        public PredictionController(PredictionService services, PredictionModo modo)
        {
            this.services = services;
            this.modo = modo;
        }
        public IActionResult Index(string? message = null, string? messageType = null)
        {
            var dto = services.GetAll();

            var predictionListViewModel = new PredictionListViewModel
            {
                SmaCrossover = dto.SmaCrossover,
                RegresionLineal = dto.RegresionLineal,
                Momentum = dto.Momentum
            };

            if (predictionListViewModel.Datos == null)
                predictionListViewModel.Datos = new List<NewPredictionViewModel>();

            while (predictionListViewModel.Datos.Count < 20)
            {
                predictionListViewModel.Datos.Add(new NewPredictionViewModel());
            }

            ViewBag.Message = message;
            ViewBag.MessageType = messageType;

            return View("Index", predictionListViewModel);
        }
        public IActionResult Calcular()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calcular(PredictionListViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Index");
                }

                var datos = model.Datos.Select(d => new PredictionDto
                {
                    Fecha = d.Fecha,
                    Valor = d.Valor
                }).ToList();

                var modoDto = new ModoDto { Type = modo.Current };
                var resultado = services.Opcion(datos, modoDto);

                return RedirectToRoute(new
                {
                    controller = "Prediction",
                    action = "Index",
                    message = $"predicción calculada!",
                    messageType = "alert-success"
                });

            }
            catch (Exception ex)
            {
                return RedirectToRoute(new
                {
                    controller = "Prediction",
                    action = "Index",
                    message = "no se pudo calcular la predicción",
                    messageType = "alert-danger"
                });
            }
        }

          
        public IActionResult Modos()
        {
            var vm = new ModoViewModel
            {
                Type = modo.Current 
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Modos(ModoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                modo.Current = model.Type;

                return RedirectToRoute(new
                {
                    controller = "Prediction",
                    action = "Index",
                    message = $"modo {modo.Current} seleccionado",
                    messageType = "alert-success"
                });
            }
            catch (Exception)
            {
                return RedirectToRoute(new
                {
                    controller = "Prediction",
                    action = "Index",
                    message = "no se pudo guardar el modo",
                    messageType = "alert-danger"
                });
            }
        }
    }
}
