using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralsCalculator.Classes
{
    class RPN
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

        public static string ConvertToRPN(string expression)
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
                else if(symbol != ' ')
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

        private static void ChooseOperator(string word, ref Stack<int> numbers)
        {
            int number1, number2;
            switch (word)
            {
                case "+":
                    number1 = numbers.Peek();
                    numbers.Pop();
                    number2 = numbers.Peek();
                    numbers.Pop();
                    numbers.Push(number2 + number1);
                    break;
                case "-":
                    number1 = numbers.Peek();
                    numbers.Pop();
                    number2 = numbers.Peek();
                    numbers.Pop();
                    numbers.Push(number2 - number1);
                    break;
                case "*":
                    number1 = numbers.Peek();
                    numbers.Pop();
                    number2 = numbers.Peek();
                    numbers.Pop();
                    numbers.Push(number2 * number1);
                    break;
                case "/":
                    number1 = numbers.Peek();
                    numbers.Pop();
                    number2 = numbers.Peek();
                    numbers.Pop();
                    numbers.Push(number2 / number1);
                    break;
                case "%":
                    number1 = numbers.Peek();
                    numbers.Pop();
                    number2 = numbers.Peek();
                    numbers.Pop();
                    numbers.Push(number2 % number1);
                    break;
            }
        }

        public static int SolveRPN(string RPN)
        {
            var words = RPN.Split(' ');
            string[] operators = { "+", "-", "*", "/", "%" };
            Stack<int> numbers = new Stack<int>();

            foreach (string word in words)
            {
                if (!operators.Contains(word))
                {
                    int number = Int32.Parse(word);
                    numbers.Push(number);
                }
                else
                {
                    ChooseOperator(word, ref numbers);
                    RomanNumeral rn = new RomanNumeral(numbers.Peek());
                }
            }

            return numbers.Peek();
        }
    }
}
