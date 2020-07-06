using System;

using CloudNative.CloudEvents;

namespace CloudEvents.Typed
{
    public class CloudEvent<T>
    {
        internal CloudEvent(T data, CloudEventId id, Uri source, CloudEventsSpecVersion specVersion, CloudEventType type)
        {
            this.Data = data;
            this.Id = id;
            this.Source = source;
            this.SpecVersion = specVersion;
            this.Type = type;
        }

        public CloudEventId Id { get; }

        public Uri Source { get; }

        public CloudEventsSpecVersion SpecVersion { get; }

        public CloudEventType Type { get; }

        public T Data { get; }

        public CloudEventSubject? Subject { get; set; }

        public CloudEventTime? Time { get; set; }
    }
}