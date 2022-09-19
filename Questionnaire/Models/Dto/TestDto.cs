namespace Questionnaire.Models.Dto
{
    public class TestDto
    {
        public Guid Id { get; set; }
        public string Title{ get; set; }
        public string RespondentFullName { get; set; }
        public List<QuestionDto> Questions { get; set; }
    }
}
