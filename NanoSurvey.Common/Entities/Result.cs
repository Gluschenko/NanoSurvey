using System;
using System.Collections.Generic;
using System.Text;

namespace NanoSurvey.Common.Entities
{
    public class Result
    {
        public int ID { get; set; }
        public int SurveyID { get; set; }
        public int InterviewID { get; set; }
        public string Data { get; set; }
    }
}
