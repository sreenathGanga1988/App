using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AppBLL
{
    public class Class1
    {
    }

    public class SecureKeyMade
    {
        public string myKey;
        
    }

    public static  class MyIntialize
    {

        public static String Createkey()
        {
            String newkey = "";

           
         String key= encrypt(GetMacAddress());

            SecureKeyMade localPrinter = new SecureKeyMade();
            localPrinter.myKey = key;
            

            // Create and XmlSerializer to serialize the data to a file
            XmlSerializer xs = new XmlSerializer(typeof(SecureKeyMade));
            using (FileStream fs = new FileStream("Secure.xml", FileMode.Create))
            {
                xs.Serialize(fs, localPrinter);
            }

            return key;
        }


        public static Boolean  CheckKey(String name)
        {
            String readkey = "";

            String decryptreadkey = "";

            Boolean isok = false;
            try
            {
                String key = GetMacAddress();

                SecureKeyMade localPrinter = new SecureKeyMade();

                XmlSerializer xs = new XmlSerializer(typeof(SecureKeyMade));
                using (FileStream fs = new FileStream("Secure.xml", FileMode.Open))
                {
                    
                    localPrinter = xs.Deserialize(fs) as SecureKeyMade;
                    readkey = localPrinter.myKey;

                    decryptreadkey = Decrypt(readkey);
                }

                if (decryptreadkey == key && readkey==name)
                {
                    isok = true;
                }
            }
            catch (Exception)
            {

                isok = false;
            }

            return isok;
        }

        public static String  GetMacAddress()
        {
            string mac = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {

                if (nic.OperationalStatus == OperationalStatus.Up && (!nic.Description.Contains("Virtual") && !nic.Description.Contains("Pseudo")))
                {
                    if (nic.GetPhysicalAddress().ToString() != "")
                    {
                        mac = nic.GetPhysicalAddress().ToString();
                    }
                }
            }

            return mac;
        }



        public static string encrypt(string encryptString)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
                0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
            });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
                0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
            });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }






    }










}
