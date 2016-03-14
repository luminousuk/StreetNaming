using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace StreetNaming.Util.DataAnnotations
{
    public class RequiredGroup : ValidationAttribute
    {
        private readonly IList<string> _properties;
        protected const string DefaultErrorMessageFormatString = "At least one must be populated: {0}";

        public RequiredGroup(params string[] properties)
        {
            _properties = properties.ToList();
            ErrorMessage = DefaultErrorMessageFormatString;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var anyPopulated =
                _properties.Any(
                    property =>
                        validationContext.ObjectInstance.GetType()
                            .GetProperty(property)
                            .GetValue(validationContext.ObjectInstance, null) != null);
            
            return anyPopulated ? new ValidationResult(string.Format(ErrorMessageString, validationContext.DisplayName)) : ValidationResult.Success;
        }
    }
}
