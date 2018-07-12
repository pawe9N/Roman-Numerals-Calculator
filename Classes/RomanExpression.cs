using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralsCalculator.Classes
{
    class RomanExpression
    {
        private static string RemoveWhitespace(string expression)
        {
            return new string(expression.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
        }

        public static string AddWhitespacesBetweenOperators(string romanExpression)
        {
            romanExpression = RemoveWhitespace(romanExpression);
            char[] operators = { '+', '-', '*', '/', '%', '^', '√', '(', ')' };
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < romanExpression.Length; i++)
            {
                if(operators.Contains(romanExpression[i]))
                {
                    result.Append($" {romanExpression[i]} ");
                }
                else
                {
                    result.Append(romanExpression[i]);
                }    
            }
            return result.ToString();
        }

        public static string ChangeRomanExpressionToNormalExpression(string romanExpression)
        {
            romanExpression = AddWhitespacesBetweenOperators(romanExpression);
            var words = romanExpression.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string[] operators = { "+", "-", "*", "/", "%", "^", "√", "(", ")" };
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
