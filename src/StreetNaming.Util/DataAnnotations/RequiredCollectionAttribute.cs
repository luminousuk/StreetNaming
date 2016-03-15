using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace StreetNaming.Util.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class RequiredCollectionAttribute : ValidationAttribute
    {
        protected const string DefaultErrorMessageFormatString = "You must provide at least one";

        public RequiredCollectionAttribute() : base(DefaultErrorMessageFormatString)
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return CheckValueIsValid(value)
                ? ValidationResult.Success
                : new ValidationResult(ErrorMessageString);
        }

        public override bool IsValid(object value)
        {
            return CheckValueIsValid(value);
        }

        private static bool CheckValueIsValid(object value)
        {
            var collection = value as ICollection;

            return collection?.Count > 0;
        }
    }
}