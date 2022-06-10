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
            var replacementChar = "";
            var replacementIndex = 0;
            var divisor = 0;

            for (int i = romanNumerals.Count - 1; i > -1; i--) // iterate descending from end of list
            {
                if (number >= romanNumerals.Keys[i])
                {
                    replacementChar = romanNumerals.Values[i];
                    replacementIndex = i;
                    divisor = romanNumerals.Keys[i];
                    i = -1;
                }
            }

            numeral = RepeatReplacementChar(DetermineCharMultiplier(number, divisor), replacementChar, replacementIndex);

            return numeral;
        }

        private static int DetermineCharMultiplier(int number, int divisor)
        {
            int charMultiplier = divisor > 0 ? Math.DivRem(number, divisor, out int remainder): 1;

            return charMultiplier;
        }

        private static string RepeatReplacementChar(int charMultiplier, string replacementChar, int replacementIndex)
        {
            string numeral = "";
            
            if (charMultiplier > 3)
            {
                // look up current key in romanNumerals using replacementIndex
                int index = romanNumerals.IndexOfValue(replacementChar);
                // retrieve the next higher numeral from romanNumerals table
                var nextHigherKey = romanNumerals.Values[index+1];
                // set numeral to replacementChar appended with next higher numeral
                numeral = replacementChar;
                replacementChar = nextHigherKey;
                charMultiplier = 1;
            }
            for (int i = 0; i < charMultiplier; i++)
            {
                numeral += replacementChar;
            }

            return numeral;
        }
    }
}