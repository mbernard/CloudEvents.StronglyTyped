using System;
using System.Diagnostics.CodeAnalysis;

using CloudNative.CloudEvents;

using MBernard.CloudEvents.StronglyTyped.Common;

namespace MBernard.CloudEvents.StronglyTyped
{
    public record CloudEvent<T>
        where T : notnull
    {
        public CloudEvent(T data, NonEmptyString? id = null, Uri? source = null, NonEmptyString? type = null)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Data cannot be null");
            }

            this.Data = data;
            this.Id = id ?? CloudEventConfiguration.IdProvider.GetId();
            this.Source = source ?? CloudEventConfiguration.SourceProvider.GetSource<T>();
            this.Type = type ?? CloudEventConfiguration.TypeProvider.GetType<T>();
            this.Time = CloudEventConfiguration.TimeProvider.GetTime();
            this.Subject = CloudEventConfiguration.SubjectProvider.GetSubject();
        }

        public NonEmptyString? Subject { get; init; }

        public DateTimeOffset? Time { get; init; }

        public T Data { get; init; }

        public NonEmptyString Id { get; init; }

        public Uri Source { get; init; }

        public NonEmptyString Type { get; init; }

        public static implicit operator CloudEvent<T>(CloudEvent from) => ToCloudEventT(from, (T)from.Data);

        public static implicit operator CloudEvent(CloudEvent<T> from) => ToCloudEvent(from);

        public CloudEvent<TData> Cast<TData>()
            where TData : notnull =>
            ToCloudEventT(this, (TData)((object)this.Data!)!);

        internal static CloudEvent<TData> ToCloudEventT<TData>(CloudEvent from, TData data)
            where TData : notnull
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