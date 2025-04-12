using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace ApiLogin.DDD.Transversal.Utils
{
    public static class PasswordHasher
    {
        #region [Functions]
        public static string HashPassword(string password)
        {
            // Genera un salt aleatorio
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // 128-bit

            // Deriva el hash (PBKDF2 con HMAC-SHA256)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000, // Número de iteraciones
                numBytesRequested: 256 / 8)); // 256-bit output

            return $"{Convert.ToBase64String(salt)}.{hashed}";
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split('.');
            if (parts.Length != 2) return false;

            byte[] salt = Convert.FromBase64String(parts[0]);
            string hashed = parts[1];

            string newHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return hashed == newHash;
        } 
        #endregion
    }
}
