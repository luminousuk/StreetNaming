using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace StreetNaming.Util.DataAnnotations
{
    /// <summary>
    ///     Validates a UK Post Code (format only)
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public sealed class PostCodeAttribute : DataTypeAttribute
    {
        private static readonly Regex PostcodeRegex = CreateRegEx();

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:StreetNaming.Util.DataAnnotations.PostCodeAttribute" /> class.
        /// </summary>
        public PostCodeAttribute() : base(DataType.PostalCode)
        {
        }

        /// <summary>
        ///     Determines whether the specified value matches the pattern of a valid UK post code address.
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
                    "^(GIR ?0AA|[A-PR-UWYZ]([0-9]{1,2}|([A-HK-Y][0-9]([0-9ABEHMNPRV-Y])?)|[0-9][A-HJKPS-UW]) ?[0-9][ABD-HJLNP-UW-Z]{2})$",
                    RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled);
        }
    }
}