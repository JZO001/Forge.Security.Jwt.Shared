# History and decisions

Newest last. Each entry: what was asked or decided, by whom, and why. The entries before 2026-11-15 are reconstructed
from the commit messages and the package files in `..\.Documents\`; a file's date there is when it was last written, not
necessarily when the version was published (see `OPEN.md`).

## 2022 – 2026-07: the versions

| Date | Commit message | Package files in `..\.Documents\` |
| --- | --- | --- |
| 2022-10-13 | Initial commit |  |
| 2022-10-19 | Version 1.5.0 |  |
| 2022-10-24 | Version 1.6.0 |  |
| 2022-11-18 | DLL upgrade and nullable removed |  |
| 2023-01-09 | Minor fixes |  |
| 2023-05-16 | v1.6.3.0 |  |
| 2023-05-25 | Cache improvements | 1.7.0 |
| 2023-12-05 | Update Forge.Security.Jwt.Shared.csproj | 1.7.1 |
| 2024-01-17 | Nuget package upgrade; Version increased | 1.7.2 |
| 2025-03-20 | v1.7.3; v1.7.4 | 1.7.3, 1.7.4 |
| 2025-09-23 | version 1.8.0.0 | 1.8.0, 1.8.1 |
| 2026-02-03 | 1.8.2.0 | 1.8.2 |
| 2026-02-13 | Maintenance | 1.8.3 |
| 2026-07-12 | v1.8.4.0; Add cancellation token support | 1.8.4, 1.8.5 |

## 2026-11-15 – The `net11.0` target

**Zoltán's change:** `net11.0` added to `TargetFrameworks`, in all seven packages of the solution. The version is not
raised.

At the first analysis build the `net11.0` target did not compile: CS0234 (`Microsoft.AspNetCore` does not exist) and
CS0246 (`AuthenticationState`, `AuthenticationStateChangedHandler`), because
`Microsoft.AspNetCore.Components.Authorization` is not part of the .NET 11 shared framework. Since a failing target
fails the package, no package of the solution could be built. Zoltán added
`Microsoft.AspNetCore.Components.Authorization` 11.0.0 for `net11.0` the same day; the target builds since (see
`VERIFICATION.md`). The version is not raised yet.

## 2026-11-15 – The knowledge base

Created at Zoltán's request, from the knowledge base of `Forge.Next.Shared` (`CLAUDE.md`, `AI/`), adapted to this
solution. First planned once for the solution folder; Zoltán decided that each package gets its own, because each
package folder is a git repository of its own. The rules in `CLAUDE.md` were carried over and adapted, not decided one
by one (see `OPEN.md`).

## 2026-11-15 – The package icon: the Forge mark

At Zoltán's request, `logo.png` of `Forge.Next.Shared` is this package's icon: the Forge mark, a hexagon with a smaller,
filled hexagon inside, the two joined by three lines, on a dark rounded tile, 128 by 128 pixels. It sits in the
repository folder, like `LICENSE` and `README.md`, so that each git repository holds what its package needs;
`PackageIcon` names it, and it is packed to the package root. The published versions have no icon; the next version
carries it.

## 2026-11-15 – Packaging analysis

At Zoltán's request, the packaging of the solution was analysed, with `Forge.Next.Shared` as the model: the project
files, the package files in `..\.Documents\`, and builds of a copy of the solution (so that `..\.Documents\` and
`..\.Output\` stayed untouched). The findings for this package are in `OPEN.md`, the checks in `VERIFICATION.md`.
Nothing was fixed in the analysis itself, apart from the icon above; Zoltán's changes after it are recorded in this
file.

## 2026-11-15 – `net6.0` and `net7.0` dropped

**Zoltán's change,** after the analysis listed them as out of support: `net6.0` and `net7.0` left `TargetFrameworks`,
with their reference groups and `SupportedPlatform` conditions. The console harness `..\Testing.Security.Jwt` moved to
`net10.0`. A consumer on `net6.0` or `net7.0` gets the `netstandard2.0` build of the new version. A breaking change for
those consumers, so the version is raised by a minor step (below).

## 2026-11-15 – One XML documentation file per target

At Zoltán's request (a finding of the analysis), as in `Forge.Next.Shared` 3.3.2: `GenerateDocumentationFile` instead of
`DocumentationFile`. The `<None Remove="Forge.Security.Jwt.Shared.xml" />` item and the `.gitignore` entry (`# For
Future`, `Forge.Security.Jwt.Shared.xml`) were removed, and the file in the project folder deleted. Each target writes
its own file under `obj/<configuration>/<target>/`; the build copies it next to the assembly, the post-build step to
`..\.Output\<target>\`, and the pack takes it from there. The `netstandard2.0` folder of the package has its own file
now (155 members, the .NET ones 154); in 1.8.5 it held a .NET target's file.

## 2026-11-15 – 1.8.5 → 1.9.0

At Zoltán's request. A minor version, because `net6.0` and `net7.0` were dropped; besides: `net11.0`, the icon, the XML
documentation per target. For publishing: the packages that reference this one depend on its new version, so it is
published before them.

## 2026-11-15 – The commit before the Release build

The analysis found that `Forge.Security.Jwt.Shared` 1.8.5 and `Forge.Security.Jwt.Service` 1.7.3 were built before their
commits, so their packages name an earlier commit. Zoltán: the published packages stay as they are; from now on the
change is committed before the Release build. A release step in `CLAUDE.md`.

## 2026-11-15 – `Forge.snk` instead of `Forge.pfx`

Zoltán decided to sign with a `.snk` exported from `Forge.pfx`, so that `dotnet build` and `dotnet pack` can build the
packages as well. `..\.Documents\Export-ForgeSnk.ps1` asks for the password of the `.pfx`, and writes
`..\.Documents\Forge.snk` only after checking that the key gives the public key of the signed assemblies (token
`97960309cfe8d317`). Found while testing it: .NET writes `CALG_RSA_KEYX` into the key blob whatever the `KeyNumber`, and
the public key, so the token, would then differ; the script writes `CALG_RSA_SIGN`, as `sn.exe` does. The `.snk` has no
password: whoever has it can sign as Forge. Zoltán ran it the same day. The `.snk` holds a 1024-bit key with
`CALG_RSA_SIGN`, its public key is that of the signed assemblies (token `97960309cfe8d317`), and its private key signs.
All seven projects now name `..\.Documents\Forge.snk` in `AssemblyOriginatorKeyFile`; this also put right the three
projects (`Forge.Security.Jwt.Service.Storage.SqlServer`, `Forge.Wasm.BrowserStorages`,
`Forge.Wasm.BrowserStorages.NewtonSoft.Json`) that named `..\..\.Documents\Forge.pfx`, the `.Documents` folder above the
solution folder. `dotnet build` builds the solution and its packages since, with the same public key token
(`VERIFICATION.md`). `Forge.pfx` stays in `..\.Documents\`; no project names it.

## 2026-11-15 – 1.9.0 → 1.9.1

Zoltán raised the version once more the same day (a patch step); the reason is not recorded. Neither version is
published: on nuget.org 1.8.5 is the latest (checked on 2026-11-15).

## 2026-11-15 – The other findings fixed

Zoltán commented out the post-build `xcopy` target in all seven projects, so a project builds alone as well. Then, at
Zoltán's request, the other findings:
- in this project: `DataStore` and its two properties documented (CS1591); the serialization constructors of
  `AuthenticationException` and `TokenExpiredException` marked `[Obsolete]` with `SYSLIB0051` on `NET8_0_OR_GREATER`, as
  the BCL marks `Exception`'s own: the warning is gone and the constructors stay. Zoltán added `net11.0` to the
  `SupportedPlatform browser` condition.
- in all seven: the license is stated as `PackageLicenseExpression` `MIT` instead of `PackageLicenseFile`; the `LICENSE`
  file is still packed, since the MIT license asks for the notice to go with the copies.

The seven projects build with no warning since (the console harness `..\Testing.Security.Jwt` has eight of its own). Not
changed: a Release build still writes the package of the current version into `..\.Documents\` (`OPEN.md`).
