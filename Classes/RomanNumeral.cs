using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static RomanNumeral operator+(RomanNumeral a, RomanNumeral b)
        {
            return new RomanNumeral(RNConverter.ConvertFromIntToRomanNumeral(a.decimalNumber + b.decimalNumber));
        }

        public static RomanNumeral Add(RomanNumeral a, RomanNumeral b)
        {
            return a + b;
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
    }
}
