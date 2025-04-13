using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace ApiLogin.DDD.Transversal.Utils
{
    public static class MetGlo
    {
        #region [Variables]
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("TuClaveSecretaDe32Bytes123456789012"); // 256-bit
        #endregion

        #region [Constructor]

        #endregion

        #region [Functions]
        public static bool IsEmail(string pEmail)
        {
            bool correcto = false;

            try
            {
                new MailAddress(pEmail);
                correcto = false;
            }
            catch (Exception ex)
            {
                correcto = false;
            }
            return correcto;
        }

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

        public static string Encrypt(string plainText)
        {
            using Aes aes = Aes.Create();
            aes.Key = Key;

            // Genera IV automáticamente
            aes.GenerateIV();

            using MemoryStream ms = new();
            // Escribe el IV primero
            ms.Write(aes.IV, 0, aes.IV.Length);

            using (CryptoStream cs = new(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            using (StreamWriter sw = new(cs))
            {
                sw.Write(plainText);
            }

            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string cipherText)
        {
            byte[] buffer = Convert.FromBase64String(cipherText);

            using Aes aes = Aes.Create();
            aes.Key = Key;

            // Lee el IV de los primeros bytes
            byte[] iv = new byte[aes.IV.Length];
            Array.Copy(buffer, iv, iv.Length);
            aes.IV = iv;

            using MemoryStream ms = new();
            using (CryptoStream cs = new(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(buffer, iv.Length, buffer.Length - iv.Length);
            }

            return Encoding.UTF8.GetString(ms.ToArray());
        }

        #endregion
    }
}
