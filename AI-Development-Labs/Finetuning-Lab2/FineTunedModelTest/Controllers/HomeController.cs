using FineTunedModelTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace FineTunedModelTest.Controllers
{
    public class HomeController(IConfiguration _config) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult AskQuestion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AskQuestion(string question)
        {
            HttpClient client = new HttpClient();
            // add auth header
            client.DefaultRequestHeaders.Authorization = new
                    System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _config["ModelCredentials:APIKey"]);

            // create body
            var body = new
            {
                model = _config["ModelCredentials:ModelName"],
                messages = new[]
                {
                    new { role = "user", content = question }
                }
            };

            // send post req
            var response = await client.PostAsJsonAsync(_config["ModelCredentials:Endpoint"], body);
            // read response
            var content = await response.Content.ReadAsStringAsync();
            // parse response
            using var doc = JsonDocument.Parse(content);

            var answer = doc.RootElement.GetProperty("choices")[0]
                .GetProperty("message").GetProperty("content").GetString();

            ViewBag.Question = question;
            ViewBag.Answer = answer;

            return View();
        }
    }
}
