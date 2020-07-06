using System;

namespace CloudEvents.Typed
{
    public interface ICloudEventTypeResolver
    {
        void RegisterType<T>(CloudEventType cloudEventType);

        void RegisterType(Type type, CloudEventType cloudEventType);

        Type GetType(CloudEventType cloudEventType);
    }
}