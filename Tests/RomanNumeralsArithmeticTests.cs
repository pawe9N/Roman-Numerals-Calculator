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
        [Test]
        public void AddVitoV_WhenCalled_Return11()
        {
            RomanNumeralsArithmetic calc = new RomanNumeralsArithmetic();

            int result = calc.AddVtoVI();

            Assert.AreEqual(11, result);
        }
    }
}
