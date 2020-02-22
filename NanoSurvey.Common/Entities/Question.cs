using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NanoSurvey.Common.Entities
{
    public class Question
    {
        [Key]
        public int ID { get; set; }
        public int SurveyID { get; set; }
        public string Text { get; set; }
        public bool IsMultipleAnswer { get; set; }

        public virtual List<Answer> Answers { get; set; }
    }
}
