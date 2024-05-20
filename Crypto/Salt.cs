namespace Crypto {
    public class Salt {

        private readonly Random Rnd = new Random();
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";


        /// <summary>Generar un salt segun el tamaño en bytes</summary>
        /// <param name="Length">Tamaño del salt a generar</param>
        /// <returns>una cadena de texto eb base 64 que contiene el salt generado</returns>
        public string Generate (int Length) {
            char[] Salt = new char[Length];
            for (int i = 0; i < Length; i++) {
                Salt[i] = Chars[Rnd.Next(Chars.Length)];
            }
            return new string(Salt);
        }

        /// <summary>Generar un salta a partir de un texto</summary>
        /// <param name="Text">Texto con el que se genera el salt</param>
        /// <returns>una cadena de texto eb base 64 que contiene el salt generado</returns>
        public string Generate (string Text) {
            return new Sha256().GenHashSha256(Text);
        }


    }
}
