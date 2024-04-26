using System.Security.Cryptography;
using System.Text;

namespace MicroHack.Util;

public class PasswordHashingService
{
    public static string HashPassword(string password)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(password);
        byte[] hashBytes = SHA256.HashData(bytes);

        StringBuilder builder = new();

        for (int i = 0; i < hashBytes.Length; i++)
        {
            builder.Append(hashBytes[i].ToString("x2"));
        }

        return builder.ToString();
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        string hashedInput = HashPassword(password);
        return hashedInput.Equals(hashedPassword, StringComparison.OrdinalIgnoreCase);
    }
}