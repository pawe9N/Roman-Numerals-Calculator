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
    class RomanExpressionTests
    {
        [TestCase("XX + V", "20 + 5")]
        [TestCase("M * XXIX / CD - V % XL", "1000 * 29 / 400 - 5 % 40")]
        [TestCase("XX + II / XI * IV - III % III", "20 + 2 / 11 * 4 - 3 % 3")]
        [TestCase("( XX + II ) / XI * IV - III % III", "( 20 + 2 ) / 11 * 4 - 3 % 3")]
        public void ChangeRomanExpressionToNormalExpression_ValidExpression_ReturnNormalExpression(string expression, string expected)
        {
            string result = RomanExpression.ChangeRomanExpressionToNormalExpression(expression);

            Assert.AreEqual(expected, result);
        }

        [TestCase("XX+V", "XX + V")]
        [TestCase("XX                   + V", "XX + V")]
        public void AddWhitespacesBetweenOperators_ValidExpression_ReturnExpressionWithWhitespaces(string expression, string expected)
        {
            string result = RomanExpression.AddWhitespacesBetweenOperators(expression);

            Assert.AreEqual(expected, result);
        }
    }
}
