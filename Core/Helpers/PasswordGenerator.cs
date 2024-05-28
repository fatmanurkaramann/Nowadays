using System.Security.Cryptography;
using System.Text;

namespace Core.Helpers
{
    public class PasswordGenerator
    {
        private const int DefaultLength = 12;

        public static string Generate(int length = DefaultLength)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length must be greater than zero.", nameof(length));
            }

            using RNGCryptoServiceProvider rng = new();
            byte[] randomNumber = new byte[length];
            rng.GetBytes(randomNumber);

            StringBuilder password = new(length);

            foreach (byte num in randomNumber)
            {
                password.Append(ValidChar(num));
            }

            return password.ToString();
        }

        private static char ValidChar(byte val)
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return validChars[val % validChars.Length];
        }
    }
}
