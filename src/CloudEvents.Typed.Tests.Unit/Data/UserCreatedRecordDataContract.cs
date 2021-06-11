using System;
using System.Runtime.Serialization;

namespace CloudEvents.Typed.Tests.Unit.Data
{
    [DataContract(Namespace = "https://miguelbernard.com/cloudevent.typed", Name = "user.created.v1")]
    public record UserCreatedRecordDataContract
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public DateTime BirthDate { get; set; }
    }
}
