using System;

using MBernard.CloudEvents.StronglyTyped.Common;

namespace MBernard.CloudEvents.StronglyTyped.Providers
{
    public class GuidProvider : IIdProvider
    {
        public NonEmptyString GetId() => new(Guid.NewGuid().ToString("D"));
    }
}