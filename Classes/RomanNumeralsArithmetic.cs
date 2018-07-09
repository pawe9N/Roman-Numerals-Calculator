using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralsCalculator.Classes
{
    public class RomanNumeralsArithmetic
    {
        private RomanNumeralsConverter RNConverter;
        public RomanNumeralsArithmetic()
        {
            RNConverter = new RomanNumeralsConverter();
        }

        public string RNAdd(string a, string b)
        {
            int romanNumeral1 = RNConverter.ConvertFromRomanNumeralToInt(a);
            int romanNumeral2 = RNConverter.ConvertFromRomanNumeralToInt(b);

            return RNConverter.ConvertFromIntToRomanNumeral(romanNumeral1 + romanNumeral2);
        }

        public string RNSubstract(string a, string b)
        {
            int romanNumeral1 = RNConverter.ConvertFromRomanNumeralToInt(a);
            int romanNumeral2 = RNConverter.ConvertFromRomanNumeralToInt(b);

            return RNConverter.ConvertFromIntToRomanNumeral(romanNumeral1 - romanNumeral2);
        }
    }
}
