using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSR.Common
{
    /// <summary>
    /// Class OTPGenerator.
    /// </summary>
    public static class OTPGenerator
    {
        /// <summary>
        /// GenerateOTP
        /// </summary>
        /// <returns></returns>
        /// <UpdatedBy>Dwarkesh</UpdatedBy>
        /// <UpdatedOn> 25/10/2016</UpdatedOn>
        /// <Updates>Update OTP Algorithm given by Nisarg</Updates>
        public static string GenerateOTP()
        {
            try
            {
                string value = "";
                int[] numbers = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                Random rd1 = new Random();
                int r1 = 0;
                int r2 = 0;
                int r3 = 0;
                bool flag = false;
                int randomIndex = 0;

                do
                {
                    flag = false;
                    randomIndex = rd1.Next(0, 9);
                    r1 = numbers[randomIndex];
                    randomIndex = rd1.Next(0, 9);
                    r2 = numbers[randomIndex];
                    randomIndex = rd1.Next(0, 9);
                    r3 = numbers[randomIndex];
                    value = r1.ToString() + r2.ToString() + r3.ToString();

                    if (value[0] == value[1])
                    {
                        flag = true;
                    }

                    else if (value[1] == value[2])
                    {
                        flag = true;
                    }

                    if (value[0] == value[2])
                    {
                        flag = true;
                    }

                } while (flag == true);

                randomIndex = rd1.Next(0, 2);
                Random dd = new Random();
                value = value + value[randomIndex].ToString();
                string[] MyArray = new string[4] { value[0].ToString(), value[1].ToString(), value[2].ToString(), value[3].ToString() };
                string[] MyRandomArray = MyArray.OrderBy(x => dd.Next()).ToArray();
                value = MyRandomArray[0] + MyRandomArray[1] + MyRandomArray[2] + MyRandomArray[3];
                return value;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GenerateGUIId()
        {
            int lenthofpass = 15;
            string allowedChars = "1,2,3,4,5,6,7,8,9";
            allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedChars += "1,2,3,4,5,6,7,8,9,0,!,@,#,$,%,&,?";

            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);
            string optString = "";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < lenthofpass; i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                optString += temp;
            }
            return optString;
        }
    }
}
