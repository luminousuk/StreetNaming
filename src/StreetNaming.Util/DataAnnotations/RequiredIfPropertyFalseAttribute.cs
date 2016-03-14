using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace StreetNaming.Util.DataAnnotations
{
    public class RequiredIfBooleanPropertyFalseAttribute : ValidationAttribute
    {
        private readonly string _dependentPropertyName;
        protected const string DefaultErrorMessageFormatString = "The {0} field is required.";

        public RequiredIfBooleanPropertyFalseAttribute(string dependentPropertyName)
        {
            _dependentPropertyName = dependentPropertyName;
            ErrorMessage = DefaultErrorMessageFormatString;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propVal = (bool)validationContext.ObjectInstance.GetType().GetProperty(_dependentPropertyName).GetValue(validationContext.ObjectInstance, null);
            
            return !propVal && value == null ? new ValidationResult(string.Format(ErrorMessageString, validationContext.DisplayName)) : ValidationResult.Success;
        }
    }
}
