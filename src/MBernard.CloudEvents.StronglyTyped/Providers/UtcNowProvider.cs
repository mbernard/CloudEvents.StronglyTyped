using System;

namespace MBernard.CloudEvents.StronglyTyped.Providers
{
    public class UtcNowProvider : ITimeProvider
    {
        public DateTimeOffset? GetTime() => DateTimeOffset.UtcNow;
    }
}