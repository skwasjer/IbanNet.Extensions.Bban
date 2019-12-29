using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using IbanNet.CheckDigits.Calculators;
using IbanNet.Registry;
using IbanNet.Validation.NationalCheckDigits;
using IbanNet.Validation.Results;
using Moq;
using Xunit;

namespace IbanNet.Validation.Rules
{
    public class HasValidNationalCheckDigitsRuleTests
    {
        private readonly HasValidNationalCheckDigitsRule _sut;
        private readonly Mock<NationalCheckDigitsValidator> _checkDigitsValidatorMock;

        public HasValidNationalCheckDigitsRuleTests()
        {
            _checkDigitsValidatorMock = new Mock<NationalCheckDigitsValidator>(Mock.Of<ICheckDigitsCalculator>(), new [] { "ZZ" });

            var checkDigitValidatorStubs = new List<NationalCheckDigitsValidator>
            {
                _checkDigitsValidatorMock.Object
            };

            _sut = new HasValidNationalCheckDigitsRule(checkDigitValidatorStubs);
        }

        [Fact]
        public void Given_that_no_validator_matches_iban_country_when_validating_it_should_pass()
        {
            var context = new ValidationRuleContext("XX000000")
            {
                Country = new IbanCountry("XX")
            };

            // Act
            ValidationRuleResult actual =_sut.Validate(context);

            // Assert
            actual.Should().BeSameAs(ValidationRuleResult.Success);
            _checkDigitsValidatorMock.Verify(m => m.Validate(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void Given_that_bban_structure_length_is_zero_when_validating_it_should_fail()
        {
            var context = new ValidationRuleContext("ZZ000000")
            {
                Country = new IbanCountry("ZZ")
                {
                    Bban =
                    {
                        Length = 0
                    }
                }
            };

            // Act
            ValidationRuleResult actual = _sut.Validate(context);

            // Assert
            actual.Should().Be(new InvalidNationalCheckDigitsResult());
            _checkDigitsValidatorMock.Verify(m => m.Validate(It.IsAny<string>()), Times.Never);
        }

        [Theory]
        [InlineData(0, 10)]
        [InlineData(5, 6)]
        public void Given_that_bban_expected_length_is_greater_than_available_when_validating_it_should_fail(int position, int length)
        {
            var context = new ValidationRuleContext("ZZ000000")
            {
                Country = new IbanCountry("ZZ")
                {
                    Bban =
                    {
                        Position = position,
                        Length = length
                    }
                }
            };

            // Act
            ValidationRuleResult actual = _sut.Validate(context);

            // Assert
            actual.Should().Be(new InvalidNationalCheckDigitsResult());
            _checkDigitsValidatorMock.Verify(m => m.Validate(It.IsAny<string>()), Times.Never);
        }

        [Theory]
        [InlineData(2, 7, "0123456")]
        [InlineData(4, 4, "2345")]
        public void When_validating_it_should_extract_bban_from_iban(int position, int length, string expectedExtractedBban)
        {
            var context = new ValidationRuleContext("ZZ0123456")
            {
                Country = new IbanCountry("ZZ")
                {
                    Bban =
                    {
                        Position = position,
                        Length = length
                    }
                }
            };

            // Act
            ValidationRuleResult actual = _sut.Validate(context);

            // Assert
            _checkDigitsValidatorMock.Verify(m => m.Validate(expectedExtractedBban), Times.Once);
        }

        [Fact]
        public void Given_multiple_check_digit_validators_when_validating_it_should_only_use_those_that_have_matching_country()
        {
            var matchingCheckDigitValidatorMock = new Mock<NationalCheckDigitsValidator>(Mock.Of<ICheckDigitsCalculator>(), new[] { "WW" });

            var checkDigitValidatorStubs = new List<NationalCheckDigitsValidator>
            {
                _checkDigitsValidatorMock.Object,
                matchingCheckDigitValidatorMock.Object
            };

            _checkDigitsValidatorMock
                .Setup(m => m.Validate(It.IsAny<string>()))
                .Returns(true)
                .Verifiable();

            matchingCheckDigitValidatorMock
                .Setup(m => m.Validate(It.IsAny<string>()))
                .Returns(true)
                .Verifiable();

            var sut = new HasValidNationalCheckDigitsRule(checkDigitValidatorStubs);

            var context = new ValidationRuleContext("WW0123456")
            {
                Country = new IbanCountry("WW")
                {
                    Bban =
                    {
                        Position = 2,
                        Length = 7
                    }
                }
            };

            // Act
            ValidationRuleResult actual = sut.Validate(context);

            // Assert
            actual.Should().BeSameAs(ValidationRuleResult.Success);
            matchingCheckDigitValidatorMock.Verify();
            _checkDigitsValidatorMock.Verify(m => m.Validate(It.IsAny<string>()), Times.Never);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Given_multiple_check_digit_validators_matching_the_country_when_validating_it_should_validate_using_any(bool matchesFirst)
        {
            var checkDigitValidatorStubs = new List<NationalCheckDigitsValidator>
            {
                _checkDigitsValidatorMock.Object,
                _checkDigitsValidatorMock.Object
            };

            _checkDigitsValidatorMock
                .SetupSequence(m => m.Validate(It.IsAny<string>()))
                .Returns(matchesFirst)
                .Returns(true);

            var sut = new HasValidNationalCheckDigitsRule(checkDigitValidatorStubs);

            var context = new ValidationRuleContext("ZZ0123456")
            {
                Country = new IbanCountry("ZZ")
                {
                    Bban =
                    {
                        Position = 2,
                        Length = 7
                    }
                }
            };

            // Act
            sut.Validate(context);

            // Assert
            _checkDigitsValidatorMock.Verify(m => m.Validate(It.IsAny<string>()), Times.Exactly(matchesFirst ? 1 : 2));
        }
    }
}
