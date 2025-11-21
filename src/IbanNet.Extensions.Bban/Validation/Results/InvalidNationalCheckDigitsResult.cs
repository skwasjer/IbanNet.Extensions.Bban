using IbanNet.Validation.Results;

namespace IbanNet.Extensions.Bban.Validation.Results;

/// <summary>
/// The result returned when the national check digits are incorrect.
/// </summary>
public sealed record InvalidNationalCheckDigitsResult : ErrorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidNationalCheckDigitsResult" /> class.
    /// </summary>
    public InvalidNationalCheckDigitsResult() : base("The national check digits are incorrect.")
    {
    }
}
