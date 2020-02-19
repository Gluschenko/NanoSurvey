using System;
using Microsoft.EntityFrameworkCore;
using NanoSurvey.Common.Entities;

namespace NanoSurvey.Common
{
    public class SurveyDatabaseContext : DbContext
    {
        public DbSet<Survey> Surveys;
        public DbSet<Question> Questions;
        public DbSet<Answer> Answers;
        public DbSet<Result> Results;
        public DbSet<Interview> Interviews;

        public SurveyDatabaseContext(DbContextOptions<SurveyDatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }*/
    }
}
