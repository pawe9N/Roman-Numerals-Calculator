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
    class RNPTests
    {
        [TestCase("1+2*(3-1)/2", "1 2 3 1 - * 2 / +")]
        [TestCase("1+(1*(2+1/(3+1/3)*2+(1*(3-1))))", "1 1 2 1 3 1 3 / + / 2 * + 1 3 1 - * + * +")]
        [TestCase("1+2+3*5-7+8/9", "1 2 + 3 5 * + 7 - 8 9 / +")]
        [TestCase("10+100*2/3*(100-1)", "10 100 2 * 3 / 100 1 - * +")]
        public void ConvertToRNP_ValidExpression_ReturnRNP(string expression, string expected)
        {
            RNP rnp = new RNP();

            string result = rnp.ConvertToRNP(expression);

            Assert.AreEqual(expected, result);
        }
    }
}
