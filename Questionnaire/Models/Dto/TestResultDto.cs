namespace Questionnaire.Models.Dto
{
    public class TestResultDto
    {
        public Guid Id { get; set; }
        public string PersonName { get; set; }
        public string TestTitle { get; set; }
        public List<AnswerOnQuestion> AnswersOnQuestions { get; set; }
    }
}
