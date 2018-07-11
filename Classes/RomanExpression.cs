using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralsCalculator.Classes
{
    class RomanExpression
    {
        public static string ChangeRomanExpressionToNormalExpression(string romanExpression)
        {
            var words = romanExpression.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string[] operators = { "+", "-", "*", "/", "%", "(", ")" };
            StringBuilder result = new StringBuilder();
            RomanNumeral RN;

            foreach (string word in words)
            {
                if (!operators.Contains(word))
                {
                    RN = new RomanNumeral(word);
                    result.Append(RN.decimalNumber);
                }
                else
                {
                    result.Append(word);
                }
                result.Append(' ');
            }

            return result.ToString().TrimEnd();
        }
    }
}
