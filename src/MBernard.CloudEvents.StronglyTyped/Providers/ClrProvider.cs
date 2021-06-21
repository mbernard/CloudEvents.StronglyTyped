using MBernard.CloudEvents.StronglyTyped.Common;

namespace MBernard.CloudEvents.StronglyTyped.Providers
{
    public class ClrProvider : ITypeProvider
    {
        public NonEmptyString GetType<T>() => typeof(T).Name;
    }
}