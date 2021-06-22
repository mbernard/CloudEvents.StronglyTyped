using MBernard.CloudEvents.StronglyTyped.Common;

namespace MBernard.CloudEvents.StronglyTyped.Providers
{
    public interface ISubjectProvider
    {
        NonEmptyString? GetSubject();
    }
}