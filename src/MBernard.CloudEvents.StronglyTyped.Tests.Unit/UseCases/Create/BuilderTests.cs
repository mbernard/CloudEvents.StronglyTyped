using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bogus;

using FluentAssertions;

using MBernard.CloudEvents.StronglyTyped.Tests.Unit.Data;

using Xunit;

namespace MBernard.CloudEvents.StronglyTyped.Tests.Unit.UseCases.Create
{
    public class BuilderTests
    {
        [Fact]
        public void GivenSimpleDataContractEvent_WhenBuild_ThenCloudEventIsBuiltWithDefaultValues()
        {
            // Given
            var p = new Faker().Person;
            var userCreated = new UserCreatedDataContract
            {
                BirthDate = p.DateOfBirth,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Id = p.Random.Guid()
            };
            
            // When
            var builder = new CloudEventBuilder<UserCreatedDataContract>();
            var actual = builder
                .WithData(userCreated)
                .Build();

            // Then
            actual.Should().NotBeNull();
            actual.Data.Should().Be(userCreated);
        }

    }
}
