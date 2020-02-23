using System.Linq;
using Microsoft.EntityFrameworkCore;
using NanoSurvey.Common.Entities;

namespace NanoSurvey.Common.Data
{
    public static class QuestionExtextions
    {
        /// <summary>
        /// Возвращает очередной вопрос, связанный с Survey. Также в Question содержатся связанные Answers (Eager loading)
        /// </summary>
        /// <param name="surveyID">Текущая анкета</param>
        /// <param name="previous">Предыдущий вопрос</param>
        /// <returns>Вопрос</returns>
        public static Question Get(this DbSet<Question> questions, int surveyID, int previous = 0)
        {
            var items = (from q in questions where q.SurveyID == surveyID && q.ID > previous select q).Take(1);
            return items.Include(q => q.Answers).FirstOrDefault();
        }

    }
}
