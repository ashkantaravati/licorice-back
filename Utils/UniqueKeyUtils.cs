using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace LicoriceBack.Utils
{
    public static class UniqueKeyUtils
    {
        internal static readonly char[] chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        public static string GenerateUniqueKey()
        {
            string first3 = GenerateRandomAlphanumericString(3);
            string second5 = GenerateRandomAlphanumericString(5);
            string third2 = GenerateRandomAlphanumericString(2);

            return $"{first3}-{second5}-{third2}";
        }

        public static string GenerateRandomAlphanumericString(int length)
        {
            byte[] data = new byte[4 * length];
            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new(length);
            for (int i = 0; i < length; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString();
        }
    }
}
