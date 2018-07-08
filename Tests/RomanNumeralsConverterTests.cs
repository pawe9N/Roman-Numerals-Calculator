using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RomanNumeralsCalculator.Classes;

namespace RomanNumeralsCalculator.Tests
{
    [TestFixture]
    class RomanNumeralsConverterTests
    {
        [TestCase("MMMCMXCIX", 3999)]
        [TestCase("MMM", 3000)]
        [TestCase("DCCXCIII", 793)]
        [TestCase("D", 500)]
        [TestCase("CD", 400)]
        [TestCase("CCCXL", 340)]
        [TestCase("CCXII", 212)]
        [TestCase("C", 100)]
        [TestCase("XC", 90)]
        [TestCase("L", 50)]
        [TestCase("X", 10)]
        [TestCase("VI", 6)]
        [TestCase("V", 5)]
        [TestCase("IV", 4)]
        public void ConvertFromRomanNumeralToInt_ValidRomanNumerals_ReturnsInt(string romanNumeral, int expected)
        {
            RomanNumeralsConverter conv = new RomanNumeralsConverter();

            int result = conv.ConvertFromRomanNumeralToInt(romanNumeral);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ConvertFromRomanNumeralToInt_InvalidRomanNumeral_ThrowsException()
        {
            RomanNumeralsConverter conv = new RomanNumeralsConverter();

            var ex = Assert.Throws<ArgumentException>(() => conv.ConvertFromRomanNumeralToInt("Invalid roman numeral"));

            StringAssert.Contains("invalid symbols", ex.Message);
        }

        [Test]
        public void ConvertFromRomanNumeralToInt_SendEmptyString_ThrowsException()
        {
            RomanNumeralsConverter conv = new RomanNumeralsConverter();

            var ex = Assert.Throws<ArgumentException>(() => conv.ConvertFromRomanNumeralToInt(""));

            StringAssert.Contains("is empty", ex.Message);
        }
    }
}
