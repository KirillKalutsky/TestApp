using System.ComponentModel.DataAnnotations;

namespace Questionnaire.Models.Dto
{
    public class TestDto
    {
        public Guid Id { get; set; }
        public string Title{ get; set; }
        [Required(ErrorMessage = "Введите ваши ФИО")]
        [Display(Name= "ФИО тестируемого")]
        public string RespondentFullName { get; set; }
        public List<QuestionDto> Questions { get; set; }
        public string ErrorAnswerMessage => AreQuestionsAnswered ? "": "Необходимо ответить на все вопросы";
        public bool AreQuestionsAnswered => Questions.All(question =>
                    question.Answers.Any(answer => answer.IsSelected));
    }
}
