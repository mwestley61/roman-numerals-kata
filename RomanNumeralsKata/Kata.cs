using System;

namespace RomanNumeralsKata
{
    public class Kata
    {
        public object getRomanNumeral(int number)
        {
            if (number == 1)
            {
                return "I";
            }
            else
            {
                if (number == 2)
                {
                    return "II";
                }
            }  
            return "III";
        }
    }
}