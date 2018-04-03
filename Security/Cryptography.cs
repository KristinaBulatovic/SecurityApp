using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Security
{
    class Cryptography
    {
        public string Encrypt_TriplDES(string key, string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            UTF8Encoding utf8 = new UTF8Encoding();
            TripleDESCryptoServiceProvider tDES = new TripleDESCryptoServiceProvider();
            tDES.Key = md5.ComputeHash(utf8.GetBytes(key));
            tDES.Mode = CipherMode.ECB;
            tDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform trans = tDES.CreateEncryptor();
            try
            {
                return Convert.ToBase64String(trans.TransformFinalBlock(utf8.GetBytes(text), 0, utf8.GetBytes(text).Length));
            }
            catch
            {
                return "";
            }

        }

        public string Decrypt_TriplDES(string key, string text)
        {
            try
            {
                byte[] encrypted = Convert.FromBase64String(text);
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                UTF8Encoding utf8 = new UTF8Encoding();
                TripleDESCryptoServiceProvider tDES = new TripleDESCryptoServiceProvider();
                tDES.Key = md5.ComputeHash(utf8.GetBytes(key));
                tDES.Mode = CipherMode.ECB;
                tDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform trans = tDES.CreateDecryptor();
                try
                {
                    return utf8.GetString(trans.TransformFinalBlock(encrypted, 0, encrypted.Length));
                }
                catch
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }

        private string IV = "qgp065mlsy3ep064"; // 16 chars = 128 bytes

        public string Encrypt_AES(string key, string text) // key -> 32 chars = 256 bytes
        {
            byte[] textbytes = ASCIIEncoding.ASCII.GetBytes(text);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = ASCIIEncoding.ASCII.GetBytes(key);
            aes.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            ICryptoTransform trans = aes.CreateEncryptor(aes.Key, aes.IV);

            byte[] encrypt = trans.TransformFinalBlock(textbytes, 0, textbytes.Length);
            trans.Dispose();

            try
            {
                return Convert.ToBase64String(encrypt);
            }
            catch
            {
                return "";
            }

        }

        public string Decrypt_AES(string key, string text) // key -> 32 chars = 256 bytes
        {
            byte[] textbytes = Convert.FromBase64String(text);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            try
            {
                aes.Key = ASCIIEncoding.ASCII.GetBytes(key);
                aes.IV = ASCIIEncoding.ASCII.GetBytes(IV);
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;
                ICryptoTransform trans = aes.CreateDecryptor(aes.Key, aes.IV);

                byte[] decrypt = trans.TransformFinalBlock(textbytes, 0, textbytes.Length);
                trans.Dispose();

                return ASCIIEncoding.ASCII.GetString(decrypt);
            }
            catch
            {
                return "";
            }


        }
        public string Key(string text)
        {
            string k = text;
            string key = "";
            if (k.Length == 0)
            {
                for (int i = 0; i < 32; i++)
                {
                    key += " ";
                }
            }
            else if (k.Length < 32)
            {
                key = k;
                for (int i = 32; i > k.Length; i--)
                {
                    key += " ";
                }
            }
            else key = k;
            return key;
        }

        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        byte[] plaintext;
        byte[] encryptedtext;


        static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.ImportParameters(RSAKey); encryptedData = rsa.Encrypt(Data, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        static public byte[] Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.ImportParameters(RSAKey);
                    decryptedData = rsa.Decrypt(Data, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
        public string RSA_Encrypted(string text)
        {
            plaintext = ByteConverter.GetBytes(text);
            encryptedtext = Encryption(plaintext, RSA.ExportParameters(false), false);
            try
            {
                return ByteConverter.GetString(encryptedtext);
            }
            catch
            {
                return "";
            }
        }

        public string RSA_Decrypted()
        {
            byte[] decryptedtex = Decryption(encryptedtext, RSA.ExportParameters(true), false);
            try
            {
                return ByteConverter.GetString(decryptedtex);
            }
            catch
            {
                return "";
            }

        }

        public string DES_Encrypt(string originalString)
        {
            if (String.IsNullOrEmpty(originalString))
            {
                throw new ArgumentNullException
                       ("The string which needs to be encrypted can not be null.");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            try
            {
                return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }
            catch
            {
                return "";
            }
        }

        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");

        public string DES_Decrypt(string cryptedString)
        {
            if (String.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException
                   ("The string which needs to be decrypted can not be null.");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream
                    (Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);

            try
            {
                return reader.ReadToEnd();
            }
            catch
            {
                return "";
            }

        }
    }
}
