﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using IbanNet.Extensions.Bban.Validation.NationalCheckDigits;
using IbanNet.Extensions.Bban.Validation.Results;
using IbanNet.Registry;
using IbanNet.Validation.Results;
using IbanNet.Validation.Rules;

namespace IbanNet.Extensions.Bban.Validation.Rules;

/// <summary>
/// Asserts that the BBAN portion of an IBAN has valid national check digits.
/// </summary>
public class HasValidNationalCheckDigitsRule : IIbanValidationRule
{
    private readonly ReadOnlyDictionary<string, IEnumerable<NationalCheckDigitsValidator>> _nationalCheckDigitsValidators;

    /// <summary>
    /// Initializes a new instance of the <see cref="HasValidNationalCheckDigitsRule" /> class.
    /// </summary>
    public HasValidNationalCheckDigitsRule()
        : this(NationalCheckDigitsValidatorFactory.Create())
    {
    }

    internal HasValidNationalCheckDigitsRule(IDictionary<string, IEnumerable<NationalCheckDigitsValidator>> nationalCheckDigitsValidators)
    {
        _nationalCheckDigitsValidators = new ReadOnlyDictionary<string, IEnumerable<NationalCheckDigitsValidator>>(
            nationalCheckDigitsValidators ?? throw new ArgumentNullException(nameof(nationalCheckDigitsValidators))
        );
    }

    /// <inheritdoc />
    public ValidationRuleResult Validate(ValidationRuleContext context)
    {
        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (!_nationalCheckDigitsValidators.TryGetValue(context.Country!.TwoLetterISORegionName, out IEnumerable<NationalCheckDigitsValidator>? checkDigitsValidators))
        {
            // No national check digits validators found.
            return ValidationRuleResult.Success;
        }

        BbanStructure bbanStructure = context.Country.Bban;
        if (bbanStructure.Position + bbanStructure.Length > context.Value.Length || bbanStructure.Length == 0)
        {
            // BBAN positional data unavailable, or not matching input.
            return new InvalidNationalCheckDigitsResult();
        }

        string bban = context.Value.Substring(bbanStructure.Position, bbanStructure.Length);
        return checkDigitsValidators.Any(validator => validator.Validate(bban))
            ? ValidationRuleResult.Success
            : new InvalidNationalCheckDigitsResult();
    }
}
