using System.Linq;
using Microsoft.EntityFrameworkCore;
using NanoSurvey.Common.Entities;

namespace NanoSurvey.Common.Data
{
    public static class SurveyExtensions
    {
        /// <summary>
        /// Находит объект Survey по ID, либо возвращает null.
        /// SQL: SELECT * FROM [Surveys] WHERE [ID] = @id
        /// </summary>
        public static Survey GetByID(this DbSet<Survey> surveys, int id) 
        {
            var items = from s in surveys where s.ID == id select s;
            return items.FirstOrDefault();
        }

        /// <summary>
        /// Возвращает массив объектов Syrvey, начиная с ID = start.
        /// SQL: SELECT TOP(@count) * [Surveys] WHERE [ID] >= @start ORDER BY [ID] ASC 
        /// </summary>
        public static Survey[] GetList(this DbSet<Survey> surveys, int count, int start = 0)
        {
            var query = from s in surveys where s.ID >= start orderby s.ID ascending select s;
            return query.Take(count).ToArray();
        }
    }
}
