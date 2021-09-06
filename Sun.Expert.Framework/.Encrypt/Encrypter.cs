using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SunExpert.Framework.Encrypt
{
    public class Encrypter
    {
        #region constantes
        private const string _cKey = "@cl4V3*/";
        private const string _cVec = "@cl4V3*/";
        #endregion
        /// <summary>
        /// Permite cifrar y descrifar contraseña segun SIGREHU DESKTOP
        /// </summary>
        /// <param name="password">Contraseña para encriptar</param>
        /// <returns></returns>
        public static string Encrypt(string password)
        {

            byte[] plaintext;


            plaintext = Encoding.UTF8.GetBytes(password);

            byte[] keys = Encoding.UTF8.GetBytes(_cKey);

            MemoryStream memdata = new MemoryStream();
            ICryptoTransform transform;
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Mode = CipherMode.CBC;


            transform = des.CreateEncryptor(keys, Encoding.UTF8.GetBytes(_cVec));

            CryptoStream encstream = new CryptoStream(memdata, transform, CryptoStreamMode.Write);

            encstream.Write(plaintext, 0, plaintext.Length);
            encstream.FlushFinalBlock();
            encstream.Close();

            password = Convert.ToBase64String(memdata.ToArray());

            return password;
        }
        /// <summary>
        /// Permite cifrar y descrifar contraseña segun SIGREHU DESKTOP
        /// </summary>
        /// <param name="password">Contraseña encriptada</param>
        /// <returns></returns>
        public static string Decrypt(string password)
        {

            byte[] plaintext;

            plaintext = Convert.FromBase64String(password);

            byte[] keys = Encoding.UTF8.GetBytes(_cKey);

            MemoryStream memdata = new MemoryStream();
            ICryptoTransform transform;
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Mode = CipherMode.CBC;

            transform = des.CreateDecryptor(keys, Encoding.UTF8.GetBytes(_cVec));

            CryptoStream encstream = new CryptoStream(memdata, transform, CryptoStreamMode.Write);

            encstream.Write(plaintext, 0, plaintext.Length);
            encstream.FlushFinalBlock();
            encstream.Close();

            password = Encoding.UTF8.GetString(memdata.ToArray());

            return password;
        }
    }
}
