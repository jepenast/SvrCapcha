using System.Text;

namespace Crypto {
    public static class General {

        /// <summary>Obtiene un vector de bytes de los datos enviadoas</summary>
        /// <param name="strData">Cadena de texto a obtener los bytes</param>
        public static byte[] GetBytes(string strData) {
            return Encoding.UTF8.GetBytes(strData);
        }

        /// <summary>Obtiene una cadena de texto segun los bytes recibidos</summary>
        /// <param name="bytes">Array de bytes a convertir en una cadena de texto</param>
        /// <returns></returns>
        public static string GetStrFromBytes(byte[] bytes) {
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>Convierte los caracteres hexadecimales en una cadena de texto</summary>
        /// <param name="hex">Cadena hexadecimal a convertir</param>
        public static string HexToStr (string hex) {
            StringBuilder sb = new();
            for (int i = 0; i < hex.Length; i += 2) {
                string HEXPair = hex.Substring(i, 2);
                byte ByteValue = Convert.ToByte(HEXPair, 16);
                char Char = Convert.ToChar(ByteValue);
                sb.Append(Char);
            }
            return sb.ToString();
        }
    }
}
