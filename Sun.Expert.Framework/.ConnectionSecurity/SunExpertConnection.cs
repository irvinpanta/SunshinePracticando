using SunExpert.Framework.Encrypt;
using System;

namespace SunExpert.Framework.ConnectionSecurity
{
    public static class SunExpertConnection
    {
        const string _ConfigurationEF = "integrated security=False;persist security info=True;connect timeout=0;MultipleActiveResultSets=True;App=EntityFramework";

        public static string GetConnectionApp()
        {
            string server = "localhost";// ConfigurationManager.AppSettings["CONNECTION_SERVER"];
            string db = "SunshinePractica";// ConfigurationManager.AppSettings["CONNECTION_DB"];
            string user = "Naoemi"; // ConfigurationManager.AppSettings["CONNECTION_USER"];
            string password = "OZaE2dt6V1dPgSUZBOORTQ=="; // ConfigurationManager.AppSettings["CONNECTION_PASSWORD"];

            //Verifica si User no es vacio
            if (user.Trim().Length == 0)
                throw new Exception("Usuario de DB no especificado en .CONFIG");

            //Verificar si Password no es vacio
            if (password.Trim().Length == 0)
                throw new Exception("Contraseña de DB no especificado en .CONFIG");

            //Decryt Password de DB
            password = Encrypter.Decrypt(password);

            //Formamos la Cadena de connection
            string connection = string.Format("data source={0};initial catalog={1};user id={2};password={3};{4}", server, db, user, password, _ConfigurationEF);

            return connection;
        }
    }
}
