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
[![Tests](https://img.shields.io/appveyor/tests/skwasjer/ibannet-extensions-bban/master.svg)](https://ci.appveyor.com/project/skwasjer/ibannet-extensions-bban/build/tests)
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

## Supported countries

Country                | Code | Support                     | Documentation 
---------------------- | ---- | --------------------------- | -------------
Algeria                |  DZ  | :grey_question: STUDYING    |
Bosnia and Herzegovina |  BA  | :heavy_check_mark: YES      | [CBBH - Instruction on payment account structure](https://www.cbbh.ba/Content/Read/53?lang=en)
Estonia                |  EE  | :grey_question: STUDYING    |
Finland                |  FI  | :grey_question: STUDYING    |
France                 |  FR  | :heavy_check_mark: YES      | [Clé RIB](https://fr.wikipedia.org/wiki/Cl%C3%A9_RIB)
Germany                |  DE  | :exclamation: NOT LIKELY    | [BundesBank - Prüfzifferberechnungsmethoden](https://www.bundesbank.de/resource/blob/603320/16a80c739bbbae592ca575905975c2d0/mL/pruefzifferberechnungsmethoden-data.pdf)
Hungary                |  HU  | :grey_question: STUDYING    |
Italy                  |  IT  | :heavy_check_mark: YES      | [Oracle Cash Management User Guide - Italy](https://docs.oracle.com/cd/E18727_01/doc.121/e13483/T359831T498954.htm#T498993)
Madagascar             |  MG  | :grey_question: STUDYING    |
Mauritania             |  MR  | :heavy_check_mark: YES      | [Clé RIB](https://fr.wikipedia.org/wiki/Cl%C3%A9_RIB)
Netherlands, The       |  NL  | :heavy_check_mark: YES      | [Oracle Cash Management User Guide - Netherlands](https://docs.oracle.com/cd/E18727_01/doc.121/e13483/T359831T498954.htm#T498964)
Monaco                 |  MC  | :heavy_check_mark: YES      | [Clé RIB](https://fr.wikipedia.org/wiki/Cl%C3%A9_RIB)
North Macedonia        |  MK  | :grey_question: STUDYING    |
Norway                 |  NO  | :heavy_check_mark: YES      | [Oracle Cash Management User Guide - Norway](https://docs.oracle.com/cd/E18727_01/doc.121/e13483/T359831T498954.htm#T498969)
Poland                 |  PL  | :grey_question: STUDYING    |
Portugal               |  PT  | :heavy_check_mark: YES      | [Número de Identificação Bancária](https://pt.wikipedia.org/wiki/N%C3%BAmero_de_Identifica%C3%A7%C3%A3o_Banc%C3%A1ria)
San Marino             |  SM  | :heavy_check_mark: YES      | [Oracle Cash Management User Guide - Italy](https://docs.oracle.com/cd/E18727_01/doc.121/e13483/T359831T498954.htm#T498993)
Slovenia               |  SI  | :grey_question: STUDYING    |
Spain                  |  ES  | :grey_question: STUDYING    |

### Contributions

PR's are welcome. Please rebase before submitting, provide test coverage, and ensure the AppVeyor build passes. I will not consider PR's otherwise.

### Contributors

- skwas (author/maintainer)
- [Greybird](https://github.com/Greybird)

### Useful info

- [Changelog](Changelog.md)
- [IbanNet ](https://github.com/skwasjer/IbanNet)
