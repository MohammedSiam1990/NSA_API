using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Helpers
{
 public static class HelperPassword
    {


        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");
          //  PrintPwd(storedHash, storedSalt);
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        public static void PrintPwd( byte[] storedHash, byte[] storedSalt)
        {

            StringBuilder builderSalt = new StringBuilder();
            for (int i = 0; i < storedSalt.Length; i++)
            {
                builderSalt.Append( storedSalt[i].ToString("x2"));
            }  
            File.WriteAllText("C:\\PwdSalt.txt", builderSalt.ToString());
            // BitConverter can also be used to put all bytes into one string  
            string V = "0x7A8DC9FA658D1AAFBC6E1611C6975F6F30EAFAC52132875943F8714A873EC2E30FD9ECA85E91E92FB5DAAB0546ABE79D4FEC4BD73FA4B7EEE0D826A07EB3C34AABAFC52EB847017555F7C31D86DAE88186146EEEB22CE8C904A50D3B3B1B777E7B9BF597523DD393D7D23A840A4C361C88393381B3683B2F8BE88EF1FF4CE4A0".ToLower();
                byte[] Salt = Encoding.Default.GetBytes(V);
           // byte[] keys = Encoding.Default.GetBytes("key");
            File.AppendAllText("C:\\PwdSalt.txt", Environment.NewLine);
              File.WriteAllText("C:\\PwdSalt.txt", System.Text.Encoding.Default.GetString(Salt));


            string bitString = BitConverter.ToString(storedSalt);
            File.AppendAllText("C:\\PwdSalt.txt",Environment.NewLine);
             File.AppendAllText("C:\\PwdSalt.txt", "// BitConverter can also be used to put all bytes into one string "  );
            File.AppendAllText("C:\\PwdSalt.txt", Environment.NewLine);
            File.AppendAllText("C:\\PwdSalt.txt", bitString );
            File.AppendAllText("C:\\PwdSalt.txt", Environment.NewLine);
            // UTF conversion - String from bytes  
            string utfString = Encoding.UTF8.GetString(storedSalt, 0, storedSalt.Length);
            File.AppendAllText("C:\\PwdSalt.txt", "// UTF conversion - String from bytes  ");
            File.AppendAllText("C:\\PwdSalt.txt", Environment.NewLine);
            File.AppendAllText("C:\\PwdSalt.txt", utfString );
            File.AppendAllText("C:\\PwdSalt.txt", Environment.NewLine);
            // ASCII conversion - string from bytes  
            string asciiString = Encoding.ASCII.GetString(storedSalt, 0, storedSalt.Length);
            File.AppendAllText("C:\\PwdSalt.txt", "// ASCII conversion - string from bytes  ");
            File.AppendAllText("C:\\PwdSalt.txt", Environment.NewLine);
            File.AppendAllText("C:\\PwdSalt.txt", asciiString );


            StringBuilder builderHash = new StringBuilder();
            for (int i = 0; i < storedHash.Length; i++)
            {
                builderHash.Append( storedHash[i].ToString("x2"));
            }
            File.WriteAllText("C:\\PwdHash.txt", builderHash.ToString());
           File.AppendAllText("C:\\PwdHash.txt", Environment.NewLine);
            bitString = BitConverter.ToString(storedHash);

           
            File.AppendAllText("C:\\PwdHash.txt", "//BitConverter can also be used to put all bytes into one string");
            File.AppendAllText("C:\\PwdHash.txt", Environment.NewLine);
            File.AppendAllText("C:\\PwdHash.txt", bitString  );
            File.AppendAllText("C:\\PwdHash.txt", Environment.NewLine);
            // UTF conversion - String from bytes  
            utfString = Encoding.UTF8.GetString(storedHash, 0, storedHash.Length);
            File.AppendAllText("C:\\PwdHash.txt", "// UTF conversion - String from bytes  ");
            File.AppendAllText("C:\\PwdHash.txt", Environment.NewLine);
            File.AppendAllText("C:\\PwdHash.txt", utfString );
            File.AppendAllText("C:\\PwdHash.txt", Environment.NewLine);
            // ASCII conversion - string from bytes  
            asciiString = Encoding.ASCII.GetString(storedHash, 0, storedHash.Length);
            File.AppendAllText("C:\\PwdHash.txt", "// ASCII conversion - string from bytes  ");
            File.AppendAllText("C:\\PwdHash.txt", Environment.NewLine);
            File.AppendAllText("C:\\PwdHash.txt", asciiString);
        }
    }
}
