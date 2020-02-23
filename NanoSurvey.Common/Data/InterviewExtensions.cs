using System.Linq;
using Microsoft.EntityFrameworkCore;
using NanoSurvey.Common.Entities;

namespace NanoSurvey.Common.Data
{
    public static class InterviewExtensions
    {
        /// <summary>
        /// Вставляет принимаемый объект Interview в таблицу
        /// SQL: INSERT INTO [Interviews] (...) VALUES (...)
        /// </summary>
        public static Interview Create(this DbSet<Interview> interviews, Interview model)
        {
            interviews.Add(model);
            return model;
        }

        /// <summary>
        /// Находит в таблице объект ID = @id, либо возвращает null
        /// SQL: SELECT * FROM [Inteviews] WHERE [ID] = @id
        /// </summary>
        public static Interview GetByID(this DbSet<Interview> interviews, int id) 
        {
            var items = from s in interviews where s.ID == id select s;
            return items.FirstOrDefault();
        }
    }
}
