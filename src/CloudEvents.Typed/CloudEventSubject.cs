using System;
using System.Collections.Generic;

namespace CloudEvents.Typed
{
    public class CloudEventSubject : ValueObject
    {
        public CloudEventSubject(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentException("subject must be non-empty", nameof(subject));
            }

            this.Value = subject;
        }

        public string Value { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this.Value;
        }
    }
}