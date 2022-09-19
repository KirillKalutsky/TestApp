namespace Questionnaire.Models.Dto
{
    public class QuestionDto
    {
        public string Text { get; set; }
        public Guid Id { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
