using System.ComponentModel.DataAnnotations;
using NanoSurvey.Common.Data.Validation;

namespace NanoSurvey.Areas.API.Models
{
    public class ServeySaveResultsModel
    {
        [Required]
        public int SurveyID { get; set; }
        [Required]
        [EmailAddress] 
        public string Email { get; set; }
        [Required]
        [PersonName]
        public string FirstName { get; set; }
        [Required]
        [PersonName]
        public string LastName { get; set; }
        [Required]
        [PersonName]
        public string MiddleName { get; set; }
    }
}
