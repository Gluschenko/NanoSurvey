using System;
using System.Collections.Generic;
using System.Text;

namespace NanoSurvey.Common.Entities
{
    public class Question
    {
        public int ID { get; set; }
        public int SurveyID { get; set; }
        public string Text { get; set; }
        public bool IsMultipleAnswer { get; set; }
    }
}
