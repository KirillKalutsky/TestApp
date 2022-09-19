namespace Questionnaire.Models
{
    public class TestResult:IdModel
    {
        public Test Test { get; set; } 
        public ICollection<AnswerOnQuestion> Answers { get; set; }
        public string PersonName { get; set; }
    }
}
