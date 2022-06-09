using System;
using System.Collections.Generic;

namespace RomanNumeralsKata
{
    public class Kata
    {
        public string GetRomanNumeral(int number)
        {
            SortedList<int, string> romanNumerals = new SortedList<int, string>();
            romanNumerals.Add(0,"Nulla");
            romanNumerals.Add(1,    "I");
            romanNumerals.Add(5,    "V");
            romanNumerals.Add(10,   "X");
            romanNumerals.Add(50,   "L");
            romanNumerals.Add(100,  "C");
            romanNumerals.Add(500,  "D");
            romanNumerals.Add(1000, "M");

            var numeral ="";
            var replacementChar = "";
            var divisor = 0;

            for (int i = romanNumerals.Count - 1; i > -1; i--) // iterate descending from end of list
            {
                Console.WriteLine("key: {0}, value: {1}", romanNumerals.Keys[i], romanNumerals.Values[i]);

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
            int charMultiplier = divisor > 0 ? Math.DivRem(number, divisor, out int remainder): 1;

            return charMultiplier;
        }

        private static string RepeatReplacementChar(int charMultiplier, string replacementChar)
        {
            string numeral = "";

            for (int i = 0; i < charMultiplier; i++)
            {
                numeral += replacementChar;
            }

            return numeral;
        }
    }
}