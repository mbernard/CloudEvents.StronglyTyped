using System;

using MBernard.CloudEvents.StronglyTyped.Common;

namespace MBernard.CloudEvents.StronglyTyped
{
    public class CloudEventBuilder<T>
        where T : notnull
    {
        private T? _data;
        private Func<NonEmptyString> _id;
        private Func<Uri> _source;
        private Func<NonEmptyString?> _subject;
        private Func<DateTimeOffset?> _time;
        private Func<NonEmptyString> _type;

        public CloudEventBuilder()
        {
            this._id = () => CloudEventConfiguration.IdProvider.GetId();
            this._source = () => CloudEventConfiguration.SourceProvider.GetSource<T>();
            this._type = () => CloudEventConfiguration.TypeProvider.GetType<T>();
            this._time = () => CloudEventConfiguration.TimeProvider.GetTime();
            this._subject = () => CloudEventConfiguration.SubjectProvider.GetSubject();
        }

        public CloudEventBuilder<T> WithData(T data)
        {
            this._data = data;
            return this;
        }

        public CloudEventBuilder<T> WithId(NonEmptyString id)
        {
            this._id = () => id;
            return this;
        }

        public CloudEventBuilder<T> WithSource(Uri source)
        {
            this._source = () => source;
            return this;
        }

        public CloudEventBuilder<T> WithType(NonEmptyString type)
        {
            this._type = () => type;
            return this;
        }

        public CloudEventBuilder<T> WithSubject(NonEmptyString? subject)
        {
            this._subject = () => subject;
            return this;
        }

        public CloudEventBuilder<T> WithTime(DateTimeOffset? time)
        {
            this._time = () => time;
            return this;
        }

        public CloudEvent<T> Build() =>
            new(this._data!, this._id(), this._source(), this._type())
            {
                Subject = this._subject(),
                Time = this._time()
            };
    }
}