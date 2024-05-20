using System.Security.Cryptography;
using System.Text;

namespace Crypto {
    public class Aes_Gcm {

        private string ResCheck {get;set;}

        public Aes_Gcm () {
            ResCheck=string.Empty;
        }


        /// <summary>Encripta una cadena de texto utilizando AES con una clave y un vector de inicialización (IV) específicos.</summary>
        /// <param name="Text">Texto a cifrar</param>
        /// <param name="Key">LLave de encriptacion</param>
        /// <param name="IV">Inicializacion del vector del mapa de encriptacion</param>
        public string Encrypt (string Text, string Key, string IV) {
            if (CheckReqKeys(Key, IV)) {
                return ResCheck;
            }
            byte[] TxtBytes = Encoding.UTF8.GetBytes(Text);
            byte[] CPText = new byte[TxtBytes.Length];
            byte[] Tag = new byte[16]; // Tag de autenticación de 128 bits
            using (AesGcm Gcm = new AesGcm(General.GetBytes(Key))) {
                Gcm.Encrypt(General.GetBytes(IV), TxtBytes, CPText, Tag);
            }
            return Encoding.UTF8.GetString(CPText.ToArray());
        }

        /// <summary>Desencripta datos encriptados utilizando AES con una clave y un vector de inicialización (IV) específicos</summary>
        /// <param name="CipherText">Texto Cifrado</param>
        /// <param name="Key">LLave de encriptacion</param>
        /// <param name="IV">Inicializacion del vector del mapa de encriptacion</param>
        public string Decrypt (string CipherText, string Key, string IV) {
            byte[] TxtBytes = Encoding.UTF8.GetBytes(CipherText);
            byte[] DecryptTxt = new byte[TxtBytes.Length];
            byte[] Tag = new byte[16]; // Tag de autenticación de 128 bits
            using (AesGcm aesGcm = new AesGcm(Encoding.UTF8.GetBytes(Key))) {
                aesGcm.Decrypt(General.GetBytes(IV), TxtBytes, Tag, DecryptTxt);
            }
            return Encoding.UTF8.GetString(DecryptTxt.ToArray());
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
    }
}