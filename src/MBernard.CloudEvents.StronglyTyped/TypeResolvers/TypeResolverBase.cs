using System;

using MBernard.CloudEvents.StronglyTyped.Common;
using MBernard.CloudEvents.StronglyTyped.Providers;

namespace MBernard.CloudEvents.StronglyTyped.TypeResolvers
{
    public abstract class TypeResolverBase : ITypeResolver
    {
        private readonly ITypeProvider _typeProvider;

        protected TypeResolverBase(ITypeProvider typeProvider) => this._typeProvider = typeProvider;

        protected TypeResolverBase()
            : this(CloudEventConfiguration.TypeProvider)
        {
        }

        public virtual void RegisterType<T>() => this.RegisterType<T>(this._typeProvider.GetType<T>());

        public virtual void RegisterType<T>(NonEmptyString cloudEventType) =>
            this.RegisterType(typeof(T), cloudEventType);

        public abstract void RegisterType(Type clrType, NonEmptyString cloudEventType);

        public abstract Type ResolveType(NonEmptyString cloudEventType);
    }
}