using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralsCalculator.Classes
{
    class RNP
    {
        private static byte PriorityOfOperation(char operation)
        {
            if (operation == '+' ||
                operation == '-')
            {
                return 1;
            }
            else if (operation == '*' ||
                operation == '/' ||
                operation == '%')
            {
                return 2;
            }
            return byte.MaxValue;
        }

        public static string ConvertToRNP(string expression)
        {
            StringBuilder result = new StringBuilder();

            Stack<char> stc = new Stack<char>();
            
            foreach(char symbol in expression)
            {
                if(symbol >= '0' && symbol <= '9')
                {
                    result.Append(symbol);
                }
                else if(symbol == '(')
                {
                    stc.Push(symbol);
                }
                else if(symbol == ')')
                {
                    while(stc.Peek() != '(')
                    {
                        result.Append(' ');
                        result.Append(stc.Peek());
                        stc.Pop();
                    }
                    stc.Pop();
                }
                else
                {
                    while(stc.Count != 0 && stc.Peek() != '(' 
                        && PriorityOfOperation(symbol) <= PriorityOfOperation(stc.Peek()))
                    {
                        result.Append(' ');
                        result.Append(stc.Peek());
                        stc.Pop();
                    }
                    result.Append(' ');
                    stc.Push(symbol);
                }
            }

            while(stc.Count != 0)
            {
                result.Append(' ');
                result.Append(stc.Peek());
                stc.Pop();
            }

            return result.ToString();
        }

        public static int SolveRNP(string rnp)
        {
            int result = 0;



            return result;
        }
    }
}
