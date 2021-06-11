using System;
using System.Reflection;
using System.Runtime.Serialization;

using CloudEvents.Typed.Common;

namespace CloudEvents.Typed.Providers
{
    public class DataContractProvider : ISourceProvider, ITypeProvider
    {
        public Uri GetSource<T>()
        {
            var att = GetDataContractAttribute<T>();

            if (att.Namespace is null)
            {
                throw new InvalidOperationException(
                    "DataContractAttribute must have the 'Namespace' property set to a valid Uri");
            }

            return new Uri(att.Namespace);
        }

        public NonEmptyString GetType<T>()
        {
            var att = GetDataContractAttribute<T>();

            if (att.Name is null)
            {
                throw new InvalidOperationException(
                    "DataContractAttribute must have the 'Name' property set to a non-empty string");
            }

            return att.Name;
        }

        private static DataContractAttribute GetDataContractAttribute<T>()
        {
            var att = typeof(T).GetCustomAttribute<DataContractAttribute>(true);
            if (att is null)
            {
                throw new InvalidOperationException($"Type '{typeof(T)}' must be decorated with DataContractAttribute");
            }

            return att;
        }
    }
}