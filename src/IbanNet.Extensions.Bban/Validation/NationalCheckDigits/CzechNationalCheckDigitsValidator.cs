using System.Globalization;
using IbanNet.CheckDigits.Calculators;
using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

/// <summary>
/// National check digits validator for Czech Republic (CZ).
/// </summary>
/// <remarks>
/// The Czech BBAN structure is: bbbb pppppp cccccccccc (20 digits)
///   - Bank code: 4 digits (positions 0-3)
///   - Account prefix: 6 digits (positions 4-9, last digit is check digit)
///   - Account number: 10 digits (positions 10-19, last digit is check digit)
/// 
/// This validator checks both the prefix check digit and the account check digit.
/// </remarks>
internal class CzechNationalCheckDigitsValidator : NationalCheckDigitsValidator
{
    public CzechNationalCheckDigitsValidator()
        : base(
            new DummyCalculator(),
            _ => throw new System.NotImplementedException(),
            _ => throw new System.NotImplementedException(),
            "CZ")
    {
    }

    public override bool Validate(string bban)
    {
        if (string.IsNullOrEmpty(bban) || bban.Length != 20)
        {
            return false;
        }

        try
        {
            // Validate prefix check digit
            // Prefix data: positions 4-8 (5 digits)
            // Prefix check digit: position 9 (1 digit)
            // Pass data + '0' to calculator to get expected check digit
            string prefixData = bban.Substring(4, 5) + "0";
            int computedPrefixCheck = CzechCheckDigitsCalculator.ComputePrefixCheckDigit(prefixData.ToCharArray());
            int expectedPrefixCheck = int.Parse(bban.Substring(9, 1), CultureInfo.InvariantCulture);
            
            if (computedPrefixCheck != expectedPrefixCheck)
            {
                return false;
            }

            // Validate account check digit
            // Account data: positions 10-18 (9 digits)
            // Account check digit: position 19 (1 digit)
            // Pass data + '0' to calculator to get expected check digit
            string accountData = bban.Substring(10, 9) + "0";
            int computedAccountCheck = CzechCheckDigitsCalculator.ComputeAccountCheckDigit(accountData.ToCharArray());
            int expectedAccountCheck = int.Parse(bban.Substring(19, 1), CultureInfo.InvariantCulture);
            
            return computedAccountCheck == expectedAccountCheck;
        }
        catch (InvalidTokenException)
        {
            return false;
        }
        catch (System.FormatException)
        {
            return false;
        }
    }

    // Dummy calculator to satisfy base class requirement
    private sealed class DummyCalculator : ICheckDigitsAlgorithm
    {
        public int Compute(char[] value)
        {
            throw new System.NotImplementedException("Czech validator uses custom validation logic");
        }
    }
}
