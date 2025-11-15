using IbanNet.Extensions.Bban.Validation.Rules;

namespace IbanNet.Extensions.Bban.PublicApi;

public sealed class PublicApiTests : PublicApiSpec
{
    public PublicApiTests()
        : base(typeof(HasValidNationalCheckDigitsRule))
    {
    }
}
