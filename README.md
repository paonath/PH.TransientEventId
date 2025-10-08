# TransientEventId

Minimal, dependency-free struct for logging event identifiers, API-compatible with Microsoft.Extensions.Logging.EventId.

## Overview

**TransientEventId** is a single-file C# library providing a drop-in replacement for `Microsoft.Extensions.Logging.EventId` without any external dependencies. It targets `netstandard2.0` for maximum compatibility and is designed for use in libraries and applications where you want to avoid a dependency on Microsoft.Extensions.Logging.

## Features

- Immutable, readonly struct: `TransientEventId`
- API-compatible with `Microsoft.Extensions.Logging.EventId`
- Implicit conversion from `int` and `(int, string)` tuple
- Deconstruction support: `(id, name) = eventId;`
- Implements `IEquatable<TransientEventId>` and value semantics
- No dependencies, no runtime overhead

## Usage

```csharp
using TransientEventId;

// Explicit construction
var eventId1 = new TransientEventId(1001, "UserLogin");

// Implicit from int
TransientEventId eventId2 = 1002;

// Implicit from tuple
TransientEventId eventId3 = (1003, "DataAccess");

// Deconstruction
var (id, name) = eventId1;
```

### Using TransientEventId with Microsoft.Extensions.Logging

Suppose you have installed the `TransientEventId` package in a project that also references `Microsoft.Extensions.Logging`.
You can define your event identifiers using `TransientEventId` and convert them to `EventId` when logging:


```csharp
using Microsoft.Extensions.Logging;
using TransientEventId;

public static class EventIdExtensions
{
    // Static conversion method
    public static EventId ToEventId(this TransientEventId transient)
        => new EventId(transient.Id, transient.Name);
}

public class MyService
{
    private readonly ILogger<MyService> _logger;

    public MyService(ILogger<MyService> logger)
    {
        _logger = logger;
    }

    // Define your event id using TransientEventId
    private static readonly TransientEventId UserLoginEvent = new(1001, "UserLogin");

    public void Login(string username)
    {
        // Use the static extension method for conversion
        EventId eventId = UserLoginEvent.ToEventId();
        _logger.LogInformation(eventId, "User {Username} logged in.", username);
    }
}
```

## Installation

Add the package from NuGet (coming soon) or reference the single `TransientEventId.cs` file directly in your project.

## Build

Build the library with:

```sh
dotnet build
```

To create a NuGet package:

```sh
dotnet pack
```

## Project Metadata

- Target: `netstandard2.0`
- License: BSD 3-Clause (see LICENSE)
- Author: Paolo Innocenti <paonath@gmail.com>
- Repository: https://github.com/paonath/PH.TransientEventId

## When to Use

- Library authors who want to expose event IDs without forcing a Microsoft.Extensions.Logging dependency
- Legacy or portable codebases
- Any .NET Standard 2.0+ project needing lightweight, structured event identifiers

## Extending

- Keep all logic in `TransientEventId.cs` for portability
- Maintain API compatibility with Microsoft.Extensions.Logging.EventId
- Do not add dependencies
- For tests, use a separate test project (not included)

## License

BSD 3-Clause License — see [LICENSE](LICENSE)