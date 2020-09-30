using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace Cfs.Custom.Software.Security
{


    public class Encryption
    {
        private static byte[] _salt = Encoding.ASCII.GetBytes("cfsdatakey12330844567");


        public static string EncryptData(string data, string sharedSecret)
        {
            string encryptedString = string.Empty;

            RijndaelManaged aes = null;

            try
            {
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);

                aes = new RijndaelManaged();
                aes.Key = key.GetBytes(aes.KeySize / 8);
                aes.IV = key.GetBytes(aes.BlockSize / 8);

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(data);
                        }
                    }

                    encryptedString = Convert.ToBase64String(ms.ToArray());
                }
            }
            finally
            {
                if (aes != null)
                {
                    aes.Clear();
                }
            }

            return encryptedString;
        }


    }
}
   
