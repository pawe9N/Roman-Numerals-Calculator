using NUnit.Framework;
using RomanNumeralsCalculator.Classes;

namespace RomanNumeralsCalculator.Tests
{
    [TestFixture]
    class RomanExpressionSolverTests
    {
        [TestCase("( XX + II ) / XI * IV - III", "V")]
        [TestCase("( ( II + II ) * XI ) ", "XLIV")]
        [TestCase("((II+II)*XI)", "XLIV")]
        [TestCase("      ((II   ^II) * XI     )", "XLIV")]
        [TestCase("√(X-I)", "III")]
        [TestCase("√(IV*(√(X-I))*III)", "VI")]
        [TestCase("√C^III", "M")]
        public void Solve_ValidExpression_ReturnValue(string expression, string expected)
        {
            string result = RomanExpressionSolver.Solve(expression);

            Assert.AreEqual(expected, result);
        }
    }
}
