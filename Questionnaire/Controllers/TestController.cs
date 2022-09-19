using Microsoft.AspNetCore.Mvc;
using Questionnaire.Models;
using Questionnaire.Models.Dto;
using Questionnaire.Services;
using Questionnaire.Extensions;

namespace Questionnaire.Controllers
{
    [Route("{controller}")]
    public class TestController : Controller
    {
        private readonly TestService testService;
        public TestController(TestService service)
        {
            testService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tests = (await testService.GetTestsAsync())
                .Select(test=>test.ToDto())
                .ToList();

            return View("Views/Test/TestsList.cshtml", tests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index([FromRoute] Guid id)
        {
            var test = await testService.GetTestAsync(id);

            return View(test.ToDto());
        }

        [HttpPost]
        public async Task<IActionResult> SendTest([FromForm] TestDto test)
        {
            await testService.SaveTestResult(test);

            return Redirect("Test");
        }

        [HttpGet("result/{id}")]
        public async Task<IActionResult> GetTestResults([FromRoute] Guid id)
        {
            var results = await testService.GetTestResults(id);

            return View("Views/Test/ResultList.cshtml", results);
        }

    }
}