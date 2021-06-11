using System;

namespace CloudEvents.Typed.Tests.Unit.Data
{
    public class UserCreated
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
