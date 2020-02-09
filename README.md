# IbanNet.Extensions.Bban

IbanNet.Extensions.Bban is an [IbanNet](https://github.com/skwasjer/IbanNet) extension library providing functionality to validate a [Basic Bank Account Number](https://en.wikipedia.org/wiki/International_Bank_Account_Number#Basic_Bank_Account_Number) also known as BBAN.

## Installation

Install IbanNet.Extensions.Bban via the Nuget package manager or `dotnet` cli.

```powershell
Install-Package IbanNet.Extensions.Bban
```
```bat
dotnet package add IbanNet.Extensions.Bban
```

---

[![Build status](https://ci.appveyor.com/api/projects/status/aw3hivn9s07hooys/branch/master?svg=true)](https://ci.appveyor.com/project/skwasjer/ibannet-extensions-bban)
[![Tests](https://img.shields.io/appveyor/tests/skwasjer/IbanNet.Extensions.Bban/master.svg)](https://ci.appveyor.com/project/skwasjer/ibannet-extensions-bban/build/tests)
[![codecov](https://codecov.io/gh/skwasjer/IbanNet.Extensions.Bban/branch/master/graph/badge.svg)](https://codecov.io/gh/skwasjer/IbanNet.Extensions.Bban)
[![NuGet](https://img.shields.io/nuget/v/IbanNet.Extensions.Bban.svg)](https://www.nuget.org/packages/IbanNet.Extensions.Bban/) [![NuGet](https://img.shields.io/nuget/dt/IbanNet.Extensions.Bban.svg)](https://www.nuget.org/packages/IbanNet.Extensions.Bban/)

## Configuration

When using IbanNet IoC container [registration extensions](https://github.com/skwasjer/IbanNet/wiki/Dependency-injection), the extension method `ValidateNationalCheckDigits` simplifies enabling BBAN validation.

```csharp
services.AddIbanNet(opts => opts.ValidateNationalCheckDigits());
```

## Creating a validator instance and register rule

When not using an IoC container, you can register the rule manually:

```csharp
var validator = new IbanValidator(
    new IbanValidatorOptions
    {
        Rules =
        {
            new HasValidNationalCheckDigitsRule()
        }
    }
);
```

### Contributions

PR's are welcome. Please rebase before submitting, provide test coverage, and ensure the AppVeyor build passes. I will not consider PR's otherwise.

### Contributors

- skwas (author/maintainer)
- [Greybird](https://github.com/Greybird)

### Useful info

- [Changelog](Changelog.md)
- [IbanNet ](https://github.com/skwasjer/IbanNet)
