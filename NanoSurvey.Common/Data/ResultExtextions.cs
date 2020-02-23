using System.Linq;
using Microsoft.EntityFrameworkCore;
using NanoSurvey.Common.Entities;

namespace NanoSurvey.Common.Data
{
    public static class ResultExtextions
    {
        /// <summary>
        /// Сохраняет, либо обновляет результат ответа на вопрос. Не данном этапе не играет роли, 
        /// является ответ множественным или одиночным. Поля InterviewID и QuestionID составляют
        /// композитный ключ. InterviewID -- это foreign key от Interview.ID.
        /// </summary>
        /// <param name="interviewID">ID текущего интервью</param>
        /// <param name="questionID">ID текущего вопроса</param>
        /// <param name="value">Значение ответа (либо ID ответа, либо бинарный флаг)</param>
        /// <returns>Сущность Result</returns>
        public static Result Save(this DbSet<Result> results, int interviewID, int questionID, int value)
        {
            var result = (from r in results where r.InterviewID == interviewID && r.QuestionID == questionID select r)
                .Take(1).FirstOrDefault();

            if (result == null)
            {
                result = new Result
                {
                    InterviewID = interviewID,
                    QuestionID = questionID,
                    Value = value
                };

                results.Add(result);
            }
            else 
            {
                result.Value = value;
            }

            return result;
        }
    }
}
