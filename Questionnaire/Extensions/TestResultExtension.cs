using Questionnaire.Models;
using Questionnaire.Models.Dto;

namespace Questionnaire.Extensions
{
    public static class TestResultExtension
    {
        public static TestResultDto ToDto(this TestResult result) =>
            new TestResultDto()
            {
                TestTitle = result.Test.Title,
                PersonName = result.PersonName,
                AnswersOnQuestions = result.Answers.ToList(),
                Id = result.Id,
            };
    }
}
