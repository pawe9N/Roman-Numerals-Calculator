using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralsCalculator.Classes
{
    class RomanExpressionSolver
    {
        public static int Solve(string rnExpression)
        {
            string normalExpression = RomanExpression.ChangeRomanExpressionToNormalExpression(rnExpression);
            string rnp = RNP.ConvertToRNP(normalExpression);
            int result = RNP.SolveRNP(rnp);

            return result;
        }
    }
}
