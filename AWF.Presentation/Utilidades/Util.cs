using System.Security.Cryptography;
using System.Text;

namespace AWF.Presentation.Utilidades
{
    public static class Util
    {

        public static string GenerateCode()
        {
            string guid = Guid.NewGuid().ToString("N").Substring(0,6);
            return guid;
        }

        public static string ConvertToSha256(string text)
        {
            // Crear la instancia sha256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertit una cadena a un array de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

                // Contruir el string en hash
                StringBuilder builder = new StringBuilder();
                for(int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

    }
}
