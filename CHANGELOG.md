# Changelog

## v2.1.1

## What's Changed

* fix: all validators for a country must pass instead of one by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/60
* fix(norway): when the final remainder of mod 11 = 0 it should yield 0 as check digit by @skwasjer in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/61

### Chores/CI

* chore(deps): Bump xunit from 2.4.1 to 2.9.3 by @dependabot[bot] in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/59

**Full Changelog**: https://github.com/skwasjer/IbanNet.Extensions.Bban/compare/v2.1.0...v2.1.1


## v2.1.0

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

## New Contributors
* @dependabot[bot] made their first contribution in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/45
* @Thorium made their first contribution in https://github.com/skwasjer/IbanNet.Extensions.Bban/pull/49

**Full Changelog**: https://github.com/skwasjer/IbanNet.Extensions.Bban/compare/v2.0.0...v2.1.0

## v2.0.0

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
