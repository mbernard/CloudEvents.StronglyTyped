using System;
using System.Runtime.Serialization;

namespace MBernard.CloudEvents.StronglyTyped.Tests.Unit.Data
{
    [DataContract(Namespace = "https://miguelbernard.com/cloudevent.stronglytyped", Name = "user.created.v1")]
    public class UserCreatedDataContract
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}