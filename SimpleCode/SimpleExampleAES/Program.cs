using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExampleAES
{
    class Program
    {
        private static byte[] GetIV(string ivSecret)
        {
            MD5 md5 = MD5.Create();
            return md5.ComputeHash(Encoding.UTF8.GetBytes(ivSecret));
        }

        private static byte[] GetKey(string key)
        {
            SHA256 sha256 = SHA256.Create();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
        }

        private static byte[] Encrypt(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;
            // Create a new AesManaged.
            using (AesManaged aes = new AesManaged())
            {
                // Create encryptor
                ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
                // Create MemoryStream
                using (MemoryStream ms = new MemoryStream())
                {
                    // Create crypto stream using the CryptoStream class. This class is the key to encryption
                    // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream
                    // to encrypt
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        // Create StreamWriter and write data to a stream
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);
                        encrypted = ms.ToArray();
                    }
                }
            }
            // Return encrypted data
            return encrypted;
        }

        private static string Decrypt(byte[] cipherText, byte[] Key, byte[] IV)
        {
            string plaintext = null;
            // Create AesManaged
            using (AesManaged aes = new AesManaged())
            {
                // Create a decryptor
                ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
                // Create the streams used for decryption.
                using (MemoryStream ms = new MemoryStream(cipherText))
                {
                    // Create crypto stream
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        // Read crypto stream
                        using (StreamReader reader = new StreamReader(cs))
                            plaintext = reader.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }

        static void Main(string[] args)
        {
            //ключ для шифрования
            string key = "oMEOO1k!";

            //вектор инициализации
            string ivSecret = "@Dx!n9^B";

            // пароль
            string password = "123";
            Console.WriteLine("Plain text data: {0}", password);

            Aes aes = Aes.Create();

            aes.IV = GetIV(ivSecret);
            aes.Key = GetKey(key);

            // Encrypt string
            byte[] encryptedPassword = Encrypt(password, aes.Key, aes.IV);
            string base64encryptPassword = Convert.ToBase64String(encryptedPassword);
            Console.WriteLine("Encrypted data: {0}", base64encryptPassword);

            byte[] encryptedPasswordArray = Convert.FromBase64String(base64encryptPassword);
            string decryptedPasswordStr = Decrypt(encryptedPasswordArray, aes.Key, aes.IV);
            Console.WriteLine("Decrypted data: {0}", decryptedPasswordStr);

            Console.WriteLine("Press any key!");
            Console.ReadKey();
        }
    }
}
