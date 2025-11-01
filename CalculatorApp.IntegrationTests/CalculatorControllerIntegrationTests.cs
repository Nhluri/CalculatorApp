using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace CalculatorApp.IntegrationTests
{
    [TestClass]
    public class CalculatorControllerIntegrationTests
    {
        private static WebApplicationFactory<Program> _factory = default!;
        private static HttpClient _client = default!;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [TestMethod]
        public async Task Post_ToIndex_ReturnsCorrectResult()
        {
            // Arrange – form data like a user submitting the calculator form
            var formData = new[]
            {
                new KeyValuePair<string, string>("Number1", "8"),
                new KeyValuePair<string, string>("Number2", "4"),
                new KeyValuePair<string, string>("Operation", "+")
            };

            var content = new FormUrlEncodedContent(formData);

            // Act – send POST request to the controller action
            var response = await _client.PostAsync("/Calculator/Index", content);

            // Assert – make sure it loaded and contains expected output
            response.EnsureSuccessStatusCode();
            var responseHtml = await response.Content.ReadAsStringAsync();

            // Verify result text appears in the rendered view (e.g., "Result: 12")
            responseHtml.Should().Contain("12");
        }
    }
}
