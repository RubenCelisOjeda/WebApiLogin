using System.Security.Cryptography;
using System.Text;

namespace ApiLogin.DDD.Transversal.Utils
{
    public static class AesEncryptionHelper
    {
        // Recomendado: Guardar esta clave en Azure Key Vault o AWS Secrets Manager
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("TuClaveSecretaDe32Bytes123456789012"); // 256-bit

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
    }
}
