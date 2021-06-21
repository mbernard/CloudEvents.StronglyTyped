using System;

namespace MBernard.CloudEvents.StronglyTyped.Common
{
    public record NonEmptyString
    {
        public NonEmptyString(string value) => this.Value = Validate(value);

        public string Value { get; }

        public static implicit operator string(NonEmptyString nonEmptyString) => nonEmptyString.Value;

        public static implicit operator NonEmptyString(string value) => new(value);

        private static string Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("value must be non-empty", nameof(value));
            }

            return value;
        }
    }
}