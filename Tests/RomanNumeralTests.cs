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
    class RomanNumeralTests
    {
        [TestCase("X", "X", "XX")]
        [TestCase("MD", "ML", "MMDL")]
        public void OperatorPlus_ValidRomanNumerals_SetsSum(string a, string b, string expected)
        {
            RomanNumeral romanNumber1 = new RomanNumeral(a);
            RomanNumeral romanNumber2 = new RomanNumeral(b);

            RomanNumeral result = romanNumber1 + romanNumber2;

            Assert.AreEqual(expected, result.romanNumeralStr);
        }

        [TestCase("X", "I", "IX")]
        [TestCase("MD", "ML", "CDL")]
        public void OperatorSubstract_ValidRomanNumerals_SetsDifference(string a, string b, string expected)
        {
            RomanNumeral romanNumber1 = new RomanNumeral(a);
            RomanNumeral romanNumber2 = new RomanNumeral(b);

            RomanNumeral result = romanNumber1 - romanNumber2;

            Assert.AreEqual(expected, result.romanNumeralStr);
        }

        [TestCase("X", "X", "C")]
        [TestCase("V", "IX", "XLV")]
        public void OperatorMultiply_ValidRomanNumerals_SetsProduct(string a, string b, string expected)
        {
            RomanNumeral romanNumber1 = new RomanNumeral(a);
            RomanNumeral romanNumber2 = new RomanNumeral(b);

            RomanNumeral result = romanNumber1 * romanNumber2;

            Assert.AreEqual(expected, result.romanNumeralStr);
        }

        [TestCase("C", "C", "I")]
        [TestCase("M", "XX", "L")]
        public void OperatorDivide_ValidRomanNumerals_SetsQuotient(string a, string b, string expected)
        {
            RomanNumeral romanNumber1 = new RomanNumeral(a);
            RomanNumeral romanNumber2 = new RomanNumeral(b);

            RomanNumeral result = romanNumber1 / romanNumber2;

            Assert.AreEqual(expected, result.romanNumeralStr);
        }

        [TestCase("C", "XC", "X")]
        [TestCase("M", "III", "I")]
        public void OperatorModulo_ValidRomanNumerals_SetsRemainder(string a, string b, string expected)
        {
            RomanNumeral romanNumber1 = new RomanNumeral(a);
            RomanNumeral romanNumber2 = new RomanNumeral(b);

            RomanNumeral result = romanNumber1 % romanNumber2;

            Assert.AreEqual(expected, result.romanNumeralStr);
        }

        [TestCase("X", "II", "C")]
        [TestCase("V", "III", "CXXV")]
        public void OperatorToPowerOf_ValidRomanNumerals_SetsResult(string a, string b, string expected)
        {
            RomanNumeral romanNumber1 = new RomanNumeral(a);
            RomanNumeral romanNumber2 = new RomanNumeral(b);

            RomanNumeral result = romanNumber1 ^ romanNumber2;

            Assert.AreEqual(expected, result.romanNumeralStr);
        }

        [TestCase("IX", "III")]
        [TestCase("C", "X")]
        public void OperatorToPowerOf_ValidRomanNumerals_SetsResult(string a, string expected)
        {
            RomanNumeral romanNumber1 = new RomanNumeral(a);

            RomanNumeral result = RomanNumeral.Sqrt(romanNumber1);

            Assert.AreEqual(expected, result.romanNumeralStr);
        }

        [TestCase("Invalid", "XC")]
        [TestCase("XC", "Invalid")]
        [TestCase("Invalid", "Invalid")]
        [TestCase("Invalid", "")]
        [TestCase("", "Invalid")]
        [TestCase("", "")]
        [TestCase("MMMM", "")]
        [TestCase("IDLM", "")]
        [TestCase("MMM", "M")]
        public void AnyOperator_WithInvalidRomanNumerals_Throws(string a, string b)
        {
            try
            {
                RomanNumeral romanNumber1 = new RomanNumeral(a);
                RomanNumeral romanNumber2 = new RomanNumeral(b);

                var result = romanNumber1 + romanNumber2;

                Assert.Fail("Invalid roman numerals should throw!");
            }
            catch (ArgumentException ex)
            {
                StringAssert.Contains("This isn't roman numeral", ex.Message);
            }

        }
    }
}