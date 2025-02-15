using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;

namespace API.TechsysLog
{
    public class BCryptor
    {
        public static string Encrypt(string input)
        {
            var encryptedText = BCrypt.Net.BCrypt.HashPassword(input);
            return encryptedText;
        }

        public static bool InputIsCorrect(string input, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(input, storedHash);
        }
    }
}
