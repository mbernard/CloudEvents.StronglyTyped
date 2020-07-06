using System;
using System.Collections.Generic;

namespace CloudEvents.Typed
{
    public class CloudEventType : ValueObject
    {
        public CloudEventType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException("type must be a non-empty string", nameof(type));
            }

            this.Value = type;
        }

        public string Value { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this.Value;
        }
    }
}