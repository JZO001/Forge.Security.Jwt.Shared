# Forge.Security.Jwt.Shared

**The foundation of JWT authentication for modern .NET applications.**

*Shared contracts. Reusable models. Unified authentication.*

[![NuGet](https://img.shields.io/nuget/v/Forge.Security.Jwt.Shared?logo=nuget&label=NuGet)](https://www.nuget.org/packages/Forge.Security.Jwt.Shared)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Forge.Security.Jwt.Shared?logo=nuget&label=Downloads)](https://www.nuget.org/packages/Forge.Security.Jwt.Shared)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/JZO001/Forge.Security.Jwt.Shared/blob/main/LICENSE)
[![GitHub Stars](https://img.shields.io/github/stars/JZO001/Forge.Security.Jwt.Shared?style=flat&logo=github)](https://github.com/JZO001/Forge.Security.Jwt.Shared/stargazers)

![.NET Standard 2.0](https://img.shields.io/badge/.NET_Standard-2.0-512BD4?logo=dotnet&logoColor=white)
![.NET 8](https://img.shields.io/badge/.NET-8-512BD4?logo=dotnet&logoColor=white)
![.NET 9](https://img.shields.io/badge/.NET-9-512BD4?logo=dotnet&logoColor=white)
![.NET 10](https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet&logoColor=white)
![.NET 11](https://img.shields.io/badge/.NET-11-512BD4?logo=dotnet&logoColor=white)
![C%23](https://img.shields.io/badge/C%23-512BD4?logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-512BD4?logo=dotnet&logoColor=white)
![Blazor](https://img.shields.io/badge/Blazor-512BD4?logo=blazor&logoColor=white)

Forge.Security.Jwt.Shared is a reusable .NET library providing shared interfaces, models, default implementations and JSON Web Token (JWT) parsing utilities for the Forge.Security.Jwt ecosystem.

It provides common building blocks for token-based authentication and authorization across client and server applications, including ASP.NET Core and Blazor, without requiring each application to define its own shared authentication contracts.

## Features

- Shared interfaces, models and default implementations for Forge JWT libraries.
- Common client-side and server-side authentication contracts.
- JWT payload decoding and claims extraction through `JwtParserHelper`.
- Role claim extraction, including array-valued role claims represented by `ClaimTypes.Role`.
- Parsing success reporting through an optional `out bool` overload.
- Shared authentication and token-expiration exception types.
- Common abstractions for storage and serialization within the Forge JWT ecosystem.
- Reusable foundation for claims-based authentication and single sign-on (SSO) solutions built with related Forge libraries.
- Multi-targeted, strongly named library with an MIT license.

## Supported Frameworks

| Framework | Target framework moniker |
| --- | --- |
| .NET Standard 2.0 | `netstandard2.0` |
| .NET 8 | `net8.0` |
| .NET 9 | `net9.0` |
| .NET 10 | `net10.0` |
| .NET 11 | `net11.0` |

These are the target frameworks declared by the repository's project file. Check the [NuGet package](https://www.nuget.org/packages/Forge.Security.Jwt.Shared) for the frameworks available in a particular published version.

## Installing

Install the package using the .NET CLI:

```bash
dotnet add package Forge.Security.Jwt.Shared
```

Alternatively, add the following package reference to your `.csproj` file, replacing `x.x.x` with the desired version:

```xml
<PackageReference Include="Forge.Security.Jwt.Shared" Version="x.x.x" />
```

You can also install it using the built-in NuGet Package Manager in Visual Studio or the Package Manager Console:

```powershell
Install-Package Forge.Security.Jwt.Shared
```

## Usage: Extract Claims from a JWT

The `JwtParserHelper` class provides a convenient way to decode a JWT payload into standard .NET `Claim` objects. For example, in a method that receives an access token as a string:

```csharp
using Forge.Security.Jwt.Shared;
using System;
using System.Collections.Generic;
using System.Security.Claims;

static void ReadClaims(string accessToken)
{
    List<Claim> claims = JwtParserHelper.ParseClaimsFromJwt(
        accessToken, out bool isSuccess);

    if (!isSuccess)
    {
        Console.WriteLine("Unable to parse the JWT payload.");
        return;
    }

    // Inspect decoded claim types without logging sensitive claim values.
    foreach (Claim claim in claims)
    {
        Console.WriteLine(claim.Type);
    }
}
```

A simpler overload is also available:

```csharp
var claims = JwtParserHelper.ParseClaimsFromJwt(accessToken);
```

> **Security note:** Parsing is not token validation. `JwtParserHelper` decodes the JWT payload but does not verify its signature, issuer, audience or expiration. A successful parse does not establish that a token is authentic or trusted. Validate tokens using appropriate authentication middleware or token-validation APIs before trusting their claims or making authorization decisions.

## Architecture

Forge.Security.Jwt.Shared is the common foundation of the Forge JWT ecosystem. Client and server implementations use shared contracts, while specialized packages provide storage integrations.

```text
Forge.Security.Jwt.Client.Storage.Browser    Forge.Security.Jwt.Service.Storage.SqlServer
                    |                                            |
       Forge.Security.Jwt.Client                    Forge.Security.Jwt.Service
                    |                                            |
                    +----------------------+---------------------+
                                           |
                             Forge.Security.Jwt.Shared
                     Interfaces | Models | JWT parsing utilities
```

This diagram illustrates the conceptual layering of the core JWT packages, rather than an exhaustive dependency graph. The shared package is not a standalone authentication server or a complete SSO implementation.

## Related Projects

| Project | Purpose | NuGet |
| --- | --- | --- |
| [Forge.Security.Jwt.Client](https://github.com/JZO001/Forge.Security.Jwt.Client) | Client-side JWT authentication | [Package](https://www.nuget.org/packages/Forge.Security.Jwt.Client) |
| [Forge.Security.Jwt.Service](https://github.com/JZO001/Forge.Security.Jwt.Service) | Server-side JWT authentication | [Package](https://www.nuget.org/packages/Forge.Security.Jwt.Service) |
| [Forge.Security.Jwt.Client.Storage.Browser](https://github.com/JZO001/Forge.Security.Jwt.Client.Storage.Browser) | Browser-based client storage | [Package](https://www.nuget.org/packages/Forge.Security.Jwt.Client.Storage.Browser) |
| [Forge.Security.Jwt.Service.Storage.SqlServer](https://github.com/JZO001/Forge.Security.Jwt.Service.Storage.SqlServer) | SQL Server storage integration | [Package](https://www.nuget.org/packages/Forge.Security.Jwt.Service.Storage.SqlServer) |
| [Forge.Wasm.BrowserStorages](https://github.com/JZO001/Forge.Wasm.BrowserStorages) | Browser storage utilities for Blazor WebAssembly | [Package](https://www.nuget.org/packages/Forge.Wasm.BrowserStorages) |
| [Forge.Wasm.BrowserStorages.NewtonSoft.Json](https://github.com/JZO001/Forge.Wasm.BrowserStorages.NewtonSoft.Json) | Newtonsoft.Json serialization integration for browser storage | [Package](https://www.nuget.org/packages/Forge.Wasm.BrowserStorages.NewtonSoft.Json) |
| [Forge.Yoda](https://github.com/JZO001/Forge.Yoda) | Related Forge project | [Package](https://www.nuget.org/packages/Forge.Yoda) |

Explore more [Forge projects on GitHub](https://github.com/JZO001?tab=repositories).

## Keywords

JWT, JSON Web Token, JWT authentication, token-based authentication, authorization, claims-based authentication, JWT parser, JWT claims extraction, security, single sign-on (SSO), .NET, C#, ASP.NET Core, Blazor, Blazor WebAssembly, shared library, authentication library, NuGet, Forge Security.

## License

Distributed under the [MIT License](https://github.com/JZO001/Forge.Security.Jwt.Shared/blob/main/LICENSE).

## Support the Project

**Forge.Security.Jwt.Shared** is developed and maintained independently and provided free of charge.

If this library saves you development time, helps your business, or makes your daily work easier, please consider giving the repository a ⭐ on GitHub.

- ⭐ Star the repository on GitHub
- 💬 Share your feedback and experiences
- 🐛 Report bugs and suggest improvements
- 📢 Recommend the library to other developers
- ☕ Consider sponsoring its continued development

Even a simple GitHub star is a meaningful way to say thank you.

**Open source is free to use, but it is not free to create and maintain.**
