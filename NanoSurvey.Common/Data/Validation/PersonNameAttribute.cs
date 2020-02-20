using System.ComponentModel.DataAnnotations;

namespace NanoSurvey.Common.Data.Validation
{
    public class PersonNameAttribute : DataTypeAttribute
    {
        public PersonNameAttribute() : base("Personal name must be in the correct format") { }

        public override bool IsValid(object value)
        {
            if (value is string candidate)
            {
                return DataHelpers.IsValidPersonName(candidate);
            }
            return base.IsValid(value);
        }
    }
}
