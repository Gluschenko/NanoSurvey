using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NanoSurvey.Common.Entities
{
    public class ResultItem
    {
        // ТУТ КОМПОЗИТНЫЙ КЛЮЧ
        [Key]
        public int ResultID { get; set; } 
        public int Value { get; set; }
    }
}
