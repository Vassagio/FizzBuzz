using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FizzBuzz.Core.Tests
{
    //Number must be positive
    //Any positive number must return as a string
    //Divisible by three returns Fizz
    //Divisible by five returns Buzz
    //Divisible by three and five returns FizzBuzz

    public sealed class NumberConversionServiceTest
    {
        [Fact]
        public void Initialize()
        {
            var service = BuildNumberConversionService();

            Assert.IsAssignableFrom<INumberConversionService>(service);
        }

        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(4, "4")]
        public void Convert_WhenAPositiveInteger_ReturnTheIntegerAsAString(int value, string expected)
        {
            var service = BuildNumberConversionService();

            var result = service.Convert(value);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        public void Convert_WhenANegativeInteger_ReturnEmptyString(int value)
        {
            var service = BuildNumberConversionService();

            var result = service.Convert(value);

            Assert.Empty(result);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        public void Convert_WhenDivisibleByThree_ReturnFizz(int value)
        {
            var service = BuildNumberConversionService();

            var result = service.Convert(value);

            Assert.Equal("Fizz", result);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void Convert_WhenDivisibleByFive_ReturnBuzz(int value)
        {
            var service = BuildNumberConversionService();

            var result = service.Convert(value);

            Assert.Equal("Buzz", result);
        }

        [Theory]
        [InlineData(7)]
        [InlineData(14)]
        public void Convert_WhenDivisibleBySeven_ReturnJazz(int value)
        {
            var service = BuildNumberConversionService();

            var result = service.Convert(value);

            Assert.Equal("Jazz", result);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        public void Convert_WhenDivisibleByThreeAndFive_ReturnFizzBuzz(int value)
        {
            var service = BuildNumberConversionService();

            var result = service.Convert(value);

            Assert.Equal("FizzBuzz", result);
        }

        [Theory]
        [InlineData(21)]
        [InlineData(42)]
        public void Convert_WhenDivisibleByThreeBySeven_ReturnFizzJazz(int value)
        {
            var service = BuildNumberConversionService();

            var result = service.Convert(value);

            Assert.Equal("FizzJazz", result);
        }

        [Theory]
        [InlineData(35)]
        [InlineData(70)]
        public void Convert_WhenDivisibleByFiveBySeven_ReturnBuzzJazz(int value)
        {
            var service = BuildNumberConversionService();

            var result = service.Convert(value);

            Assert.Equal("BuzzJazz", result);
        }


        [Theory]
        [InlineData(105)]
        [InlineData(210)]
        public void Convert_WhenDivisibleByThreeByFiveBySeven_ReturnFizzBuzzJazz(int value)
        {
            var service = BuildNumberConversionService();

            var result = service.Convert(value);

            Assert.Equal("FizzBuzzJazz", result);
        }


        private static INumberConversionService BuildNumberConversionService()
        {
            return new NumberConversionService();
        }
    }
}
