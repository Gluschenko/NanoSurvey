using System.Linq;
using Microsoft.EntityFrameworkCore;
using NanoSurvey.Common.Entities;

namespace NanoSurvey.Common.Data
{
    public static class ResultExtextions
    {
        public static Result Save(this DbSet<Result> results, int interviewID, int questionID, int value)
        {
            var result = new Result
            {
                InterviewID = interviewID,
                QuestionID = questionID,
                Value = value
            };

            results.Add(result);
            return result;

            /*try
            {
                results.Add(result);
                return result;
            }
            catch 
            {
                return null;
            }*/
        }
    }
}
