using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace MyWebApi.Helper
{
    public class PasswordHasher
    {
        public static byte[] GetRandom(int value)
        {
            byte[] random = new byte[value];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
            }
            return random;
        }
        public static string GetRandomPassword()
        {
            int len = 8;
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_-+=<>?";
            char[] chars = new char[len];
            using (var rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < len; i++)
                {
                    byte[] bytes = new byte[1];
                    rng.GetBytes(bytes);
                    chars[i] = validChars[bytes[0] % validChars.Length];
                }
            }
            string pass = new string(chars);
            return pass;
        }
        public static string HashPassword(string password)
        {
            byte[] salt = GetRandom(16);

            string hashPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32
                ));
            string res = Convert.ToBase64String(salt) + "|" + hashPassword;
            return res;
        }
        public static bool verifyPassword(string password, string savePassHash)
        {
            if (string.IsNullOrEmpty(savePassHash) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password or saved hash is empty");
                return false;
            }

            string[] parts = savePassHash.Split("|");
            if (parts.Length != 2)
            {
                Console.WriteLine($"Invalid hash format. Parts count: {parts.Length}");
                return false;
            }

            try
            {
                byte[] salt = Convert.FromBase64String(parts[0]);
                string hashPass = parts[1];

                string hashPassInput = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 10000,
                    numBytesRequested: 32
                    ));
                
                Console.WriteLine($"Input password: {password}");
                Console.WriteLine($"Stored salt: {parts[0]}");
                Console.WriteLine($"Stored hash: {hashPass}");
                Console.WriteLine($"Generated hash: {hashPassInput}");
                
                return hashPass == hashPassInput;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in password verification: {ex.Message}");
                return false;
            }
        }
    }
}
