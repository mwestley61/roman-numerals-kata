using System;
using System.Collections.Generic;

namespace RomanNumeralsKata
{
    public class Kata
    {
        static SortedList<int, string> romanNumerals = new SortedList<int, string>
        {
            {0,"Nulla"},
            {1,"I"},
            {5,"V"}, 
            {10,"X"},
            {50,"L"},
            {100,"C"},
            {500,"D"},
            {1000,"M"}
        };

        public string GetRomanNumeral(int number)
        {
            var numeral ="";

            for (int i = romanNumerals.Count - 1; i > -1; i--) // iterate descending from end of list
            {
                if (number >= romanNumerals.Keys[i])
                {
                    return ConvertNumberToRomanNumeral(number, romanNumerals.Keys[i], romanNumerals.Values[i]);
                }
            }

            return numeral;
        }

        private static string ConvertNumberToRomanNumeral(int number, int divisor, string replacementChar)
        {
            int remainder = 0;
            int charMultiplier = divisor > 0 ? Math.DivRem(number, divisor, out remainder) : 1;
            Console.WriteLine("Number=" + number + " Divisor=" + divisor + " Remainder=" + remainder);

            return NumeralWithAnyAdjustmentsToReplacementChar(charMultiplier, replacementChar, remainder);
        }

        private static string NumeralWithAnyAdjustmentsToReplacementChar(int charMultiplier, string replacementChar, int remainder)
        {
            string numeral = "";

            if (charMultiplier > 3)
            {
                // set numeral to replacementChar and append with the next higher numeral
                numeral = replacementChar;
                replacementChar = romanNumerals.Values[romanNumerals.IndexOfValue(replacementChar) + 1];
                charMultiplier = 1;
            }

            if (remainder > 3)
            {
                numeral = romanNumerals.Values[romanNumerals.IndexOfValue(replacementChar) - 1];
                replacementChar = romanNumerals.Values[romanNumerals.IndexOfValue(replacementChar) + 1];
                charMultiplier = 1;
            }
            else
            {
                if (remainder > 0)
                {
                    numeral = replacementChar;
                    replacementChar = "I";
                    charMultiplier = remainder;
                }
            }

            return NumeralAffectedByCharMultiplier(charMultiplier, replacementChar, numeral);
        }

        private static string NumeralAffectedByCharMultiplier(int charMultiplier, string replacementChar, string numeral)
        {
            for (int i = 0; i < charMultiplier; i++)
            {
                numeral += replacementChar;
            }

            return numeral;
        }
    }
}