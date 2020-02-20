using System.Linq;
using Microsoft.EntityFrameworkCore;
using NanoSurvey.Common.Entities;

namespace NanoSurvey.Common.Data
{
    public static class SurveyExtensions
    {
        public static Survey GetByID(this DbSet<Survey> set, int id) 
        {
            var items = from s in set where s.ID == id select s;
            return items.FirstOrDefault();
        }

        public static Survey[] GetList(this DbSet<Survey> set, int count, int offset)
        {
            return set.Skip(offset).Take(count).ToArray();
        }
    }
}
