using System;

namespace RomanNumeralsKata
{
    public class Kata
    {
        public string GetRomanNumeral(int number)
        {
            var numeral="";
            var replacementChar = "I"; 
 
            if (number == 0)
            {
                return "Nulla";
            }

            if (number >= 10)
            {
                number = Math.DivRem(number, 10, out int remainder);
                replacementChar = "X";
            }

            if (number > 0 && number < 4)
                for (int i = 0; i < number; i++)
                {
                    numeral +=replacementChar;
                }
            else if (number == 5)
            {
                return "V";
            }

            return numeral;
        }
    }
}