# CloudEvents. Typed

[![CI](https://github.com/mbernard/CloudEvents.Typed/actions/workflows/ci.yml/badge.svg)](https://github.com/mbernard/CloudEvents.Typed/actions/workflows/ci.yml)
[![CodeQL](https://github.com/mbernard/CloudEvents.StronglyTyped/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/mbernard/CloudEvents.StronglyTyped/actions/workflows/codeql-analysis.yml)
[![Publish NuGet](https://github.com/mbernard/CloudEvents.StronglyTyped/actions/workflows/Publish.yml/badge.svg)](https://github.com/mbernard/CloudEvents.StronglyTyped/actions/workflows/Publish.yml)

`CloudEvents. StronglyTyped` is an opinionated library that removes some friction of the `CloudNative.CloudEvents` C# SDK by providing a strongly typed implementation of the `CloudEvent<T>` class.
The library also provides multiple utils to manipulate, transform and create CloudEvents.

# Goals
* Conventions over configuration
* Provide good default, but make everything extensible
* More userfriendly to use than the default C# SDK
* Type safety to avoid run-time errors
* Avoid confusion regarding the content of the Data property of a CloudEvent
* Modern design using C# 9 records
* Structural equality
* Intended to be used and passed around in your application business domain layer (carries all the metadata you need without the serialization information)
* Very opinionated
# In a nutshell

## TODO image here

# Design choices

## `dataContentType` and `dataSchema` are not present on the CloudEvent<T> object

`CloudEvent<T>` is considered a deserialized version of your cloud event; thus, those properties are no longer required as the `Data` property represents an in-memory object. If the event needs to be re-serialized, those values should be included on the non-generic CloudEvent before serializing with the formatter.
