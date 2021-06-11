using CloudEvents.Typed.Common;

namespace CloudEvents.Typed.Providers
{
    public class ClrProvider : ITypeProvider
    {
        public NonEmptyString GetType<T>() => typeof(T).Name;
    }
}