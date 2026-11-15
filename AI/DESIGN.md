# Design

## The parts

| File / folder | Namespace | Role |
| --- | --- | --- |
| `AuthenticationException.cs`, `TokenExpiredException.cs` | `Forge.Security.Jwt.Shared` | The exception types of the packages |
| `JwtParserHelper.cs` | `Forge.Security.Jwt.Shared` | JWT parsing helpers |
| `Client/Api/` | `…Shared.Client.Api` | `ITokenizedApiCommunicationService`, `HttpRequestException`, the request and response event arguments |
| `Client/Models/` | `…Shared.Client.Models` | `AdditionalData`, `AuthenticationResponse`, `BooleanResponse`, `DataStore`, `JwtClientAuthenticationCoreOptions`, `ParsedTokenData`, `TokenRequest`, `TokenValidationResponse` |
| `Client/Services/` | `…Shared.Client.Services` | `IAuthenticationService`, `IJwtTokenAuthenticationStateProvider`, `IRefreshTokenService`, `IHostedService`, `IAdditionalData`, `IAuthenticationResponse`, `UserDataEventArgs` |
| `Service/` | `…Shared.Service`, `…Shared.Service.Models` | `IJwtManagementService`; `JwtKeyValuePair`, `JwtRefreshToken`, `JwtTokenResult`, `JwtTokenValidationResultEnum` |
| `Serialization/` | `…Shared.Serialization` | `ISerializationProvider`, `SystemTextJsonSerializer` and its options |
| `Storage/` | `…Shared.Storage` | `IStorage<TValue>`, `MemoryStorage<TValue>` (the default storage) |

## The targets

| Target | Package references |
| --- | --- |
| `netstandard2.0` | `Microsoft.AspNetCore.Components.Authorization` 3.1.32, `Microsoft.AspNetCore.Authorization` 6.0.0, `System.Text.Json` 8.0.5 |
| `net8.0` | `Microsoft.AspNetCore.Components.Authorization` 8.0.0 |
| `net9.0` | `Microsoft.AspNetCore.Components.Authorization` 9.0.0 |
| `net10.0` | `Microsoft.AspNetCore.Components.Authorization` 10.0.0 |
| `net11.0` | `Microsoft.AspNetCore.Components.Authorization` 11.0.0 (added on 2026-11-15) |

`System.IdentityModel.Tokens.Jwt` 8.0.1 on every target.

## The build and the package

- SDK: `Microsoft.NET.Sdk`. `SignAssembly` with `..\.Documents\Forge.snk`.
- `GenerateDocumentationFile`: each target writes its own `Forge.Security.Jwt.Shared.xml` under
  `obj/<configuration>/<target>/`, and the build copies it next to the assembly (since 2026-11-15; before, one
  `DocumentationFile` in the project folder served every target).
- `GeneratePackageOnBuild` for Release; `PackageOutputPath` is `..\.Documents\`.
- The package holds `lib/<target>/Forge.Security.Jwt.Shared.dll` and `.xml` for every target, and at its root `LICENSE`
  (the license is stated as `PackageLicenseExpression` `MIT` since 2026-11-15; the file is still packed), `README.md`
  (`PackageReadmeFile`) and `logo.png` (`PackageIcon`, from 2026-11-15).
- The serialization constructors of the exception types carry `[Obsolete]` with `SYSLIB0051` on `NET8_0_OR_GREATER`, as
  `Exception`'s own (2026-11-15).
- The post-build copy (`xcopy` of the `.dll`, `.pdb`, `.xml` to `$(SolutionDir).Output\<target>\`) is commented out in
  the project file (Zoltán, 2026-11-15).
- The `Scc*` properties (`SAK`) and the `.vspscc` file belong to the TFS binding of the solution.

## Why each choice was made

- **One package version of the framework libraries per target:** the same pattern as in `Forge.Next.Shared`, where the
  reason is recorded: the package does not force a newer framework package on a consumer than its framework's own.
- **Strong naming:** the seven packages of the solution are signed with the same key, so the assemblies have a stable
  identity. Until 2026-11-15 the projects named the password-protected `Forge.pfx`, which only Visual Studio's MSBuild
  can sign with; since then its key pair as `Forge.snk`, which `dotnet build` can use too.
- **`netstandard2.0`:** the oldest target; its ASP.NET Core packages are the 3.1 ones. Since `net6.0` and `net7.0` were
  dropped (2026-11-15), consumers on those get this build.
- **Nullable off:** the commit of 2022-11-18 says "DLL upgrade and nullable removed"; the shared code compiles for
  `netstandard2.0` with C# 7.3.
