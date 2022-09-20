using Microsoft.AspNetCore.Mvc;
using Questionnaire.Models;
using Questionnaire.Models.Dto;
using Questionnaire.Services;
using Questionnaire.Extensions;
using System.ComponentModel.DataAnnotations;

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
        public async Task<IActionResult> Index([FromRoute][Required] Guid id)
        {
            var test = await testService.GetTestAsync(id);

            return View(test.ToDto());
        }

        [HttpPost]
        public async Task<IActionResult> SendTest([FromForm] TestDto test)
        {
            if (test.RespondentFullName==null || 
                !test.AreQuestionsAnswered)
            {
                var testDto = (await testService.GetTestAsync(test.Id)).ToDto();
                return View("Views/Test/Index.cshtml", testDto);
            }

            await testService.SaveTestResult(test);

            return Redirect("Test");
        }

        [HttpGet("result/{id}")]
        public async Task<IActionResult> GetTestResults([FromRoute][Required] Guid id)
        {
            var results = await testService.GetTestResults(id);

            return View("Views/Test/ResultList.cshtml", results.Select(res=>res.ToDto()).ToList());
        }

    }
}