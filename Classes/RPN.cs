using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumeralsCalculator.Classes
{
    class RPN
    {
        private static byte PriorityOfOperation(char operation)
        {
            switch(operation)
            {
                case '+':
                case '-': return 1;
                case '*':
                case '/':
                case '%': return 2;
                case '^':
                case '√': return 3;
                default: return byte.MaxValue;
            }
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
                    if(symbol != '√')
                    {
                        result.Append(' ');
                    }
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
            RomanNumeral number1 = new RomanNumeral(numbers.Peek());
            numbers.Pop();
            if (word != "√")
            {
                RomanNumeral number2 = new RomanNumeral(numbers.Peek());
                numbers.Pop();

                switch (word)
                {
                    case "+":
                        numbers.Push((number2 + number1).decimalNumber);
                        break;
                    case "-":
                        numbers.Push((number2 - number1).decimalNumber);
                        break;
                    case "*":
                        numbers.Push((number2 * number1).decimalNumber);
                        break;
                    case "/":
                        numbers.Push((number2 / number1).decimalNumber);
                        break;
                    case "%":
                        numbers.Push((number2 % number1).decimalNumber);
                        break;
                    case "^":
                        numbers.Push((number2 ^ number1).decimalNumber);
                        break;
                }
            }
            else
            {
                numbers.Push(RomanNumeral.Sqrt(number1).decimalNumber);
            }
        }

        public static int SolveRPN(string RPN)
        {
            var words = RPN.Split(' ');
            string[] operators = { "+", "-", "*", "/", "%", "^", "√" };
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
                }
            }

            return numbers.Peek();
        }
    }
}
