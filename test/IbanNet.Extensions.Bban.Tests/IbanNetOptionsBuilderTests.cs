#if NETCOREAPP_OR_GREATER || NET5_0_OR_GREATER
using System;
using System.Linq;
using FluentAssertions;
using IbanNet.DependencyInjection;
using IbanNet.DependencyInjection.ServiceProvider;
using IbanNet.Extensions.Bban.Validation.Rules;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace IbanNet.Extensions.Bban
{
    /// <summary>
    /// Asserts rule is correctly registered using the builder extensions.
    /// </summary>
    public class IbanNetOptionsBuilderTests
    {
        private readonly IIbanValidator _validator;

        public IbanNetOptionsBuilderTests()
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

        [Fact]
        public void Given_that_builder_is_null_when_adding_rule_it_should_throw()
        {
            IIbanNetOptionsBuilder builder = null;

            // Act
            // ReSharper disable once ExpressionIsAlwaysNull
            Action act = () => builder.ValidateNationalCheckDigits();

            // Assert
            act.Should()
                .Throw<ArgumentNullException>()
                .Which.ParamName.Should()
                .Be(nameof(builder));
        }

        [Fact]
        public void When_registering_rule_it_should_return_builder()
        {
            IIbanNetOptionsBuilder returnedBuilder = null;
            IServiceProvider services = new ServiceCollection()
                // Register rule
                .AddIbanNet(builder =>
                {
                    returnedBuilder = builder.ValidateNationalCheckDigits();
                    returnedBuilder.Should().Be(builder);
                })
                .BuildServiceProvider();

            // Act
            // Resolve to trigger extension  method.
            services.GetRequiredService<IIbanValidator>();
            returnedBuilder.Should().NotBeNull();
        }
    }
}
#endif
