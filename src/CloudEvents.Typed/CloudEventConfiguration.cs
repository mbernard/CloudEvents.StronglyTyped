using CloudEvents.Typed.Providers;
using CloudEvents.Typed.TypeResolvers;

namespace CloudEvents.Typed
{
    public static class CloudEventConfiguration
    {
        public static ISourceProvider SourceProvider { get; set; } = new DataContractProvider();

        public static IIdProvider IdProvider { get; set; } = new GuidProvider();

        public static ITypeProvider TypeProvider { get; set; } = new DataContractProvider();

        public static ITypeResolver TypeResolver { get; set; } = new InMemoryTypeResolver();
    }
}