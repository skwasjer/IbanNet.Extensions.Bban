﻿using IbanNet.CheckDigits.Calculators;
using IbanNet.Extensions.Bban.Extensions;

namespace IbanNet.Extensions.Bban.CheckDigits.Calculators;

/// <summary>
/// Computes the expected national check digits using MOD-11.
/// </summary>
/// <remarks>
/// https://no.wikipedia.org/wiki/MOD11
/// </remarks>
internal class Mod11CheckDigitsCalculator : ICheckDigitsCalculator
{
    public int Compute(char[] value)
    {
        int sum = 0;
        for (int i = 0; i < value.Length; i++)
        {
            char c = value[i];
            if (!c.IsAsciiDigit())
            {
                throw new InvalidTokenException("Expected numeric characters.");
            }

            int weight = 7 - (i + 2) % 6;
            sum += (c - '0') * weight;
        }

        return 11 - sum % 11;
    }
}
