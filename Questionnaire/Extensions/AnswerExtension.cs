using Questionnaire.Models;
using Questionnaire.Models.Dto;

namespace Questionnaire.Extensions
{
    public static class AnswerExtension
    {
        public static Answer ToAnswer(this AnswerDto dto) =>
            new Answer
            {
                Text = dto.Text,
                IsTrue = dto.IsTrue
            };

        public static AnswerDto ToDto(this Answer answer) =>
            new AnswerDto
            {
                Id = answer.Id,
                Text = answer.Text,
                IsTrue = answer.IsTrue
            };
    }
}
