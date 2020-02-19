using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NanoSurvey.Common.Entities;

namespace NanoSurvey.Common.Data
{
    public class Surveys
    {

    }

    public static class SurveysExtensions
    {
        public static Survey GetByID(this DbSet<Survey> set, int id) 
        {
            return (from s in set where s.ID == id select s).FirstOrDefault();
        }

        public static Survey[] GetList(this DbSet<Survey> set, int count, int offset)
        {
            return set.Skip(offset).Take(count).ToArray();
        }
    }
}
