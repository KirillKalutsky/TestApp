using Questionnaire.Models.Dto;
using Questionnaire.Models;

namespace Questionnaire.Extensions
{
    public static class TestExtension
    {
        public static Test ToTest(this TestDto dto) =>
            new Test()
            {
                Questions = dto.Questions.Select(question => question.ToQuestion()).ToList(),
                Title = dto.Title
            };

        public static TestDto ToDto(this Test test) =>
            new TestDto
            {
                Title = test.Title,
                Id = test.Id,
                Questions = test.Questions != null? test.Questions.Select(question => question.ToDto()).ToList():null
            };
    }
}
