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
        public void passingOneReturns_I()
        {
            var numeral = _kata.getRomanNumeral(1);

            Assert.Equal("I", numeral);
        }

        [Fact]
        public void passingTwoReturns_II()
        {
            var numeral = _kata.getRomanNumeral(2);

            Assert.Equal("II", numeral);
        }
        [Fact]
        public void passingThreeReturns_III()
        {
            var numeral = _kata.getRomanNumeral(3);

            Assert.Equal("III", numeral);
        }
    }
}
