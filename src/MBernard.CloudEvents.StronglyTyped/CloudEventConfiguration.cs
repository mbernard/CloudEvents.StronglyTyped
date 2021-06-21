using MBernard.CloudEvents.StronglyTyped.Providers;
using MBernard.CloudEvents.StronglyTyped.TypeResolvers;

namespace MBernard.CloudEvents.StronglyTyped
{
    public static class CloudEventConfiguration
    {
        public static ISourceProvider SourceProvider { get; set; } = new DataContractProvider();

        public static IIdProvider IdProvider { get; set; } = new GuidProvider();

        public static ITypeProvider TypeProvider { get; set; } = new DataContractProvider();

        public static ITypeResolver TypeResolver { get; set; } = new InMemoryTypeResolver();
    }
}