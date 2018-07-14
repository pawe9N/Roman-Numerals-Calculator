using System;
using System.Text;

namespace RomanNumeralsCalculator.Classes
{
    class RomanNumeralsConverter
    {
        const int NOT_ROMAN_SYMBOL = -1;
        const int TOO_MANY_SYMBOLS_IN_ROW = 4;

        public RomanNumeralsConverter() { }

        public string ConvertFromIntToRomanNumeral(int number)
        {
            if (number > 3999 || number < 1)
            {
                throw new ArgumentException("This isn't roman numeral! In roman numeral notation it doesn't exist!");
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

        private void CheckHowManyTimesSymbolInRow(ref int previousSymbol, ref int sameSymbolInRow, int digit)
        {
            if(previousSymbol == digit)
            {
                sameSymbolInRow++;
            }
            else
            {
                sameSymbolInRow = 1;
            }

            if (sameSymbolInRow == TOO_MANY_SYMBOLS_IN_ROW)
            {
                throw new ArgumentException("This isn't roman numeral! It has too many of the same symbols in row!");
            }

            previousSymbol = digit;
        }

        private void CheckIfSymbolCanStandOnItsPosition(int digit, int nextDigit)
        {
            if(digit < nextDigit)
            {
                if(!((digit == 1 && (nextDigit == 5 || nextDigit == 10))
                    || (digit == 10 && (nextDigit == 50 || nextDigit == 100))
                    || (digit == 100 && (nextDigit == 500 || nextDigit == 1000))))
                    {
                        throw new ArgumentException("This isn't roman numeral! It has bad format of symbols positions in it!");
                    }
            }
            else if(digit == nextDigit)
            {
                switch(digit)
                {
                    case 5:
                    case 50:
                    case 500: throw new ArgumentException("This isn't roman numeral! It has too many of the same symbols in row!");
                }
            }
        }

        public int ConvertFromRomanNumeralToInt(string romanNumeralStr)
        {
            if(string.IsNullOrEmpty(romanNumeralStr))
            {
                throw new ArgumentException("This isn't roman numeral! It is empty!");
            }

            int result = 0;
            int previousSymbol = ConvertRomanSymbolToInt(romanNumeralStr[0]);
            int sameSymbolInRow = 1;

            int digit = 0,  nextDigit = 0 ;

            for (int i=0; i< romanNumeralStr.Length; i++)
            {
                digit = ConvertRomanSymbolToInt(romanNumeralStr[i]);

                if (i + 1 < romanNumeralStr.Length)
                {
                    nextDigit = ConvertRomanSymbolToInt(romanNumeralStr[i + 1]);
                    CheckIfSymbolCanStandOnItsPosition(digit, nextDigit);
                }

                if (i>0)
                {
                    CheckHowManyTimesSymbolInRow(ref previousSymbol, ref sameSymbolInRow, digit);
                }


                if (digit != NOT_ROMAN_SYMBOL)
                {
                    if(i+1 == romanNumeralStr.Length ||  digit >= nextDigit)
                    {
                        result += digit;
                    }
                    else
                    {
                        result += nextDigit - digit;
                        i++;

                        if (i + 1 < romanNumeralStr.Length)
                        {
                            previousSymbol = digit;
                            digit = nextDigit;
                            nextDigit = ConvertRomanSymbolToInt(romanNumeralStr[i + 1]);
                            CheckIfSymbolCanStandOnItsPosition(digit, nextDigit);

                            if(previousSymbol == nextDigit)
                            {
                                throw new ArgumentException("This isn't roman numeral! It has bad format of symbols positions in it!");
                            }

                        }

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
