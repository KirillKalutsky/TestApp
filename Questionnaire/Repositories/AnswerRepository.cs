using Microsoft.EntityFrameworkCore;
using Questionnaire.Models;
using Questionnaire.DB;

namespace Questionnaire.Repositories
{
    public class AnswerRepository : BaseRepository<Answer>
    {
        public AnswerRepository(TestContext context) : base(context)
        {
        }

        public override Task<List<Answer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<Guid> Insert(Answer entity)
        {
            throw new NotImplementedException();
        }

        public override Task Update(Answer entity)
        {
            throw new NotImplementedException();
        }
    }
}
