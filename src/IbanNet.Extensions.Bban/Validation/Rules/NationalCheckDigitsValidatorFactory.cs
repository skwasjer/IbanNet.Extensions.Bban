using System.Collections;
using IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

namespace IbanNet.Extensions.Bban.Validation.Rules;

internal static class NationalCheckDigitsValidatorFactory
{
    /// <summary>
    /// Returns all validators grouped by country code.
    /// </summary>
    public static IDictionary<string, IEnumerable<NationalCheckDigitsValidator>> Create()
    {
        return GroupByCountry(new AllValidators());
    }

    private static Dictionary<string, IEnumerable<NationalCheckDigitsValidator>> GroupByCountry(IEnumerable<NationalCheckDigitsValidator> validators)
    {
        // Group national check digits validators by supported countries and then create dictionary for quick resolving.
        return validators
            .SelectMany(v => v.SupportedCountryCodes
                .Select(c => new
                {
                    validator = v,
                    countryCode = c
                })
            )
            .GroupBy(g => g.countryCode)
            .ToDictionary(
                g => g.Key,
                g => g.Select(kvp => kvp.validator).AsEnumerable()
            );
    }

    private sealed class AllValidators : IEnumerable<NationalCheckDigitsValidator>
    {
        public IEnumerator<NationalCheckDigitsValidator> GetEnumerator()
        {
            yield return new ItalyAndSanMarino();
            yield return new FranceMonacoAndMauritania();
            yield return new Norway();
            yield return new BosniaAndHerzegovina();
            yield return new Belgium();
            yield return new Portugal();
            yield return new Poland();
            yield return new Finland();
            yield return new CzechRepublic.Prefix();
            yield return new CzechRepublic.Account();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
