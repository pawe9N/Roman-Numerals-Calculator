namespace RomanNumeralsCalculator.Classes
{
    class RomanExpressionSolver
    {
        public static string Solve(string rnExpression)
        {
            string normalExpression = RomanExpression.ChangeRomanExpressionToNormalExpression(rnExpression);
            string rpn = RPN.ConvertToRPN(normalExpression);
            int decimalResult = RPN.SolveRPN(rpn);
            string romanResult = new RomanNumeral(decimalResult).romanNumeralStr;

            return romanResult;
        }
    }
}
