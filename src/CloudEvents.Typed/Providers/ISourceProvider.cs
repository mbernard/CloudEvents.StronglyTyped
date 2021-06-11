using System;

namespace CloudEvents.Typed.Providers
{
    public interface ISourceProvider
    {
        /// <summary>
        ///     Identifies the context in which an event happened. Often this will include information such as the type of the
        ///     event source, the organization publishing the event or the process that produced the event. The exact syntax and
        ///     semantics behind the data encoded in the URI is defined by the event producer.
        ///     Producers MUST ensure that source + id is unique for each distinct event.
        ///     An application MAY assign a unique source to each distinct producer, which makes it easy to produce unique IDs
        ///     since no other producer will have the same source. The application MAY use UUIDs, URNs, DNS authorities or an
        ///     application-specific scheme to create unique source identifiers.
        ///     A source MAY include more than one producer. In that case the producers MUST collaborate to ensure that source + id
        ///     is unique for each distinct event.
        ///     Constraints:
        ///     REQUIRED
        ///     MUST be a non-empty URI-reference
        ///     An absolute URI is RECOMMENDED
        ///     Examples
        ///     Internet-wide unique URI with a DNS authority.
        ///     https://github.com/cloudevents
        ///     mailto:cncf-wg-serverless @lists.cncf.io
        ///     Universally-unique URN with a UUID:
        ///     urn:uuid:6e8bc430-9c3a-11d9-9669-0800200c9a66
        ///     Application-specific identifiers
        ///     /cloudevents/spec/pull/123
        ///     /sensors/tn-1234567/alerts
        ///     1-555-123-4567
        /// <see cref="https://github.com/cloudevents/spec/blob/master/spec.md#source-1"/>
        /// </summary>
        /// <typeparam name="T">Type of the event</typeparam>
        /// <returns>Returns an identifier of the context in which an event happened</returns>
        Uri GetSource<T>();
    }
}