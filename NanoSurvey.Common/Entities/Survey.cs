using System.ComponentModel.DataAnnotations;

namespace NanoSurvey.Common.Entities
{
    public class Survey
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
