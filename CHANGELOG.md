# Changelog

## v2.2.0

### What's Changed

* feat: add new reusable mod-97,10 implementation by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/70
* refactor: abstract the extraction of check digits and check string by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/63
* refactor: rename calculators to algorithms by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/68
* refactor: IbanNet 6.0 has ICheckDigitsCalculator deprecated, so introduce our own by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/82
* perf: reduce heap allocation by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/84
* perf: aggressive inline extensions/small helpers by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/74
* perf: add benchmark and improve mod97-10 by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/71

### Chores

* chore(deps): replace Moq with NSubstitute by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/64
* test: add explicit usings by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/65
* chore: enable nullable context by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/66
* test: verify the public API by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/67
* style: clean up namespaces after #67 enabled implicit usings by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/69
* chore(deps): Bump Microsoft.Extensions.DependencyInjection from 8.0.0 to 10.0.0 by @dependabot[bot] in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/55
* test: assert that we are actually calling with the expected characters, in order by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/72
* perf: running benchmark was not honoring CLI args to select TFM. by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/73
* ci(deps): Bump actions/download-artifact from 4 to 6 by @dependabot[bot] in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/77
* ci(deps): Bump actions/setup-dotnet from 4 to 5 by @dependabot[bot] in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/76
* ci(deps): Bump actions/setup-java from 4 to 5 by @dependabot[bot] in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/78
* chore(deps): Bump BenchmarkDotNet.Diagnostics.Windows from 0.15.6 to 0.15.7 by @dependabot[bot] in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/75
* chore(deps): bump xunit.runner.visualstudio from 2.4.3 to 2.8.2 by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/83
* ci: only include (s)nupkg files in artifacts from /src folder by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/85


**Full Changelog**: https://github.com/skwasjer/IbanNet.Extensions.Bban/compare/v2.1.1...v2.2.0

## v2.1.1

### What's Changed

* fix: all validators for a country must pass instead of one by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/60
* fix(norway): when the final remainder of mod 11 = 0 it should yield 0 as check digit by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/61

### Chores/CI

* chore(deps): Bump xunit from 2.4.1 to 2.9.3 by @dependabot[bot] in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/59

**Full Changelog**: https://github.com/skwasjer/IbanNet.Extensions.Bban/compare/v2.1.0...v2.1.1


## v2.1.0

### What's Changed

* feat: Add BBAN validators for Poland, Finland, and Czech Republic by @Thorium in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/49
  * Polish (PL) BBAN validator with MOD-10 check digit algorithm
  * Finnish (FI) BBAN validator with Luhn algorithm
  * Czech (CZ) BBAN validator with dual MOD-11 algorithm
 
### Chores

* chore(deps): Bump IbanNet.DependencyInjection.ServiceProvider from 5.18.0 to 5.19.0 by @dependabot[bot] in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/45
* ci(runners): switch to latest runners since `macos-13` is deprecated by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/58
* ci(deps): Bump actions/checkout from 4 to 5 by @dependabot[bot] in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/53
* ci(deps): Bump github/codeql-action from 3 to 4 by @dependabot[bot] in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/54
* ci(deps): Bump actions/upload-artifact from 4 to 5 by @dependabot[bot] in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/51
* ci(deps): Bump gittools/actions from 3.1.1 to 4.2.0 by @dependabot[bot] in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/52
* ci(deps): Bump actions/setup-node from 4 to 6 by @dependabot[bot] in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/50

### New Contributors
* @dependabot[bot] made their first contribution in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/45
* @Thorium made their first contribution in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/49

**Full Changelog**: https://github.com/skwasjer/IbanNet.Extensions.Bban/compare/v2.0.0...v2.1.0

## v2.0.0

### What's Changed

* feat!: adds .NET 8 by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/26
* feat!: removes .NET 6.0 by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/27
* feat!: remove EOL TFM's by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/15
* feat: remove Dutch national check digit validation by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/29

### Chores

* ci: refactor to GH actions by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/14
* doc: add code of conduct [skip ci] by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/16
* doc: add contrib and templates [skip ci] by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/17
* chore: update git config and code style [skip ci] by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/19
* chore(deps): bump FluentAssertions but pin due to license change in v8 by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/20
* chore(deps): bump Moq but pin due to license change and spyware in >= v4.20 by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/22
* chore(deps): remove SourceLink, it is implicitly/automatically enabled nowadays by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/23
* chore(deps): bump Nullable to v1.3.1 by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/24
* chore(deps): bump IbanNet to v5.18.0 by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/25
* ci(macos): replaces .NET Core 3.1 in unit tests with .NET 7 by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/28
* chore: use file scoped namespace by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/30
* style: use collection expressions by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/31
* chore: enable stricter code analysis and address some issues by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/32

**Full Changelog**: https://github.com/skwasjer/IbanNet.Extensions.Bban/compare/v1.0.0...v2.0.0

## v1.0.0

- Add .NET 5.0 and .NET 6.0 target frameworks

## v0.3.0

- Add Dutch BBAN check digit validation, with exception for (former) Postbank account numbers.

## v0.2.0

- Add extension methods

## v0.1.0

- Initial commit / draft
