using Microsoft.EntityFrameworkCore;
using Questionnaire.Models;
using Questionnaire.DB;

namespace Questionnaire.Repositories
{
    public class QuestionRepository : BaseRepository<Question>
    {
        public QuestionRepository(TestContext context) : base(context)
        {
        }

        public override Task<List<Question>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<Guid> Insert(Question entity)
        {
            throw new NotImplementedException();
        }

        public override Task Update(Question entity)
        {
            throw new NotImplementedException();
        }
    }
}
