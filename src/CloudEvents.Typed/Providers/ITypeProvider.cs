using CloudEvents.Typed.Common;

namespace CloudEvents.Typed.Providers
{
    public interface ITypeProvider
    {
        /// <summary>
        ///     Often this attribute is used for routing, observability, policy enforcement, etc. The format of this is producer
        ///     defined and
        ///     might include information such as the version of the type - see Versioning of CloudEvents in the Primer for more
        ///     information.
        ///     Constraints:
        ///     REQUIRED
        ///     MUST be a non-empty string
        ///     SHOULD be prefixed with a reverse-DNS name.The prefixed domain dictates the organization which defines the
        ///     semantics of this event type.
        ///     Examples
        ///     com.github.pull_request.opened
        ///     com.example.object.deleted.v2
        /// <see cref="https://github.com/cloudevents/spec/blob/master/spec.md#type"/>
        /// </summary>
        /// <typeparam name="T">Type of the event</typeparam>
        /// <returns>Returns a value describing the type of event related to the originating occurrence</returns>
        NonEmptyString GetType<T>();
    }
}