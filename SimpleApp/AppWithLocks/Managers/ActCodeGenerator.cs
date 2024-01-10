using System;
using System.Security.Cryptography;
using System.Text;

namespace AppWithLocks.Managers
{
    class ActCodeGenerator
    {
        public static string GetRegistrationCode(string id)
        {
            System.Text.Encoder enc = System.Text.Encoding.Unicode.GetEncoder();
            byte[] unicodeText = new byte[id.Length * 2];
            enc.GetBytes(id.ToCharArray(), 0, id.Length, unicodeText, 0, true);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < unicodeText.Length; i++)
            {
                sb.Append(unicodeText[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string GetCodeFromSerial(string serialString)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(serialString));
        }

        public static string GetSerialFromCode(string codeString)
        {
            byte[] data = Convert.FromBase64String(codeString);
            return System.Text.Encoding.UTF8.GetString(data);
        }

        public static string GenerateLicenseKey(string productIdentifier)
        {
            return FormatLicenseKey(GetMd5Sum(productIdentifier));
        }

        static string GetMd5Sum(string productIdentifier)
        {
            System.Text.Encoder enc = System.Text.Encoding.Unicode.GetEncoder();
            byte[] unicodeText = new byte[productIdentifier.Length * 2];
            enc.GetBytes(productIdentifier.ToCharArray(), 0, productIdentifier.Length, unicodeText, 0, true);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(unicodeText);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("X2"));
            }
            return sb.ToString();
        }

        static string FormatLicenseKey(string productIdentifier)
        {
            productIdentifier = productIdentifier.Substring(0, 28).ToUpper();
            char[] serialArray = productIdentifier.ToCharArray();
            StringBuilder licenseKey = new StringBuilder();

            int j = 0;
            for (int i = 0; i < 28; i++)
            {
                for (j = i; j < 4 + i; j++)
                {
                    licenseKey.Append(serialArray[j]);
                }
                if (j == 28)
                {
                    break;
                }
                else
                {
                    i = (j) - 1;
                    licenseKey.Append("-");
                }
            }
            return licenseKey.ToString();
        }
    }
}
