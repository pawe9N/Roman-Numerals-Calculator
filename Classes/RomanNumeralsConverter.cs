using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralsCalculator.Classes
{
    class RomanNumeralsConverter
    {
        const int NOT_ROMAN_SYMBOL = -1;

        public RomanNumeralsConverter() { }

        public string ConvertFromIntToRomanNumeral(int number)
        {
            if (number > 3999 || number < 1)
            {
                throw new ArgumentException("Invalid number! In roman numeral notation it doesn't exist!");
            }

            StringBuilder romanNumeral = new StringBuilder();

            int[] tableOfSymbolNumbers = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

            while(number > 0)
            {
                int index;
                for(index = 0; index < tableOfSymbolNumbers.Length; index++)
                {
                    if(number >= tableOfSymbolNumbers[index])
                    {
                        break;
                    }
                }

                switch(tableOfSymbolNumbers[index])
                {
                    case 1000: { romanNumeral.Append('M'); number -= 1000; break; }
                    case 900: { romanNumeral.Append("CM"); number -= 900; break; }
                    case 500: { romanNumeral.Append('D'); number -= 500; break; }
                    case 400: { romanNumeral.Append("CD"); number -= 400; break; }
                    case 100: { romanNumeral.Append('C'); number -= 100; break; }
                    case 90: { romanNumeral.Append("XC"); number -= 90; break; }
                    case 50: { romanNumeral.Append('L'); number -= 50; break; }
                    case 40: { romanNumeral.Append("XL"); number -= 40; break; }
                    case 10: { romanNumeral.Append('X'); number -= 10; break; }
                    case 9: { romanNumeral.Append("IX"); number -= 9; break; }
                    case 5: { romanNumeral.Append('V'); number -= 5; break; }
                    case 4: { romanNumeral.Append("IV"); number -= 4; break; }
                    case 1: { romanNumeral.Append('I'); number -= 1; break; }
                }
            }

            return romanNumeral.ToString();
        }

        private int ConvertRomanSymbolToInt(char digit)
        {
            switch(digit)
            {
                case 'M': return 1000;
                case 'D': return 500;
                case 'C': return 100;
                case 'L': return 50;
                case 'X': return 10;
                case 'V': return 5;
                case 'I': return 1;
            }
            return NOT_ROMAN_SYMBOL;
        }

        public int ConvertFromRomanNumeralToInt(string romanNumeral)
        {
            if(string.IsNullOrEmpty(romanNumeral))
            {
                throw new ArgumentException("Roman numeral is empty!");
            }

            int result = 0;

            for(int i=0; i<romanNumeral.Length; i++)
            {
                int digit = ConvertRomanSymbolToInt(romanNumeral[i]);

                if (digit != NOT_ROMAN_SYMBOL)
                {
                    if((i+1 == romanNumeral.Length) || (i+1 < romanNumeral.Length && digit >= ConvertRomanSymbolToInt(romanNumeral[i + 1])))
                    {
                        result += digit;
                    }
                    else
                    {
                        result += ConvertRomanSymbolToInt(romanNumeral[i + 1]) - digit;
                        i++;
                    }
                }
                else
                {
                    throw new ArgumentException("This isn't roman numeral! It has invalid symbols.");
                }
            }

            return result;
        }
    }
}
