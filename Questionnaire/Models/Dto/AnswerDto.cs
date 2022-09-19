namespace Questionnaire.Models.Dto
{
    public class AnswerDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsSelected { get; set; }
        public bool IsTrue { get; set; }
    }
}
