using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NanoSurvey.Common.Entities
{
    public class Survey
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(ID))]
        public ICollection<Question> Questions { get; set; }
    }
}
