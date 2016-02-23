using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace StreetNaming.Util.DataAnnotations
{
    /// <summary>
    ///     Validates a UK telephone number
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public sealed class TelephoneAttribute : DataTypeAttribute
    {
        private static readonly Regex PostcodeRegex = CreateRegEx();

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:StreetNaming.Util.DataAnnotations.TelephoneAttribute" /> class.
        /// </summary>
        public TelephoneAttribute() : base(DataType.PhoneNumber)
        {
        }

        /// <summary>
        ///     Determines whether the specified value matches the pattern of a valid UK telephone number.
        /// </summary>
        /// <returns>
        ///     true if the specified value is valid or null; otherwise, false.
        /// </returns>
        /// <param name="value">The value to validate.</param>
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            var input = value as string;

            if (input != null)
                return PostcodeRegex.Match(input).Length > 0;

            return false;
        }

        private static Regex CreateRegEx()
        {
            return
                new Regex(
                    @"^(((\+44\s?\d{4}|\(?0\d{4}\)?)\s?\d{3}\s?\d{3})|((\+44\s?\d{3}|\(?0\d{3}\)?)\s?\d{3}\s?\d{4})|((\+44\s?\d{2}|\(?0\d{2}\)?)\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$",
                    RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled);
        }
    }
}