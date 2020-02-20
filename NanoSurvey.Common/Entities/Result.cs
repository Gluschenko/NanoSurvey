using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NanoSurvey.Common.Entities
{
    public class Result
    {
        [Key]
        public int ID { get; set; }
        public int SurveyID { get; set; }
        public int InterviewID { get; set; }
    }
}
