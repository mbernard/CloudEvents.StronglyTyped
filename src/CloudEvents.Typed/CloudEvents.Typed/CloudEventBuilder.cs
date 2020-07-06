using System;
using System.Reflection;
using System.Runtime.Serialization;

using CloudNative.CloudEvents;

namespace CloudEvents.Typed
{
    internal class CloudEventBuilder<T>
    {
        private readonly T _data;
        private CloudEventId _id;
        private Uri _source;
        private CloudEventsSpecVersion _specVersion;
        private CloudEventSubject? _subject;
        private CloudEventType _type;
        private CloudEventTime _time;

        private CloudEventBuilder(T data)
        {
            var dataContract = typeof(T).GetCustomAttribute<DataContractAttribute>(true);

            this._data = data;
            this._id = new CloudEventId(Guid.NewGuid().ToString());
            this._source = new Uri(dataContract.Namespace);
            this._specVersion = CloudEventsSpecVersion.Default;
            this._type = new CloudEventType(dataContract.Name);
            this._time = new CloudEventTime(DateTime.UtcNow);
        }

        public static CloudEventBuilder<T> New(T data) => new CloudEventBuilder<T>(data);

        public CloudEventBuilder<T> WithId(CloudEventId id)
        {
            this._id = id;
            return this;
        }

        public CloudEventBuilder<T> WithSource(Uri source)
        {
            this._source = source;
            return this;
        }

        public CloudEventBuilder<T> WithSpecVersion(CloudEventsSpecVersion specVersion)
        {
            this._specVersion = specVersion;
            return this;
        }

        public CloudEventBuilder<T> WithType(CloudEventType type)
        {
            this._type = type;
            return this;
        }

        public CloudEventBuilder<T> WithSubject(CloudEventSubject subject)
        {
            this._subject = subject;
            return this;
        }

        public CloudEventBuilder<T> WithTime(CloudEventTime time)
        {
            this._time = time;
            return this;
        }

        public CloudEvent<T> Build() =>
            new CloudEvent<T>(this._data, this._id, this._source, this._specVersion, this._type)
            {
                Subject = this._subject,
                Time = this._time,
            };
    }
}