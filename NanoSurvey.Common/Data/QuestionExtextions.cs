using System.Linq;
using Microsoft.EntityFrameworkCore;
using NanoSurvey.Common.Entities;

namespace NanoSurvey.Common.Data
{
    public static class QuestionExtextions
    {
        public static Question GetQuestion(this DbSet<Question> questions, int surveyID, int start = 0)
        {
            var items = from q in questions where q.SurveyID == surveyID && q.ID >= start select q;
            return items.FirstOrDefault();
        }
    }
}
