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
    class RomanNumeralsArithmeticTests
    {
        [TestCase("X", "X", "XX")]
        [TestCase("MD", "ML", "MMDL")]
        public void RNAdd_ValidRomanNumerals_ReturnsSum(string a, string b, string expected)
        {
            RomanNumeralsArithmetic RNArithmetic = new RomanNumeralsArithmetic();

            string result = RNArithmetic.RNAdd(a, b);

            Assert.AreEqual(expected, result);
        }

        [TestCase("X", "I", "IX")]
        [TestCase("MD", "ML", "CDL")]
        public void RNSubstract_ValidRomanNumerals_ReturnsDifference(string a, string b, string expected)
        {
            RomanNumeralsArithmetic RNArithmetic = new RomanNumeralsArithmetic();

            string result = RNArithmetic.RNSubstract(a, b);

            Assert.AreEqual(expected, result);
        }
    }
}
