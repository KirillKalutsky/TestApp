using Questionnaire.Models;
using Microsoft.EntityFrameworkCore;

namespace Questionnaire.DB
{
    public class TestContext:DbContext
    {
        private readonly DbSet<Question> Questions;
        private readonly DbSet<Answer> Answers;
        private readonly DbSet<Test> Tests;
        private readonly DbSet<TestResult> Results;
        private readonly DbSet<AnswerOnQuestion> AnswerOnQuestions;
        public TestContext(DbContextOptions<TestContext> contextOptions)
            : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasMany(question => question.Answers)
                .WithMany(answer => answer.Questions);

            modelBuilder.Entity<Test>()
                .HasMany(test => test.Questions)
                .WithMany(question => question.Tests);

            modelBuilder.Entity<TestResult>()
                .HasOne(result => result.Test)
                .WithMany(test => test.Results);

            modelBuilder.Entity<TestResult>()
                .HasMany(result => result.Answers);

            modelBuilder.Entity<AnswerOnQuestion>()
                .HasMany(x => x.SelectedAnswers);

            modelBuilder.Entity<AnswerOnQuestion>()
                .HasOne(x => x.Question);
        }
    }
}
