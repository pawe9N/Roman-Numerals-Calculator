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

        public RomanNumeralsConverter() {}

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
