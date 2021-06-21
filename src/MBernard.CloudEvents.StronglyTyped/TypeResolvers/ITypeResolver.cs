using System;

using MBernard.CloudEvents.StronglyTyped.Common;

namespace MBernard.CloudEvents.StronglyTyped.TypeResolvers
{
    public interface ITypeResolver
    {
        void RegisterType(Type clrType, NonEmptyString cloudEventType);

        Type ResolveType(NonEmptyString cloudEventType);
    }
}