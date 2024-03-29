[![CI](https://github.com/mbernard/CloudEvents.Typed/actions/workflows/ci.yml/badge.svg)](https://github.com/mbernard/CloudEvents.Typed/actions/workflows/ci.yml)
[![CodeQL](https://github.com/mbernard/CloudEvents.StronglyTyped/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/mbernard/CloudEvents.StronglyTyped/actions/workflows/codeql-analysis.yml)
[![Publish NuGet](https://github.com/mbernard/CloudEvents.StronglyTyped/actions/workflows/Publish.yml/badge.svg)](https://github.com/mbernard/CloudEvents.StronglyTyped/actions/workflows/Publish.yml)

An opinionated library that removes some friction of the `CloudNative.CloudEvents` C# SDK by providing a strongly typed implementation of the `CloudEvent<T>` class.
The library also provides multiple utils to manipulate, transform and create CloudEvents.

# Features
* Simplifed CloudEvent creation
* Value providers
* 
# Goals
* Provide good default, but make everything extensible
* More userfriendly to use than the default C# SDK
* Type safety to avoid run-time errors
* Avoid confusion regarding the content of the Data property of a CloudEvent
* Modern design using C# 9 records
* Structural equality
* Intended to be used in your application business domain layer (carries all the metadata you need without the serialization information)
* Very opinionated

# In a nutshell

![cloudevents layers](https://blog.miguelbernard.com/_next/image?url=https%3A%2F%2Fcms.miguelbernard.com%2Fcontent%2Fimages%2F2021%2F07%2FCloudEvents-Layers-1.png&w=3120&q=75)


