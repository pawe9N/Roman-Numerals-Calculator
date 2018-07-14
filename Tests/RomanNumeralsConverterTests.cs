using NUnit.Framework;
using RomanNumeralsCalculator.Classes;
using System;

namespace RomanNumeralsCalculator.Tests
{
    [TestFixture]
    class RomanNumeralsConverterTests
    {
        [TestCase(3999, "MMMCMXCIX")]
        [TestCase(2113, "MMCXIII")]
        [TestCase(11, "XI")]
        [TestCase(407, "CDVII")]
        [TestCase(20, "XX")]
        [TestCase(1, "I")]
        [TestCase(23, "XXIII")]
        [TestCase(545, "DXLV")]
        [TestCase(139, "CXXXIX")]
        [TestCase(49, "XLIX")]
        public void ConvertFromIntToRomanNumeral_ValidInts_ReturnsRomanNumeral(int number, string expected)
        {
            RomanNumeralsConverter conv = new RomanNumeralsConverter();

            string result = conv.ConvertFromIntToRomanNumeral(number);

            Assert.AreEqual(expected, result);
        }

        [TestCase(0)]
        [TestCase(4000)]
        public void ConvertFromIntToRomanNumeral_IntsAreOutOfRange_Throws(int invalidNumber)
        {
            RomanNumeralsConverter conv = new RomanNumeralsConverter();

            var ex = Assert.Throws<ArgumentException>(() => conv.ConvertFromIntToRomanNumeral(invalidNumber));

            StringAssert.Contains("This isn't roman numeral", ex.Message);
        }

        [TestCase("MMMCMXCIX", 3999)]
        [TestCase("MMM", 3000)]
        [TestCase("DCCXCIII", 793)]
        [TestCase("D", 500)]
        [TestCase("CCCXL", 340)]
        [TestCase("CCXII", 212)]
        [TestCase("C", 100)]
        [TestCase("L", 50)]
        [TestCase("V", 5)]
        [TestCase("IV", 4)]
        public void ConvertFromRomanNumeralToInt_ValidRomanNumerals_ReturnsInt(string romanNumeral, int expected)
        {
            RomanNumeralsConverter conv = new RomanNumeralsConverter();

            int result = conv.ConvertFromRomanNumeralToInt(romanNumeral);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ConvertFromRomanNumeralToInt_InvalidRomanNumeral_Throws()
        {
            RomanNumeralsConverter conv = new RomanNumeralsConverter();

            var ex = Assert.Throws<ArgumentException>(() => conv.ConvertFromRomanNumeralToInt("Invalid roman numeral"));

            StringAssert.Contains("invalid symbols", ex.Message);
        }

        [Test]
        public void ConvertFromRomanNumeralToInt_SendEmptyString_Throwsn()
        {
            RomanNumeralsConverter conv = new RomanNumeralsConverter();

            var ex = Assert.Throws<ArgumentException>(() => conv.ConvertFromRomanNumeralToInt(""));

            StringAssert.Contains("is empty", ex.Message);
        }

        [TestCase("XXXX")]
        [TestCase("MXXXX")]
        [TestCase("MMMCCCCVVIII")]
        [TestCase("VV")]
        public void ConvertFromRomanNumeralToInt_SendRomanNumeralsWithTooManyTheSameSymbols_Throws(string invalidRomanNumeral)
        {
            RomanNumeralsConverter conv = new RomanNumeralsConverter();

            var ex = Assert.Throws<ArgumentException>(() => conv.ConvertFromRomanNumeralToInt(invalidRomanNumeral));

            StringAssert.Contains("too many of the same symbols in row", ex.Message);
        }

        [TestCase("XM")]
        [TestCase("IM")]
        [TestCase("VML")]
        [TestCase("IXI")]
        [TestCase("IVI")]
        [TestCase("VIV")]
        public void ConvertFromRomanNumeralToInt_SendRomanNumeralsWithBadSymbolsPosition_Throws(string invalidRomanNumeral)
        {
            RomanNumeralsConverter conv = new RomanNumeralsConverter();

            var ex = Assert.Throws<ArgumentException>(() => conv.ConvertFromRomanNumeralToInt(invalidRomanNumeral));

            StringAssert.Contains("bad format of symbols positions", ex.Message);
        }
    }
}
