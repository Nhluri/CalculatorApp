using CalculatorApp.Models;
using CalculatorApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorApp.Tests
{
    [TestClass]
    public class CalculatorServiceTests
    {
        private CalculatorService _service;

        [TestInitialize]
        public void Setup()
        {
            _service = new CalculatorService();
        }

        [TestMethod]
        public void Add_TwoNumbers_ReturnsSum()
        {
            var model = new Calculator { Number1 = 5, Number2 = 3, Operation = "+" };
            var result = _service.Calculate(model, out string? error);

            Assert.AreEqual(8, result);
            Assert.IsNull(error);
        }

        [TestMethod]
        public void Subtract_TwoNumbers_ReturnsDifference()
        {
            var model = new Calculator { Number1 = 10, Number2 = 4, Operation = "-" };
            var result = _service.Calculate(model, out string? error);

            Assert.AreEqual(6, result);
            Assert.IsNull(error);
        }

        [TestMethod]
        public void Multiply_TwoNumbers_ReturnsProduct()
        {
            var model = new Calculator { Number1 = 2, Number2 = 5, Operation = "*" };
            var result = _service.Calculate(model, out string? error);

            Assert.AreEqual(10, result);
            Assert.IsNull(error);
        }

        [TestMethod]
        public void Divide_TwoNumbers_ReturnsQuotient()
        {
            var model = new Calculator { Number1 = 9, Number2 = 3, Operation = "/" };
            var result = _service.Calculate(model, out string? error);

            Assert.AreEqual(3, result);
            Assert.IsNull(error);
        }

        [TestMethod]
        public void Divide_ByZero_ReturnsError()
        {
            var model = new Calculator { Number1 = 5, Number2 = 0, Operation = "/" };
            var result = _service.Calculate(model, out string? error);

            Assert.AreEqual(0, result);
            Assert.AreEqual("Cannot divide by zero!", error);
        }

        [TestMethod]
        public void Invalid_Operation_ReturnsError()
        {
            var model = new Calculator { Number1 = 5, Number2 = 5, Operation = "%" };
            var result = _service.Calculate(model, out string? error);

            Assert.AreEqual(0, result);
            Assert.AreEqual("Invalid operation selected.", error);
        }
    }
}
