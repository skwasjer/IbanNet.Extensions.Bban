using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private class AllValidators : IEnumerable<NationalCheckDigitsValidator>
    {
        public IEnumerator<NationalCheckDigitsValidator> GetEnumerator()
        {
            yield return new CinNationalCheckDigitsValidator();
            yield return new CleRibNationalCheckDigitsValidator();
            yield return new NorwayMod11ValidatorDigitsValidator();
            yield return new BosniaAndHerzegovinaMod97NationalCheckDigitsValidator();
            yield return new BelgiumMod97NationalCheckDigitsValidator();
            yield return new NibNationalCheckDigitsValidator();
            yield return new PolishNationalCheckDigitsValidator();
            yield return new FinnishNationalCheckDigitsValidator();
            yield return new CzechNationalCheckDigitsValidator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
