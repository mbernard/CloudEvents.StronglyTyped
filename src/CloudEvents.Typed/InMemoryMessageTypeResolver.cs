using System;
using System.Collections.Generic;

namespace CloudEvents.Typed
{
    public class InMemoryMessageTypeResolver : ICloudEventTypeResolver
    {
        private readonly Dictionary<CloudEventType, Type> _types;

        public InMemoryMessageTypeResolver() => this._types = new Dictionary<CloudEventType, Type>();

        public void RegisterType<T>(CloudEventType cloudEventType) => this.RegisterType(typeof(T), cloudEventType);

        public void RegisterType(Type type, CloudEventType cloudEventType) => this._types.Add(cloudEventType, type);

        public Type GetType(CloudEventType type) => this._types[type];
    }
}