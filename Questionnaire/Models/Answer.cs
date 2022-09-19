namespace Questionnaire.Models
{
    public class Answer:IdModel
    {
        public Answer(Guid id) : base(id) { }
        public Answer():base() { }
        public ICollection<Question> Questions{ get; set; }
        public string Text { get; set; }
        public bool IsTrue { get; set; }
        public ICollection<AnswerOnQuestion> SelectedAnswers { get; set; }
    }
}
