using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NanoSurvey.Common.Entities
{
    public class Answer
    {
        [Key]
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public string Text { get; set; }
    }
}
