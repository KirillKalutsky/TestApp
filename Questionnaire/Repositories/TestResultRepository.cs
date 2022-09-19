using Microsoft.EntityFrameworkCore;
using Questionnaire.DB;
using Questionnaire.Models;

namespace Questionnaire.Repositories
{
    public class TestResultRepository : BaseRepository<TestResult>
    {
        public TestResultRepository(TestContext context) : base(context)
        {
        }

        public override async Task<List<TestResult>> GetAll()=>
            await items.Include(test => test.Answers).ThenInclude(a=>a.Question)
            .Include(x=>x.Answers).ThenInclude(x=>x.SelectedAnswers).Include(x=>x.Test).ToListAsync();

        public override Task<TestResult> Find(Guid id)
        {
            return items.Include(res=>res.Test)
                .Include(res=>res.Answers)
                .ThenInclude(answer=>answer.SelectedAnswers)
                .Include(res=>res.Answers)
                .ThenInclude(answer=>answer.Question)
                .Where(res=>res.Id == id).FirstOrDefaultAsync();
        }

        public override async Task<Guid> Insert(TestResult entity)
        {
            await items.AddAsync(entity);

            return entity.Id;
        }

        public override Task Update(TestResult entity)
        {
            throw new NotImplementedException();
        }
    }
}
