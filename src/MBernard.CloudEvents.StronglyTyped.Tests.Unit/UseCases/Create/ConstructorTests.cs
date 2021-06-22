using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MBernard.CloudEvents.StronglyTyped.Common;
using MBernard.CloudEvents.StronglyTyped.Tests.Unit.Data;

using Xunit;

namespace MBernard.CloudEvents.StronglyTyped.Tests.Unit.UseCases.Create
{
    public class ConstructorTests
    {
        [Fact]
        public void GivenNullData_WhenConstruct_ThenExceptionIsThrown()
        {
            // Given
            // When
            // Then
            Assert.Throws<ArgumentNullException>(
                "data",
                () => new CloudEvent<UserCreatedDataContract>(null));
        }

        [Fact]
        public void GivenNullData_WhenConstructWithAllParams_ThenExceptionIsThrown()
        {
            // Given
            // When
            // Then
            Assert.Throws<ArgumentNullException>(
                "data",
                () => new CloudEvent<UserCreatedDataContract>(null, "id"));
        }

    }
}
