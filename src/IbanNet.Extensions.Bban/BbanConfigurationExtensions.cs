using System;
using IbanNet.DependencyInjection;
using IbanNet.Validation.Rules;

namespace IbanNet
{
    /// <summary>
    /// Configuration extensions for IbanNet to enable national check digit validation.
    /// </summary>
    public static class BbanConfigurationExtensions
    {
        // TODO: maybe add 'experimental' option to opt-in into experimental (still in development/unstable) check digit validators/countries (perhaps specific per country/algo.

        /// <summary>
        /// Enables national check digit validation for a subset of IBAN countries.
        /// </summary>
        /// <param name="builder">The builder instance.</param>
        /// <returns>The <see cref="IIbanNetOptionsBuilder"/> so that additional calls can be chained.</returns>
        public static IIbanNetOptionsBuilder ValidateNationalCheckDigits(this IIbanNetOptionsBuilder builder)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.WithRule(() => new HasValidNationalCheckDigitsRule());
        }
    }
}
