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

        public override Task<List<Answer>> GetAll() =>
            items.ToListAsync();

        public override async Task<Guid> Insert(Answer entity)
        {
            await items.AddAsync(entity);

            return entity.Id;
        }

    }
}
