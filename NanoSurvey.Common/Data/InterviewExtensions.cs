using System.Linq;
using Microsoft.EntityFrameworkCore;
using NanoSurvey.Common.Entities;

namespace NanoSurvey.Common.Data
{
    public static class InterviewExtensions
    {
        public static Interview Create(this DbSet<Interview> interviews, Interview model)
        {
            interviews.Add(model);
            return model;
        }

        public static Interview GetByID(this DbSet<Interview> interviews, int id) 
        {
            var items = from s in interviews where s.ID == id select s;
            return items.FirstOrDefault();
        }
    }
}
