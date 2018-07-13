using System;

namespace RomanNumeralsCalculator.Classes
{
    public class RomanNumeral
    {
        private static RomanNumeralsConverter RNConverter;
        public int decimalNumber;
        public string romanNumeralStr;
        public RomanNumeral(int number)
        {
            RNConverter = new RomanNumeralsConverter();
            romanNumeralStr = RNConverter.ConvertFromIntToRomanNumeral(number);
            decimalNumber = number;           
        }

        public RomanNumeral(string romanSymbols)
        {
            RNConverter = new RomanNumeralsConverter();
            decimalNumber = RNConverter.ConvertFromRomanNumeralToInt(romanSymbols);
            romanNumeralStr = romanSymbols;
        }

        public RomanNumeral(RomanNumeral romanNumeral)
        {
            this.decimalNumber = romanNumeral.decimalNumber;
            this.romanNumeralStr = romanNumeral.romanNumeralStr;
        }

        public static RomanNumeral operator+(RomanNumeral a, RomanNumeral b)
        {
            return new RomanNumeral(RNConverter.ConvertFromIntToRomanNumeral(a.decimalNumber + b.decimalNumber));
        }

        public static RomanNumeral operator-(RomanNumeral a, RomanNumeral b)
        {
            return new RomanNumeral(RNConverter.ConvertFromIntToRomanNumeral(a.decimalNumber - b.decimalNumber));
        }

        public static RomanNumeral operator *(RomanNumeral a, RomanNumeral b)
        {
            return new RomanNumeral(RNConverter.ConvertFromIntToRomanNumeral(a.decimalNumber * b.decimalNumber));
        }

        public static RomanNumeral operator /(RomanNumeral a, RomanNumeral b)
        {
            return new RomanNumeral(RNConverter.ConvertFromIntToRomanNumeral(a.decimalNumber / b.decimalNumber));
        }

        public static RomanNumeral operator %(RomanNumeral a, RomanNumeral b)
        {
            return new RomanNumeral(RNConverter.ConvertFromIntToRomanNumeral(a.decimalNumber % b.decimalNumber));
        }

        public static RomanNumeral operator ^(RomanNumeral a, RomanNumeral b)
        {
            return new RomanNumeral(RNConverter.ConvertFromIntToRomanNumeral((int)Math.Pow(a.decimalNumber, b.decimalNumber)));
        }

        public static RomanNumeral Sqrt(RomanNumeral a)
        {
            int sqrtResult = (int)Math.Sqrt(a.decimalNumber);
            if(sqrtResult*sqrtResult == a.decimalNumber)
            {
                return new RomanNumeral(RNConverter.ConvertFromIntToRomanNumeral((int)Math.Sqrt(a.decimalNumber)));
            }
            else
            {
                throw new Exception($"{a.decimalNumber} doesn't have an integer root!");
            }
        }
    }
}
