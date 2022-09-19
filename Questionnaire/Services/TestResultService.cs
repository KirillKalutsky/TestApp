using Questionnaire.Models;
using Questionnaire.Models.Dto;
using Questionnaire.Repositories;

namespace Questionnaire.Services
{
    public class TestResultService
    {
        private readonly BaseRepository<TestResult> _resultRepository;
        public TestResultService(BaseRepository<TestResult> resultRepository)
        {
            _resultRepository = resultRepository;
        }

        public async Task<TestResult> GetResultById(Guid id) =>
            await _resultRepository.Find(id);
    }
}
