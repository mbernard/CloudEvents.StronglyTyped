using System;

using CloudNative.CloudEvents;

using MBernard.CloudEvents.StronglyTyped.TypeResolvers;

namespace MBernard.CloudEvents.StronglyTyped
{
    public static class CloudEventExtensions
    {
        public static CloudEvent<object> ToStronglyTyped(
            this CloudEvent cloudEvent,
            Func<CloudEvent, Type, object> transformer) =>
            ToStronglyTyped(cloudEvent, transformer, CloudEventConfiguration.TypeResolver);

        public static CloudEvent<object> ToStronglyTyped(
            this CloudEvent cloudEvent,
            Func<CloudEvent, Type, object> transformer,
            ITypeResolver typeResolver)
        {
            var type = typeResolver.ResolveType(cloudEvent.Type);
            var data = transformer(cloudEvent, type);

            return ToStronglyTypedInternal(cloudEvent, data);
        }

        public static CloudEvent<T> ToStronglyTyped<T>(this CloudEvent cloudEvent, Func<CloudEvent, T> dataTransformer)
            where T : notnull =>
            ToStronglyTypedInternal(cloudEvent, dataTransformer(cloudEvent));

        private static CloudEvent<T> ToStronglyTypedInternal<T>(CloudEvent cloudEvent, T data)
            where T : notnull
        {
            var ce = new CloudEvent<T>(data, cloudEvent.Id, cloudEvent.Source, cloudEvent.Type)
            {
                Time = cloudEvent.Time
            };

            if (cloudEvent.Subject is not null)
            {
                ce = ce with { Subject = cloudEvent.Subject };
            }

            return ce;
        }
    }
}