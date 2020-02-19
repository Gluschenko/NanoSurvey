using System;
using System.Collections.Generic;
using System.Text;

namespace NanoSurvey.Common.Entities
{
    public class Answer
    {
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public string Text { get; set; }
    }
}
