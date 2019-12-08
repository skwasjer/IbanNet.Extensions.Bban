namespace IbanNet.Validation.Results
{
    /// <summary>
    /// The result returned when the national check digits are incorrect.
    /// </summary>
    public class InvalidNationalCheckDigitsResult : ErrorResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidNationalCheckDigitsResult" /> class.
        /// </summary>
        public InvalidNationalCheckDigitsResult() : base("The national check digits are incorrect.")
        {
        }
    }
}
