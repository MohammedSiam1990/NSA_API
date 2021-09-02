using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NSR.Common
{
    public class CommonMethods
    {
        public static bool IsMobileNumberValid(string mobileNumber)
        {
            var mobileRegex = @"^05[0-9]{8}$";
            var match = Regex.Match(mobileNumber, mobileRegex, RegexOptions.IgnoreCase);
            return match.Success;
        }

        public static bool IsEmailValid(string email)
        {
            var emailRegex = @"^[a-zA-Z0-9_.@-]+$";
            var match = Regex.Match(email, emailRegex, RegexOptions.IgnoreCase);
            return match.Success;
        }

        public static string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}
