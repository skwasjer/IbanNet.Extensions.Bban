using System;
using System.Collections.Generic;
using IbanNet.CheckDigits.Calculators;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

internal abstract class NationalCheckDigitsValidator
{
    private readonly CheckString _checkString;
    private readonly CheckDigits _expectedCheckDigits;
    private readonly ICheckDigitsCalculator _checkDigitsCalculator;

    protected NationalCheckDigitsValidator
    (
        ICheckDigitsCalculator checkDigitsCalculator,
        CheckString checkString,
        CheckDigits expectedCheckDigits,
        params string[] supportedCountryCodes)
    {
        _checkDigitsCalculator = checkDigitsCalculator ?? throw new ArgumentNullException(nameof(checkDigitsCalculator));
        SupportedCountryCodes = supportedCountryCodes ?? throw new ArgumentNullException(nameof(supportedCountryCodes));
        _expectedCheckDigits = expectedCheckDigits ?? throw new ArgumentNullException(nameof(expectedCheckDigits));
        _checkString = checkString ?? throw new ArgumentNullException(nameof(checkString));
    }

    /// <summary>
    /// Gets the country codes this national check digits validator applies to.
    /// </summary>
    public IEnumerable<string> SupportedCountryCodes { get; }

    /// <summary>
    /// Validates a BBAN for valid national check digits.
    /// </summary>
    public virtual bool Validate(string bban)
    {
        string checkString = _checkString.Invoke(bban);

        try
        {
            int computedCheckDigits = _checkDigitsCalculator.Compute(checkString.ToCharArray());
            int checkDigits = _expectedCheckDigits(bban);
            return checkDigits == computedCheckDigits;
        }
        catch (ArgumentException)
        {
            return false;
        }
        catch (InvalidTokenException)
        {
            return false;
        }
    }
}
