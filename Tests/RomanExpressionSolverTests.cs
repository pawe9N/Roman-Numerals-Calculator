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
    class RomanExpressionSolverTests
    {
        [TestCase("( XX + II ) / XI * IV - III", "V")]
        [TestCase("( ( II + II ) * XI ) ", "XLIV")]
        public void Solve_ValidExpression_ReturnValue(string expression, string expected)
        {
            string result = RomanExpressionSolver.Solve(expression);

            Assert.AreEqual(expected, result);
        }
    }
}
