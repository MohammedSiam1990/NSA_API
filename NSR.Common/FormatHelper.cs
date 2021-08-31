using System;
using System.Text.RegularExpressions;

namespace NSR.Common
{
    /// <summary>
    /// Format helper
    /// </summary>
    public static class FormatHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsArabicCharactersOnly(string value)
        {
            return Regex.IsMatch(value, "[\u0621-\u064A\u0660-\u0669]+");
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="value"></param>
       /// <returns></returns>
        public static bool IsValidComputerNumber(string value)
        {
            return Regex.IsMatch(value, "^(7)[0-9]{9}$");            
        }

        /// <summary>
        /// Checks whether its a valid Iqama or national id
        /// </summary>
        /// <param name="nationalIDOrIqamaNumber"></param>
        /// <returns></returns>
        public static bool IsValidNationalIDOrIqamaNumber(string nationalIDOrIqamaNumber)
        {
            // National ID or Iqama number should start with 1 or 2 
            if (!nationalIDOrIqamaNumber.StartsWith("1") && !nationalIDOrIqamaNumber.StartsWith("2"))
                return false;

            // National ID or Iqama number should be 10 digits always
            if (nationalIDOrIqamaNumber.Length != 10)
                return false;

            int nSum = 0;
            string lastDigit = "";
            int nDigit = 0;

            for (int i = 0; i < 9; i++)
            {
                nDigit = Convert.ToByte(nationalIDOrIqamaNumber[i]) - 48; // subtract 48 because from character it returns ANSI code of number
                if (i % 2 == 0) // If Odd position digit double it
                {
                    if ((nDigit * 2) > 9) // If two digits number then add each digit
                        nSum += Convert.ToByte(((nDigit * 2).ToString().Substring(0, 1))) + Convert.ToByte(((nDigit * 2).ToString().Substring(1, 1)));
                    else
                        nSum += nDigit * 2;
                }
                else
                    nSum += nDigit;
            }

            lastDigit = (nSum % 10).ToString();

            if (lastDigit != "0")
            {
                lastDigit = ((10 - (Convert.ToByte(lastDigit)))).ToString();
            }

            return lastDigit == nationalIDOrIqamaNumber.Substring(9, 1);
        }
    }
}
