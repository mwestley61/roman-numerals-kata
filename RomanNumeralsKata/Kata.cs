using System;

namespace RomanNumeralsKata
{
    public class Kata
    {
        public string GetRomanNumeral(int number)
        {
            var numeral="";
            var replacementChar = "";
            var divisor = 0;

            if (number == 0)
            {
                return "Nulla";
            }
            if (number == 5)
            {
                return "V";
            }

            if (number >= 1000)
            { 
                replacementChar = "M";
                divisor = 1000;
            }
            else
            {
                if (number >= 100)
                {
                    replacementChar = "C";
                    divisor = 100;
                } 
                else
                {
                    if (number >= 10)
                    {
                        replacementChar = "X";
                        divisor = 10;
                    }
                    else
                    {
                        replacementChar = "I";
                        divisor = 1;
                    }
                }
            }

            numeral = RepeatReplacementChar(DetermineCharMultiplier(number, divisor), replacementChar);

            return numeral;
        }

        private static int DetermineCharMultiplier(int number, int divisor)
        {
            int charMultiplier = Math.DivRem(number, divisor, out int remainder);

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