using Questionnaire.Extensions;
using Questionnaire.Repositories;
using Questionnaire.Models;
using Questionnaire.Models.Dto;

namespace Questionnaire.Services
{
    public class TestService
    {
        private BaseRepository<Test> testRepository;
        private BaseRepository<TestResult> testResultRepositoy;
        private BaseRepository<Question> questionRepository;
        private BaseRepository<Answer> answerRepository;
        public TestService(BaseRepository<Test> repository,
            BaseRepository<TestResult> resultRepository,
            BaseRepository<Question> questionRep,
            BaseRepository<Answer> answerRep)
        {
            testRepository = repository;
            testResultRepositoy = resultRepository;
            questionRepository = questionRep;
            answerRepository = answerRep;
        }

        public async Task<List<TestResult>> GetTestResults(Guid testId)
        {
            var results = await testResultRepositoy.GetAll();

            return results.Where(x=>x.Test.Id==testId).ToList();
        }

        public async Task SaveTestResult(TestDto testDto)
        {
            var result = new TestResult()
            {
                Test = await testRepository.Find(testDto.Id),
                PersonName = testDto.RespondentFullName,
            };

            var answersResult = new List<AnswerOnQuestion>();

            foreach(var question in testDto.Questions)
            {
                var answers = new List<Answer>();
                foreach(var answer in question.Answers)
                {
                    if(answer.IsSelected)
                        answers.Add(await answerRepository.Find(answer.Id));
                }

                answersResult.Add(new AnswerOnQuestion()
                {
                    Question = await questionRepository.Find(question.Id),
                    SelectedAnswers=answers
                }); 
            }

            result.Answers = answersResult;

            await testResultRepositoy.Insert(result);

            await testResultRepositoy.SaveChanges();
        }

        public async Task<Test> GetTestAsync(Guid id) =>
            await testRepository.Find(id);

        public async Task<List<Test>> GetTestsAsync() =>
            await testRepository.GetAll();

        public async Task<Guid> InsertTestAsync(TestDto dto)
        {
            var test = dto.ToTest();
            var id = await testRepository.Insert(test);
            await testRepository.SaveChanges();
            return id;
        }
    }

}
