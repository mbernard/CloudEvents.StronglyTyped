using System;

using CloudEvents.Typed.Common;

using CloudNative.CloudEvents;

namespace CloudEvents.Typed
{
    public record CloudEvent<T>(T Data, NonEmptyString Id, Uri Source, NonEmptyString Type)
    {
        public CloudEvent(T data)
            : this(
                data,
                CloudEventConfiguration.IdProvider.GetId(),
                CloudEventConfiguration.SourceProvider.GetSource<T>(),
                CloudEventConfiguration.TypeProvider.GetType<T>()) =>
            this.Time = DateTimeOffset.UtcNow;

        public NonEmptyString? Subject { get; init; }

        public DateTimeOffset? Time { get; init; }

        public static implicit operator CloudEvent<T>(CloudEvent from) => ToCloudEventT(from, (T)from.Data);

        public static implicit operator CloudEvent(CloudEvent<T> from) => ToCloudEvent(from);

        public CloudEvent<TData> Cast<TData>() => ToCloudEventT(this, (TData)((object)this.Data!)!);

        internal static CloudEvent<TData> ToCloudEventT<TData>(CloudEvent from, TData data)
        {
            var ce = new CloudEvent<TData>(data, from.Id, from.Source, from.Type) { Time = from.Time };

            if (from.Subject is not null)
            {
                ce = ce with { Subject = from.Subject };
            }

            return ce;
        }

        internal static CloudEvent ToCloudEvent(CloudEvent<T> from)
        {
            var ce = new CloudEvent(CloudEventsSpecVersion.Default)
            {
                Type = from.Type,
                Source = from.Source,
                Id = from.Id,
                Time = from.Time,
                Data = from.Data
            };

            if (from.Subject is not null)
            {
                ce.Subject = from.Subject.Value;
            }

            return ce.Validate();
        }
    }
}