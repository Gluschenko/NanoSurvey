using System;
using System.ComponentModel.DataAnnotations;

namespace NanoSurvey.Common.Entities
{
    public class Interview
    {
        [Key]
        public int ID { get; set; }
        public int SurveyID { get; set; }
        public int ResultID { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}
