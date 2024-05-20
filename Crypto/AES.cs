using System.Security.Cryptography;
using System.Text;

namespace Crypto {
    public class AES {

        public enum CryptoMode {
            CBC,
            ECB,
            CFB,
            CTS
        }

        private string ResCheck {get;set;}

        public AES() {
            ResCheck=string.Empty;
        }

        /// <summary>Encripta una cadena de texto utilizando AES con una clave y un vector de inicialización (IV) específicos.</summary>
        /// <param name="Text">Texto a cifrar</param>
        /// <param name="Key">LLave de encriptacion</param>
        /// <param name="IV">Inicializacion del vector del mapa de encriptacion</param>
        public string Encrypt (string Text, string Key, string IV, CryptoMode Mode) {
            if (CheckReqKeys(Key,IV)) {
                return ResCheck;
            }
            using var aesAlg = Aes.Create();
            aesAlg.Key = General.GetBytes(Key);
            aesAlg.IV = General.GetBytes(IV);
            aesAlg.Mode = GetMode(Mode);
            ICryptoTransform Encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using MemoryStream MS = new();
            using (CryptoStream CrytoS = new(MS, Encryptor, CryptoStreamMode.Write)) {
                byte[] TextBytes = Encoding.UTF8.GetBytes(Text);
                CrytoS.Write(TextBytes, 0, TextBytes.Length);
            }
            return Encoding.UTF8.GetString(MS.ToArray());
        }

        /// <summary>Desencripta datos encriptados utilizando AES con una clave y un vector de inicialización (IV) específicos</summary>
        /// <param name="CipherText">Texto Cifrado</param>
        /// <param name="Key">LLave de encriptacion</param>
        /// <param name="IV">Inicializacion del vector del mapa de encriptacion</param>
        public string Decrypt (string CipherText, string Key, string IV, CryptoMode Mode) {
            byte[] TxtBytes = Encoding.UTF8.GetBytes(CipherText);
            using var aesAlg = Aes.Create();
            aesAlg.Key = General.GetBytes(Key);
            aesAlg.IV = General.GetBytes(IV);
            aesAlg.Mode = GetMode(Mode);
            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using var memoryStream = new System.IO.MemoryStream(TxtBytes);
            using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using var streamReader = new System.IO.StreamReader(cryptoStream);
            return streamReader.ReadToEnd();
        }

        /// <summary>Validar si las llaves cumplen con los requisitos de seguridad</summary>
        /// <param name="Key">LLave a validar</param>
        /// <param name="IV">Indice a validar</param>
        public bool CheckReqKeys (string Key,string IV) {
            if (string.IsNullOrEmpty(Key)) {
                ResCheck = "Key Empty";
                return false;
            }
            if (string.IsNullOrEmpty(IV)) {
                ResCheck = "IV Empty";
                return false;
            }
            if (Key.Length < 32) {
                ResCheck = "The key is less than 32 characters";
                return false;
            }
            if ( (IV.Length<16 || IV.Length > 128)){
                ResCheck = "IV does not comply with requirements, minimum 16 characters and maximum 128";
                return false;
            }
            return true;
        }

        private CipherMode GetMode(CryptoMode Mode) {
            switch (Mode) {
                case CryptoMode.CBC:return CipherMode.CBC;
                case CryptoMode.ECB:return CipherMode.ECB;
                case CryptoMode.CFB:return CipherMode.CFB;
                case CryptoMode.CTS:return CipherMode.CTS;
                default: return CipherMode.CBC;
            }
        }
    }
}