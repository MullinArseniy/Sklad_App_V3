using System.Security.Cryptography;

public class PasswordHasher
{

    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int DefaultIterations = 100000;

    public static string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);

        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, DefaultIterations, HashAlgorithmName.SHA256, HashSize);

        var hashBytes = new byte[SaltSize + HashSize];
        Array.Copy(salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

        return Convert.ToBase64String(hashBytes);

    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {

        var hashBytes = Convert.FromBase64String(hashedPassword);


        var salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);


        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, DefaultIterations, HashAlgorithmName.SHA256, HashSize);

        for (var i = 0; i < HashSize; i++)
        {
            if (hashBytes[i + SaltSize] != hashToCompare[i])
            {
                return false;
            }
        }

        return true;
    }
}