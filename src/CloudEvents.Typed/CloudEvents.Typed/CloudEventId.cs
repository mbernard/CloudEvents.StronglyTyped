using System;
using System.Collections.Generic;

namespace CloudEvents.Typed
{
    public class CloudEventId : ValueObject
    {
        public CloudEventId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("id must be a non-empty string", nameof(id));
            }

            this.Value = id;
        }

        public string Value { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this.Value;
        }
    }
}