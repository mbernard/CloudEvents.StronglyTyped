using System;

using CloudEvents.Typed.Common;

namespace CloudEvents.Typed.Providers
{
    public class GuidProvider : IIdProvider
    {
        public NonEmptyString GetId() => new(Guid.NewGuid().ToString("D"));
    }
}