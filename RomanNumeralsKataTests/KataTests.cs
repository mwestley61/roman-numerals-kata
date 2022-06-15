using System;
using System.IO;
using RomanNumeralsKata;
using System.Runtime.InteropServices;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace RomanNumeralsKataTests
{
    public class KataTests
    {
        private readonly Kata _kata;
        private readonly ITestOutputHelper _testOutputHelper;

        public KataTests(ITestOutputHelper testOutputHelper)
        {
            _kata = new Kata(); 
            _testOutputHelper = testOutputHelper;
            var converter = new Converter(_testOutputHelper);
            Console.SetOut(converter);
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
        public void returns_V_minus_I()
        {
            var numeral = _kata.GetRomanNumeral(4);

            Assert.Equal("IV", numeral);
        }

        [Fact]
        public void returns_V()
        {
            var numeral = _kata.GetRomanNumeral(5);

            Assert.Equal("V", numeral);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void returns_V_plus_one_to_three_letter_Is(int number)
        {
            var numeral = _kata.GetRomanNumeral(number);
            var numberOfIs = number - 5;

            Assert.StartsWith("V", numeral);
            Assert.EndsWith(new string('I', numberOfIs), numeral);
        }

        [Fact]
        public void returns_X_minus_I()
        {
            var numeral = _kata.GetRomanNumeral(9);

            Assert.Equal("IX", numeral);
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

        [Theory]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        public void returns_X_plus_one_to_three_letter_Is(int number)
        {
            var numeral = _kata.GetRomanNumeral(number);
            var numberOfIs = number - 10;

            Assert.StartsWith("X", numeral);
            Assert.EndsWith(new string('I', numberOfIs), numeral);
        }

        [Fact]
        public void returns_L_minus_X()
        {
            var numeral = _kata.GetRomanNumeral(40);

            Assert.Equal("XL", numeral);
        }
        
        [Fact]
        public void returns_L()
        {
            var numeral = _kata.GetRomanNumeral(50);

            Assert.Equal("L", numeral);
        }

        [Theory]
        [InlineData(51)]
        [InlineData(52)]
        [InlineData(53)]
        public void returns_L_plus_one_to_three_letter_Is(int number)
        {
            var numeral = _kata.GetRomanNumeral(number);
            var numberOfIs = number - 50;

            Assert.StartsWith("L", numeral);
            Assert.EndsWith(new string('I', numberOfIs), numeral);
        }

        [Fact]
        public void returns_C_minus_X()
        {
            var numeral = _kata.GetRomanNumeral(90);

            Assert.Equal("XC", numeral);
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

        [Theory]
        [InlineData(101)]
        [InlineData(102)]
        [InlineData(103)]
        public void returns_C_plus_one_to_three_letter_Is(int number)
        {
            var numeral = _kata.GetRomanNumeral(number);
            var numberOfIs = number - 100;

            Assert.StartsWith("C", numeral);
            Assert.EndsWith(new string('I', numberOfIs), numeral);
        }

        [Fact]
        public void returns_D_minus_C()
        {
            var numeral = _kata.GetRomanNumeral(400);

            Assert.Equal("CD", numeral);
        }

        [Fact]
        public void returns_D()
        {
            var numeral = _kata.GetRomanNumeral(500);

            Assert.Equal("D", numeral);
        }

        [Theory]
        [InlineData(501)]
        [InlineData(502)]
        [InlineData(503)]
        public void returns_D_plus_one_to_three_letter_Is(int number)
        {
            var numeral = _kata.GetRomanNumeral(number);
            var numberOfIs = number - 500;

            Assert.StartsWith("D", numeral);
            Assert.EndsWith(new string('I', numberOfIs), numeral);
        }

        [Fact]
        public void returns_M_minus_C()
        {
            var numeral = _kata.GetRomanNumeral(900);

            Assert.Equal("CM", numeral);
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

        [Theory]
        [InlineData(1001)]
        [InlineData(1002)]
        [InlineData(1003)]
        public void returns_M_plus_one_to_three_letter_Is(int number)
        {
            var numeral = _kata.GetRomanNumeral(number);
            var numberOfIs = number - 1000;

            Assert.StartsWith("M", numeral);
            Assert.EndsWith(new string('I', numberOfIs), numeral);
        }
    }
    public class Converter : TextWriter
        {   
        ITestOutputHelper _output;
        public Converter(ITestOutputHelper output)
        {
            _output = output;
        }
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
        public override void WriteLine(string message)
        {
            _output.WriteLine(message);
        }
        public override void WriteLine(string format, params object[] args)
        {
            _output.WriteLine(format, args);
        }

        public override void Write(char value)
        {
            throw new NotSupportedException("This text writer only supports WriteLine(string) and WriteLine(string, params object[]).");
        }
    }
}