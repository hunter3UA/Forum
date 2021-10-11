using System;
using System.Security.Cryptography;

namespace Forum.BL.Services.Users
{
    public class PasswordService
    {
        public class Salted_Hash
        {
            public byte[] Hash { get; set; } = null;
            public byte[] Salt { get; set; } = null;
        }
        /// <summary>
        /// Class for creating hash 
        /// </summary>
        public class Security
        {

            /// <summary>
            /// Method for generating salt for hash
            /// </summary>
            /// <param name="TokenLength"></param>
            /// <returns></returns>
            public static byte[] CreateToken(int TokenLength)
            {
                if (TokenLength <= 0)
                { throw new ArgumentOutOfRangeException("TokenLength", "number must be positive"); }

                RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
                var salt = new byte[TokenLength];
                rngCsp.GetNonZeroBytes(salt);
                return salt;
            }

            public class HashHMACSHA1
            {
                public static int hash_lenght = 64;
                public static int hash_iterations = 15;
                /// <summary>
                /// Method for creating hash
                /// </summary>
                /// <param name="stringToHash"></param>
                /// <param name="saltLenght"></param>
                /// <returns></returns>
                public static Salted_Hash CreateSaltedHash(string stringToHash, int saltLenght = 64)
                {
                    if (stringToHash == null)
                    { throw new ArgumentNullException("password"); }
                    else if (hash_iterations <= 0)
                    { throw new ArgumentOutOfRangeException("iterations", "number must be positive"); }
                    else if (saltLenght <= 0)
                    { throw new ArgumentOutOfRangeException("saltLenght", "number must be positive"); }

                    Salted_Hash salted_Hash = new Salted_Hash()
                    {
                        Salt = Security.CreateToken(saltLenght),

                    };

                    using (Rfc2898DeriveBytes hashDriver = new Rfc2898DeriveBytes(
                        stringToHash,
                        salted_Hash.Salt))
                    {
                        salted_Hash.Hash = hashDriver.GetBytes(hash_lenght);
                    }
                    return salted_Hash;
                }
                /// <summary>
                /// Checking password
                /// </summary>
                /// <param name="stringToCheck"></param>
                /// <param name="saltedHash"></param>
                /// <returns></returns>
                public static bool CheckSaltedHash(string stringToCheck, Salted_Hash saltedHash)
                {
                    if (stringToCheck == null)
                    { throw new ArgumentNullException("password"); }
                    else if (saltedHash.Hash == null)
                    { throw new ArgumentNullException("salt"); }
                    else if (saltedHash.Salt == null)
                    { throw new ArgumentNullException("hashedPassword"); }


                    byte[] hashGenerated = null;

                    using (Rfc2898DeriveBytes hashDriver = new Rfc2898DeriveBytes(
                        stringToCheck,
                        saltedHash.Salt))
                    {
                        hashGenerated = hashDriver.GetBytes(hash_lenght);
                    }
                    return ByteArraysEqual(hashGenerated, saltedHash.Hash);
                }

                private static bool ByteArraysEqual(byte[] buff1, byte[] buff2)
                {
                    if (buff1.Length != buff2.Length)
                    {
                        return false;
                    }
                    for (int i = 0; i < buff2.Length; i++)
                    {
                        if (buff1[i] != buff2[i]) { return false; }
                    }
                    return true;
                }
            }
        }
    }
}

