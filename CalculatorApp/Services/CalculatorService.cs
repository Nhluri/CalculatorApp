using CalculatorApp.Models;

namespace CalculatorApp.Services
{
    public class CalculatorService
    {
        public double Calculate(Calculator model, out string? error)
        {
            error = null;
            double result = 0;

            switch (model.Operation)
            {
                case "+":
                    result = model.Number1 + model.Number2;
                    break;
                case "-":
                    result = model.Number1 - model.Number2;
                    break;
                case "*":
                    result = model.Number1 * model.Number2;
                    break;
                case "/":
                    if (model.Number2 == 0)
                    {
                        error = "Cannot divide by zero!";
                    }
                    else
                    {
                        result = model.Number1 / model.Number2;
                    }
                    break;
                default:
                    error = "Invalid operation selected.";
                    break;
            }

            return result;
        }
    }
}
