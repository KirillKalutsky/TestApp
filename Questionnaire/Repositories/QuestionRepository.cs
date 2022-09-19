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

        public override Task<List<Question>> GetAll() =>
            items.ToListAsync();

        public async override Task<Guid> Insert(Question entity)
        {
            await items.AddAsync(entity);

            return entity.Id;
        }

    }
}
