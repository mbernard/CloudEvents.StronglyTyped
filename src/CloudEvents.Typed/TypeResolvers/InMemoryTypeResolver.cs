using System;
using System.Collections.Concurrent;

using CloudEvents.Typed.Common;
using CloudEvents.Typed.Providers;

namespace CloudEvents.Typed.TypeResolvers
{
    public class InMemoryTypeResolver : TypeResolverBase
    {
        private readonly ConcurrentDictionary<NonEmptyString, Type> _mappings;

        public InMemoryTypeResolver()
            : this(CloudEventConfiguration.TypeProvider)
        {
        }

        public InMemoryTypeResolver(ITypeProvider typeProvider)
            : base(typeProvider) =>
            this._mappings = new ConcurrentDictionary<NonEmptyString, Type>();

        public override void RegisterType(Type clrType, NonEmptyString cloudEventType) =>
            this._mappings.AddOrUpdate(cloudEventType, clrType, (_, _) => clrType);

        public override Type ResolveType(NonEmptyString cloudEventType) => this._mappings[cloudEventType];
    }
}