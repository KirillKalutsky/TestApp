namespace Questionnaire.Models
{
    public class AnswerOnQuestion: IdModel
    {
        public Question Question { get; set; } 
        public ICollection<Answer> SelectedAnswers { get; set; }
    }
}
