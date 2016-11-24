using System;
using System.Security.Cryptography;

namespace PhdSurvey
{
    public static class Extensions
    {
        public static string EncryptSHA512(this string value)
        {
            byte[] dataToEncode = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, dataToEncode, 0, dataToEncode.Length);
            using (SHA512 sha = SHA512.Create())
            {
                byte[] result = sha.ComputeHash(dataToEncode);
                string retVal = Convert.ToBase64String(result);
                return retVal;
            }
        }
    }
}
