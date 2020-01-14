#if NETCOREAPP3_0
using System;
using System.Linq;
using FluentAssertions;
using IbanNet.DependencyInjection.ServiceProvider;
using IbanNet.Validation.Rules;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace IbanNet
{
    /// <summary>
    /// Asserts rule is correctly registered using the builder extensions.
    /// </summary>
    public class BbanConfigurationExtensionsTests
    {
        private readonly IIbanValidator _validator;

        public BbanConfigurationExtensionsTests()
        {
            IServiceProvider services = new ServiceCollection()
                // Register rule
                .AddIbanNet(builder => builder.ValidateNationalCheckDigits())
                .BuildServiceProvider();

            _validator = services.GetRequiredService<IIbanValidator>();
        }

        [Fact]
        public void Given_that_rule_is_registered_it_should_be_added_to_options()
        {
            ((IbanValidator)_validator).Options.Rules
                .OfType<HasValidNationalCheckDigitsRule>()
                .Should()
                .HaveCount(1);
        }
    }
}
#endif
