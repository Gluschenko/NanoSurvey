using System.Linq;
using Microsoft.EntityFrameworkCore;
using NanoSurvey.Common.Entities;

namespace NanoSurvey.Common.Data
{
    public static class AnswerExtextions
    {
        public static Answer[] Get(this DbSet<Answer> answers, int questionID)
        {
            var items = from a in answers where a.QuestionID == questionID orderby a.QuestionID ascending select a;
            return items.ToArray();
        }
    }
}
