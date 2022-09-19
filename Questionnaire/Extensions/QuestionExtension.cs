using Questionnaire.Models;
using Questionnaire.Models.Dto;

namespace Questionnaire.Extensions
{
    public static class QuestionExtension
    {
        public static Question ToQuestion(this QuestionDto dto) =>
            new Question
            {
                Text = dto.Text,
                Answers = dto.Answers.Select(answer=>answer.ToAnswer()).ToList()
            };

        public static QuestionDto ToDto(this Question question) =>
            new QuestionDto
            {
                Text = question.Text,
                Id = question.Id,
                Answers = question.Answers !=null ? question.Answers.Select(answer => answer.ToDto()).ToList():null
            };
    }
}
