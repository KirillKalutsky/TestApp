using Microsoft.EntityFrameworkCore;
using Questionnaire.Models;
using Questionnaire.DB;

namespace Questionnaire.Repositories
{
    public class TestRepository : BaseRepository<Test>
    {
        public TestRepository(TestContext context) : base(context)
        {
        }

        public override Task<List<Test>> GetAll()=>
            items.Include(test=>test.Questions).ToListAsync();

        public override Task<Test> Find(Guid id) =>
            items.Include(test=>test.Questions)
            .ThenInclude(question=>question.Answers)
            .Where(test=>test.Id==id)
            .FirstOrDefaultAsync();

        public async override Task<Guid> Insert(Test entity)
        {
            await items.AddAsync(entity);

            return entity.Id;
        }

    }
}
