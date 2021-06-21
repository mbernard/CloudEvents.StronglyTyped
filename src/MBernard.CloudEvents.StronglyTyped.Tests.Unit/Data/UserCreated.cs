using System;

namespace MBernard.CloudEvents.StronglyTyped.Tests.Unit.Data
{
    public class UserCreated
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
