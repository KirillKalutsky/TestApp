using System.ComponentModel.DataAnnotations;

namespace Questionnaire.Models.Dto
{
    public class TestDto
    {
        public Guid Id { get; set; }
        public string Title{ get; set; }
        [Required]
        [Display(Name= "ФИО тестируемого")]
        public string RespondentFullName { get; set; }
        public List<QuestionDto> Questions { get; set; }
    }
}
