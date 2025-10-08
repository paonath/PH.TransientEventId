# Copilot Instructions for TransientEventId

## Project Overview
- **Purpose**: Drop-in replacement for `Microsoft.Extensions.Logging.EventId` without dependencies
- Minimal C# library targeting `netstandard2.0` for maximum compatibility
- Single immutable `readonly struct` with rich API compatibility features
- Designed as a NuGet package for portable logging event identification

## Architecture & Design Patterns
- **API Compatibility**: Deliberately mirrors `Microsoft.Extensions.Logging.EventId` interface
- **Zero Dependencies**: Avoids any external package references for portability
- **Value Semantics**: Immutable struct with proper equality, hashing, and comparison
- **Implicit Conversions**: Supports `int` and `(int, string)` tuple conversions for ergonomics

## Key Files
- `TransientEventId.cs`: Single-file library containing all functionality
- `TransientEventId.csproj`: NuGet package configuration with metadata
- `TransientEventId.sln`: Standard Visual Studio solution structure

## Core API Features
```csharp
// Construction patterns supported
var eventId1 = new TransientEventId(1001, "UserLogin");
var eventId2 = (TransientEventId)1002; // Implicit from int
var eventId3 = (TransientEventId)(1003, "DataAccess"); // Implicit from tuple

// Deconstruction support
var (id, name) = eventId1; // Tuple-style extraction
```

## Build & Development Workflow
- **Build**: `dotnet build` (from project root)
- **Package**: `dotnet pack` (creates NuGet package with metadata)
- **No tests**: Test projects would be separate (not included by design)
- **No dependencies**: Maintain zero external references

## Patterns & Conventions
- **Namespace**: Single `TransientEventId` namespace containing the struct
- **Immutability**: All properties are `readonly` with constructor-only initialization
- **Equality**: Implements `IEquatable<TransientEventId>` with ordinal string comparison
- **Hashing**: Uses `Id` property for `GetHashCode()` (matches EventId behavior)
- **Documentation**: Extensive XML documentation for IntelliSense and API docs

## NuGet Package Considerations
- **Version**: Managed in `.csproj` (currently 1.0.0)
- **Metadata**: Author, description, tags, and repository URL configured
- **License**: BSD 3-Clause (see LICENSE file)
- **Target Audience**: Libraries wanting logging events without Microsoft.Extensions dependency

## Extending Guidelines
- **Maintain Compatibility**: Any changes must preserve API compatibility with EventId
- **Zero Dependencies**: Never add package references
- **Single File**: Keep all functionality in `TransientEventId.cs`
- **Testing**: Create separate test projects if needed (e.g., `TransientEventId.Tests`)

## Integration Scenarios
- **Library Authors**: Use instead of EventId to avoid forcing dependency choices on consumers
- **Legacy Projects**: Drop-in replacement where Microsoft.Extensions.Logging isn't available
- **Portable Code**: Shared code that needs to work across different logging frameworks

## Critical Design Constraints
- Must remain API-compatible with `Microsoft.Extensions.Logging.EventId`
- Cannot introduce any dependencies (maintain `netstandard2.0` baseline)
- Single-file design for easy integration and minimal surface area
