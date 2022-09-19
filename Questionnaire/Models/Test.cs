namespace Questionnaire.Models
{
    public class Test:IdModel
    {
        public Test(Guid id) : base(id) { }
        public Test() : base(){ }
        public string Title { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<TestResult> Results { get; set; }
    }
}
