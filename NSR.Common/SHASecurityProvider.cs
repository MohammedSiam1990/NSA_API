using System;
using System.Security.Cryptography;
using System.Text;

namespace NSR.Common
{

    public static class SHASecurityProvider
    {
        #region Properties

        public static string ErrorMsg { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Generates a hash for the given text value and returns a
        /// base64-encoded result. Before the hash is computed, a random salt
        /// is generated and appended to the plain text. This salt is stored at
        /// the end of the hash value, so it can be used later for hash
        /// and returns encrypted text 
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="useHashing"></param>
        /// <returns></returns>
        /// <history>
        /// [Created by :] BINITA SHAH ON 08.08.2017
        /// </history>
        public static string Encrypt(string plainText)
        {
            // If salt is not specified, generate it on the fly.
            // Define min and max salt sizes.
            int minSaltSize = 4;
            int maxSaltSize = 8;
            // Generate a random number for the size of the salt.
            Random random = new Random();
            int saltSize = random.Next(minSaltSize, maxSaltSize);
            // Allocate a byte array, which will hold the salt.
            byte[] saltBytes = new byte[saltSize];
            // Initialize a random number generator.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            // Fill the salt with cryptographically strong byte values.
            rng.GetNonZeroBytes(saltBytes);

            //Get Encrypted cipherText using generated saltBytes
            return Encrypt(plainText, saltBytes);
        }

        /// <summary>
        /// A common Encryption method that will be called from Encrypt and VerifyEncrypt Method
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="saltBytes"></param>
        /// <returns></returns>
        /// [Created by :] BINITA SHAH ON 08.08.2017
        private static string Encrypt(string plainText, byte[] saltBytes)
        {
            if (!string.IsNullOrWhiteSpace(plainText))
            {
                try
                {
                    // Convert plain text into a byte array.
                    byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                    // Allocate array, which will hold plain text and salt.
                    byte[] plainTextWithSaltBytes = new byte[plainTextBytes.Length + saltBytes.Length];

                    // Copy plain text bytes into resulting array.
                    for (int i = 0; i < plainTextBytes.Length; i++)
                        plainTextWithSaltBytes[i] = plainTextBytes[i];

                    // Append salt bytes to the resulting array.
                    for (int i = 0; i < saltBytes.Length; i++)
                        plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

                    // Because we support multiple hashing algorithms, we must define
                    // hash object as a common (abstract) base class. We will specify the
                    // actual hashing algorithm class later during object creation.
                    HashAlgorithm hash;

                    // Initialize appropriate hashing algorithm class.
                    hash = new SHA1Managed();

                    // Compute hash value of our plain text with appended salt.
                    byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

                    // Create array which will hold hash and original salt bytes.
                    byte[] hashWithSaltBytes = new byte[hashBytes.Length + saltBytes.Length];

                    // Copy hash bytes into resulting array.
                    for (int i = 0; i < hashBytes.Length; i++)
                        hashWithSaltBytes[i] = hashBytes[i];

                    // Append salt bytes to the result.
                    for (int i = 0; i < saltBytes.Length; i++)
                        hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

                    // Convert result into a base64-encoded string.
                    string hashValue = Base36.ByteArrayToBase36String(hashWithSaltBytes);

                    // Return the result.
                    return hashValue;
                }
                catch (Exception ex)
                {
                    ErrorMsg = ex.Message.ToString();
                    return string.Empty;
                }
            }
            else
                return string.Empty;
        }

        /// <summary>
        /// Compares a hash of the specified plain text value to a given hash
        /// value. Plain text is hashed with the same salt value as the original
        /// hash.
        /// </summary>
        /// <param name="plainText">
        /// Plain text to be verified against the specified hash. The function
        /// does not check whether this parameter is null.
        /// </param>
        /// <param name="hashValue">
        /// Base64-encoded hash value produced by ComputeHash function. This value
        /// includes the original salt appended to it.
        /// </param>
        /// <returns>
        /// If computed hash mathes the specified hash the function the return
        /// value is true; otherwise, the function returns false.
        /// </returns>
        /// <history>
        /// [Created by :] BINITA SHAH ON 08.08.2017
        /// </history>
        public static bool VerifyEncryption(string plainText, string cipherText)
        {
            if (!string.IsNullOrWhiteSpace(plainText) && !string.IsNullOrWhiteSpace(cipherText))
            {
                try
                {
                    byte[] saltBytes = GetSaltBytes(cipherText);

                    if (saltBytes == null)
                        return false;

                    // Compute a new hash string.
                    string expectedHashString = Encrypt(plainText, saltBytes);

                    // If the computed hash matches the specified hash,
                    // the plain text value must be correct.
                    return (cipherText == expectedHashString);
                }
                catch (Exception ex)
                {
                    ErrorMsg = ex.Message.ToString();
                    return false;
                }
            }
            else
                return false;
        }

        /// <summary>
        /// Retrieve SaltByte from Encrypted Password
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        /// [Created by :] BINITA SHAH ON 08.08.2017
        private static byte[] GetSaltBytes(string cipherText)
        {
            // Convert base64-encoded hash value into a byte array.
            byte[] hashWithSaltBytes = Base36.Base36StringToByteArray(cipherText);

            // We must know size of hash (without salt).
            int hashSizeInBits, hashSizeInBytes;

            // Size of hash is based on the specified algorithm.
            hashSizeInBits = 160;
            // Convert size of hash from bits to bytes.
            hashSizeInBytes = hashSizeInBits / 8;

            // Make sure that the specified hash value is long enough.
            if (hashWithSaltBytes.Length < hashSizeInBytes)
                return null;
            // Allocate array to hold original salt bytes retrieved from hash.
            byte[] saltBytes = new byte[hashWithSaltBytes.Length - hashSizeInBytes];

            // Copy salt from the end of the hash to the new array.
            for (int i = 0; i < saltBytes.Length; i++)
                saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];

            return saltBytes;
        }

       
        #endregion
    }

}