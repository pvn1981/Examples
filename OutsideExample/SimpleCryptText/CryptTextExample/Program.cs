using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CryptTextExample
{
    public class EncryptManager
    {
        public struct Security
        {
            /// <summary>
            /// 加密指定的字节数据 - Зашифровать указанные байты данных
            /// </summary>
            /// <param name="originalData">原始字节数据 - необработанные байтовые данные</param>
            /// <param name="keyData">加密密钥 - ключ шифрования</param>
            /// <param name="ivData"></param>
            /// <returns>加密后的密文 - Зашифрованный зашифрованный текст</returns>
            private static byte[] Encrypt(byte[] originalData, byte[] keyData, byte[] ivData)
            {
                MemoryStream memoryStream = new MemoryStream();
                //创建Rijndael加密算法
                System.Security.Cryptography.Rijndael rijndael = System.Security.Cryptography.Rijndael.Create();
                rijndael.Key = keyData;
                rijndael.IV = ivData;

                System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(
                    memoryStream, rijndael.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
                try
                {
                    cryptoStream.Write(originalData, 0, originalData.Length);
                    cryptoStream.Close();
                    cryptoStream.Dispose();
                    return memoryStream.ToArray();
                }
                catch (Exception ex)
                {
                    // LogManager.Instance.WriteLog("GlobalMethods.Encrypt", ex);
                    return null;
                }
                finally
                {
                    memoryStream.Close();
                    memoryStream.Dispose();
                }
            }

            /// <summary>
            /// 解密指定的字节数据 - Расшифровать указанные байтовые данные
            /// </summary>
            /// <param name="originalData">加密的字节数据 - Зашифрованные байтовые данные</param>
            /// <param name="keyData">解密密钥 - Ключ дешифрования</param>
            /// <param name="ivData"></param>
            /// <returns>原始文本 - Оригинальный текст</returns>
            private static byte[] Decrypt(byte[] encryptedData, byte[] keyData, byte[] ivData)
            {
                MemoryStream memoryStream = new MemoryStream();
                //创建Rijndael加密算法 - Создайте алгоритм шифрования Rijndael.
                System.Security.Cryptography.Rijndael rijndael = System.Security.Cryptography.Rijndael.Create();
                rijndael.Key = keyData;
                rijndael.IV = ivData;

                System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(
                    memoryStream, rijndael.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
                try
                {
                    cryptoStream.Write(encryptedData, 0, encryptedData.Length);
                    cryptoStream.Close();
                    cryptoStream.Dispose();
                    return memoryStream.ToArray();
                }
                catch (Exception ex)
                {
                    // LogManager.Instance.WriteLog("GlobalMethods.Decrypt", ex);
                    return null;
                }
                finally
                {
                    memoryStream.Close();
                    memoryStream.Dispose();
                }
            }

            /// <summary>
            /// 加密一段文本 - Зашифровать текст
            /// </summary>
            /// <param name="szOriginalText">原始文本 - Оригинальный текст</param>
            /// <param name="szKey">加密密钥 - ключ шифрования</param>
            /// <returns>加密后的密文 - Зашифрованный зашифрованный текст</returns>
            public static string EncryptText(string szOriginalText, string szKey)
            {
                try
                {
                    byte[] originalData = System.Text.Encoding.Unicode.GetBytes(szOriginalText);

                    System.Security.Cryptography.PasswordDeriveBytes pdb = new System.Security.Cryptography.PasswordDeriveBytes(szKey
                        , new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                    byte[] encryptedData = EncryptManager.Security.Encrypt(originalData, pdb.GetBytes(32), pdb.GetBytes(16));

                    return System.Convert.ToBase64String(encryptedData);
                }
                catch (Exception ex)
                {
                    // LogManager.Instance.WriteLog("GlobalMethods.EncryptText", ex);
                    return null;
                }
            }

            /// <summary>
            /// 解密一段密文 - Расшифровать зашифрованный текст
            /// </summary>
            /// <param name="szOriginalText">密文文本 - зашифрованный текст</param>
            /// <param name="szKey">解密密钥 - Ключ дешифрования</param>
            /// <returns>原始文本 - Оригинальный текст</returns>
            public static string DecryptText(string szEncryptedText, string szKey)
            {
                try
                {
                    byte[] encryptedData = System.Convert.FromBase64String(szEncryptedText);

                    System.Security.Cryptography.PasswordDeriveBytes pdb = new System.Security.Cryptography.PasswordDeriveBytes(szKey
                        , new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                    byte[] originalData = EncryptManager.Security.Decrypt(encryptedData, pdb.GetBytes(32), pdb.GetBytes(16));

                    return System.Text.Encoding.Unicode.GetString(originalData);
                }
                catch (Exception ex)
                {
                    // LogManager.Instance.WriteLog("GlobalMethods.DecryptText", ex);
                    return null;
                }
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            string securityKey = "dEr78#4$";
            // admin = 0gPQpwVoDOwkRVxst1wHrA==
            string doneencryption = EncryptManager.Security.EncryptText("admin", securityKey);
            Console.WriteLine(doneencryption);

            string donedecrypting = EncryptManager.Security.DecryptText(doneencryption, securityKey);
            Console.WriteLine(donedecrypting);
        }
    }
}
