using System.ComponentModel.DataAnnotations;
using NanoSurvey.Common.Entities;
using NanoSurvey.Common.Data.Validation;

namespace NanoSurvey.Areas.API.Models
{
    public class InterviewSaveModel
    {
        [Required]
        public int SurveyID { get; set; }
        [Required][EmailAddress][StringLength(40)] 
        public string Email { get; set; }
        [Required][PersonName][StringLength(40)]
        public string FirstName { get; set; }
        [Required][PersonName][StringLength(40)]
        public string LastName { get; set; }
        [Required][PersonName][StringLength(40)]
        public string MiddleName { get; set; }

        // Явный конверт в сущность БД
        public static explicit operator Interview(InterviewSaveModel model) 
        {
            return new Interview
            {
                Date = System.DateTime.Now,
                SurveyID = model.SurveyID,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
            };
        }
    }
}
