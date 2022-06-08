using RomanNumeralsKata;
using System.Runtime.InteropServices;
using Xunit;

namespace RomanNumeralsKataTests
{
    public class KataTests
    {
        private readonly Kata _kata;

        public KataTests()
        {
            _kata = new Kata();
        }

        [Fact]
        public void returns_nulla()
        {
            var numeral = _kata.GetRomanNumeral(0);

            Assert.Equal("Nulla", numeral);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void returns_one_to_three_letter_Is(int number)
        {
            var numeral = _kata.GetRomanNumeral(number);

            Assert.Contains("I", numeral);
            Assert.True(numeral.Length == number);
        }

        [Fact]
        public void returns_V()
        {
            var numeral = _kata.GetRomanNumeral(5);

            Assert.Equal("V", numeral);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(30)]
        public void returns_one_to_three_letter_Xs(int number)
        {
            var numeral = _kata.GetRomanNumeral(number);

            Assert.Contains("X", numeral);
            Assert.True(numeral.Length == number/10);
        }

        [Fact]
        public void returns_L()
        {
            var numeral = _kata.GetRomanNumeral(50);

            Assert.Equal("L", numeral);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(200)]
        [InlineData(300)]
        public void returns_one_to_three_letter_Cs(int number)
        {
            var numeral = _kata.GetRomanNumeral(number);

            Assert.Contains("C", numeral);
            Assert.True(numeral.Length == number / 100);
        }

        [Fact]
        public void returns_D()
        {
            var numeral = _kata.GetRomanNumeral(500);

            Assert.Equal("D", numeral);
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(2000)]
        [InlineData(3000)]
        public void returns_one_to_three_letter_Ms(int number)
        {
            var numeral = _kata.GetRomanNumeral(number);

            Assert.Contains("M", numeral);
            Assert.True(numeral.Length == number / 1000);
        }
    }

}