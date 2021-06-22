using System;

namespace MBernard.CloudEvents.StronglyTyped.Providers
{
    public interface ITimeProvider
    {
        DateTimeOffset? GetTime();
    }
}