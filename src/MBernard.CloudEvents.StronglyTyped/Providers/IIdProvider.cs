using MBernard.CloudEvents.StronglyTyped.Common;

namespace MBernard.CloudEvents.StronglyTyped.Providers
{
    public interface IIdProvider
    {
        /// <summary>
        ///     Producers MUST ensure that source + id is unique for each distinct event. If a duplicate event is re-sent (e.g. due
        ///     to a network error) it MAY have the same id. Consumers MAY assume that Events with identical source and id are
        ///     duplicates.
        ///     Constraints:
        ///     REQUIRED
        ///     MUST be a non-empty string
        ///     MUST be unique within the scope of the producer
        ///     Examples:
        ///     An event counter maintained by the producer
        ///     A UUID
        /// <see cref="https://github.com/cloudevents/spec/blob/master/spec.md#id"/>
        /// </summary>
        /// <returns>Returns a string that identifies the event. </returns>
        public NonEmptyString GetId();
    }
}