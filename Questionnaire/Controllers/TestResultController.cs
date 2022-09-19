using Microsoft.AspNetCore.Mvc;
using Questionnaire.Models;
using Questionnaire.Models.Dto;
using Questionnaire.Services;
using Questionnaire.Extensions;

namespace Questionnaire.Controllers
{
    [Route("{controller}")]
    public class TestResultController:Controller
    {
        private readonly TestResultService _resultService;
        public TestResultController(TestResultService resultService)
        {
            _resultService = resultService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetResult(Guid id)
        {
            var res = await _resultService.GetResultById(id);

            return View("Views/Test/Result.cshtml", res);
        }
    }
}
