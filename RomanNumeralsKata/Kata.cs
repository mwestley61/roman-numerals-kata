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
        string shiftChar = "";

        public string GetRomanNumeral(int number)
        {
            var numeral ="";
            var replacementChar = "";
            var divisor = 0;

            for (int i = romanNumerals.Count - 1; i > -1; i--) // iterate descending from end of list
            {
                if (number >= romanNumerals.Keys[i])
                {
                    replacementChar = romanNumerals.Values[i];
                    divisor = romanNumerals.Keys[i];
                    i = -1;
                }
            }

            numeral = RepeatReplacementChar(DetermineCharMultiplier(number, divisor), replacementChar);

            return numeral;
        }

        private static int DetermineCharMultiplier(int number, int divisor)
        {
            int remainder = 0;
            int charMultiplier = divisor > 0 ? Math.DivRem(number, divisor, out remainder) : 1;
            Console.WriteLine("Number=" + number + " Divisor=" + divisor + " Remainder=" + remainder);
            if (remainder == 4)
            {
                charMultiplier = 0;
            }

            return charMultiplier;
        }

        private static string RepeatReplacementChar(int charMultiplier, string replacementChar)
        {
            string numeral = "";
            
            if (charMultiplier > 3)
            {
                // set numeral to replacementChar and append with the next higher numeral
                numeral = replacementChar;
                replacementChar = romanNumerals.Values[romanNumerals.IndexOfValue(replacementChar) + 1];
                charMultiplier = 1;
            }
            else
            {
                if (charMultiplier == 0)
                {
                    numeral = romanNumerals.Values[romanNumerals.IndexOfValue(replacementChar) - 1];
                    replacementChar = romanNumerals.Values[romanNumerals.IndexOfValue(replacementChar) + 1];
                    charMultiplier = 1;
                }
            }

            for (int i = 0; i < charMultiplier; i++)
            {
                numeral += replacementChar;
            }

            return numeral;
        }
    }
}