using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Util
{
    public class Encriptador
    {
        // Clave de encriptación. Deberías cambiar esto por una clave segura y no compartirla públicamente.
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("TuClaveSecreta12"); // Clave de 16 caracteres (128 bits)
        // Vector de inicialización. Deberías cambiar esto por un vector seguro y no compartirla públicamente.
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("TuVectorDeInicio");
        public static string EncryptString(string plainText)
        {

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Crea un encriptador para realizar la transformación de los datos
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Crea el flujo de memoria para la encriptación
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    // Crea un flujo de cifrado para escribir los datos cifrados en el flujo de memoria
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        // Escribe los datos cifrados en el flujo de cifrado
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    // Devuelve los datos cifrados como una cadena Base64
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string DecryptString(string encryptedText)
        {
            // Convierte la cadena cifrada de Base64 a bytes
            byte[] cipherText = Convert.FromBase64String(encryptedText);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Crea un desencriptador para realizar la transformación de los datos
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Crea el flujo de memoria para la desencriptación
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    // Crea un flujo de cifrado para leer los datos cifrados del flujo de memoria
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        // Lee los datos cifrados del flujo de cifrado y los decodifica como una cadena
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
