﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

using Bogus;

using CloudNative.CloudEvents;
using CloudNative.CloudEvents.SystemTextJson;

using FluentAssertions;

using MBernard.CloudEvents.StronglyTyped.Tests.Unit.Data;
using MBernard.CloudEvents.StronglyTyped.TypeResolvers;

using Xunit;

namespace MBernard.CloudEvents.StronglyTyped.Tests.Unit
{
    public class CloudEventTests
    {
        [Fact]
        public void GivenASingleEventSerialized_WhenDeserialize_ThenResultIsEquivalentToSource()
        {
            // Given
            var p = new Faker().Person;
            var userCreatedDataContract = new UserCreatedRecordDataContract
            {
                BirthDate = p.DateOfBirth,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Id = p.Random.Guid()
            };

            var expected = new CloudEventBuilder<UserCreatedRecordDataContract>().WithData(userCreatedDataContract)
                .Build();
            var formatter = new JsonEventFormatter<UserCreatedRecordDataContract>();
            var bytes = formatter.EncodeStructuredModeMessage(expected, out var ct);

            // When
            var e = formatter.DecodeStructuredModeMessage(bytes, ct, new List<CloudEventAttribute>());
            CloudEvent<UserCreatedRecordDataContract> actual = e;

            // Then
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GivenDynamicType_WhenWhen_ThenThen()
        {
            // Given
            var p = new Faker().Person;
            var userCreated = new UserCreatedRecordDataContract
            {
                BirthDate = p.DateOfBirth,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Id = p.Random.Guid()
            };

            var resolver = new InMemoryTypeResolver();
            resolver.RegisterType<UserCreatedRecordDataContract>();

            // serialize
            CloudEvent expected = new CloudEvent<UserCreatedRecordDataContract>(userCreated);
            var formatter = new JsonEventFormatter();
            var bytes = formatter.EncodeStructuredModeMessage(expected, out var ct);
            var json = Encoding.Default.GetString(bytes.ToArray());

            // When
            var e = formatter.DecodeStructuredModeMessage(bytes, ct, new CloudEventAttribute[0]);

            static object Transformer(CloudEvent cloudEvent, Type type)
            {
                var b = ((JsonElement)cloudEvent.Data).GetRawText();
                return JsonSerializer.Deserialize(b, type);
            }

            CloudEvent actual = e.ToStronglyTyped(Transformer, resolver);

            // Then
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void GivenListWithAllSameType_WhenWhen_ThenThen() =>

            // Given
            // When
            // Then
            Assert.True(true);

        [Fact]
        public void GivenListWithDifferentType_WhenWhen_ThenThen() =>

            // Given
            // When
            // Then
            Assert.True(true);

        [Fact]
        public void GivenListWithDifferentTypeButSameCommonAncestor_WhenWhen_ThenThen() =>

            // Given
            // When
            // Then
            Assert.True(true);
    }
}