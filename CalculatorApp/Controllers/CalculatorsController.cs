using Microsoft.AspNetCore.Mvc;
using CalculatorApp.Models;
using CalculatorApp.Services;

namespace CalculatorApp.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly CalculatorService _calculatorService;

        // Inject the service through the constructor
        public CalculatorController(CalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new Calculator());
        }

        [HttpPost]
        public IActionResult Index(Calculator model)
        {
            if (ModelState.IsValid)
            {
                var result = _calculatorService.Calculate(model, out string? error);
                model.Result = result;
                ViewBag.Error = error;
            }

            return View(model);
        }
    }
}
