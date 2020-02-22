using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NanoSurvey.Common.Entities
{
    public class Result
    {
        //public int ID { get; set; }
        public int InterviewID { get; set; }
        public int QuestionID { get; set; }
        public int Value { get; set; }
    }
}
