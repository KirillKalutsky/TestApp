namespace Questionnaire.Models
{
    public class Question:IdModel
    {
        public Question():base(){}
        public Question(Guid id):base(id){}
        public string Text { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<Test> Tests { get; set; }
    }
}
