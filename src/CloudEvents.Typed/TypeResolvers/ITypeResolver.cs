using System;

using CloudEvents.Typed.Common;

namespace CloudEvents.Typed.TypeResolvers
{
    public interface ITypeResolver
    {
        void RegisterType(Type clrType, NonEmptyString cloudEventType);

        Type ResolveType(NonEmptyString cloudEventType);
    }
}