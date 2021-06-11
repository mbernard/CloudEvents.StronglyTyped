using System;

using CloudEvents.Typed.Common;

namespace CloudEvents.Typed
{
    public class CloudEventBuilder<T>
        where T : notnull
    {
        private readonly T _data;

        private NonEmptyString _id;
        private Uri _source;
        private NonEmptyString? _subject;
        private DateTimeOffset? _time;
        private NonEmptyString _type;

        public CloudEventBuilder(T data)
        {
            this._data = data;
            this._id = CloudEventConfiguration.IdProvider.GetId();
            this._source = CloudEventConfiguration.SourceProvider.GetSource<T>();
            this._type = CloudEventConfiguration.TypeProvider.GetType<T>();
            this._time = DateTimeOffset.UtcNow;
        }

        public CloudEventBuilder<T> WithId(NonEmptyString id)
        {
            this._id = id;
            return this;
        }

        public CloudEventBuilder<T> WithSource(Uri source)
        {
            this._source = source;
            return this;
        }

        public CloudEventBuilder<T> WithType(NonEmptyString type)
        {
            this._type = type;
            return this;
        }

        public CloudEventBuilder<T> WithSubject(NonEmptyString? subject)
        {
            this._subject = subject;
            return this;
        }

        public CloudEventBuilder<T> WithTime(DateTimeOffset? time)
        {
            this._time = time;
            return this;
        }

        public CloudEvent<T> Build() =>
            new(this._data, this._id, this._source, this._type)
            {
                Subject = this._subject,
                Time = this._time
            };
    }
}