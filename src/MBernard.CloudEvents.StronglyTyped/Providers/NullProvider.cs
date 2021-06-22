using System;

using MBernard.CloudEvents.StronglyTyped.Common;

namespace MBernard.CloudEvents.StronglyTyped.Providers
{
    public class NullProvider : ISubjectProvider, ITimeProvider
    {
        public NonEmptyString? GetSubject() => null;

        public DateTimeOffset? GetTime() => null;
    }
}