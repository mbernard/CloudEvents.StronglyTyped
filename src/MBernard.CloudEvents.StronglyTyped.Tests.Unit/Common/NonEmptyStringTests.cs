using System;

using Bogus;

using MBernard.CloudEvents.StronglyTyped.Common;

using Xunit;

namespace MBernard.CloudEvents.StronglyTyped.Tests.Unit.Common
{
    public class NonEmptyStringTests
    {
        [Fact]
        public void GivenANonEmptyString_WhenImplicitCastToString_ThenOriginalStringIsReturned()
        {
            // Given
            var randomString = new Randomizer().String();
            var nonEmptyString = new NonEmptyString(randomString);

            // When
            string actual = nonEmptyString;

            // Then
            Assert.Equal(randomString, actual);
        }

        [Fact]
        public void GivenValidParameter_WhenConstructing_ThenNonEmptyStringIsConstructed()
        {
            // Given
            var randomString = new Randomizer().String();

            // When
            var nonEmptyString = new NonEmptyString(randomString);

            // Then
            Assert.NotNull(nonEmptyString);
        }

        [Fact]
        public void GivenValidParameter_WhenConstructingWithImplicitCast_ThenNonEmptyStringIsConstructed()
        {
            // Given
            var randomString = new Randomizer().String();

            // When
            NonEmptyString nonEmptyString = randomString;

            // Then
            Assert.NotNull(nonEmptyString);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void GivenInvalidParameter_WhenConstructing_ThenThrows(string input) =>

            // Given
            // When
            // Then
            Assert.Throws<ArgumentException>(() => new NonEmptyString(input));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void GivenInvalidParameter_WhenConstructingWithImplicitCast_ThenThrows(string input) =>

            // Given
            // When
            // Then
            Assert.Throws<ArgumentException>(
                () =>
                {
                    NonEmptyString nonEmptyString = input;
                    return nonEmptyString;
                });
    }
}