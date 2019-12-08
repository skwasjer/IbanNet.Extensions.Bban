using System.Collections.Generic;
using System.Linq;
using IbanNet.Validation.NationalCheckDigits;
using IbanNet.Validation.Results;

namespace IbanNet.Validation.Rules
{
    /// <summary>
    /// Asserts that the BBAN portion of an IBAN has valid national check digits.
    /// </summary>
    public class HasValidNationalCheckDigitsRule : IIbanValidationRule
    {
        private readonly IReadOnlyDictionary<string, IEnumerable<NationalCheckDigitsValidator>> _nationalCheckDigitsValidators;

        /// <summary>
        /// Initializes a new instance of the <see cref="HasValidNationalCheckDigitsRule" /> class.
        /// </summary>
        public HasValidNationalCheckDigitsRule()
            : this(
                new List<NationalCheckDigitsValidator>
                {
                    new CinNationalCheckDigitsValidator(),
                    new CleRibNationalCheckDigitsValidator(),
                    new NorwayMod11ValidatorDigitsValidator(),
                    new BosniaAndHerzegovinaMod97NationalCheckDigitsValidator()
                }
            )
        {
        }

        // For access by unit tests.
        internal HasValidNationalCheckDigitsRule(IEnumerable<NationalCheckDigitsValidator> nationalCheckDigitsValidators)
        {
            // Group national check digits validators by supported countries and then create dictionary for quick resolving.
            _nationalCheckDigitsValidators = nationalCheckDigitsValidators
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
                    g => (IEnumerable<NationalCheckDigitsValidator>)g.Select(kvp => kvp.validator).ToList()
                );
        }

        /// <inheritdoc />
        public ValidationRuleResult Validate(ValidationRuleContext context)
        {
            if (!_nationalCheckDigitsValidators.TryGetValue(context.Country.TwoLetterISORegionName, out IEnumerable<NationalCheckDigitsValidator> checkDigitsValidators))
            {
                // No national check digits validators found.
                return ValidationRuleResult.Success;
            }

            string bban = context.Value.Substring(4, context.Country.Bban.Length);
            return checkDigitsValidators.Any(validator => validator.Validate(bban))
                ? ValidationRuleResult.Success
                : new InvalidNationalCheckDigitsResult();
        }
    }
}
