using System;
using System.Collections.Generic;

namespace CloudEvents.Typed
{
    public class CloudEventTime : ValueObject
    {
        public CloudEventTime(DateTime time)
        {
            if (time.Kind != DateTimeKind.Utc)
            {
                throw new ArgumentException("time must be a UTC datetime", nameof(time));
            }

            this.Value = time;
        }

        public DateTime Value { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this.Value;
        }
    }
}