using Crypto;

namespace SvrCaptcha.CoreUtils {
    public class Crypto {

        public string DecryptAES (string EncTxt, string Keys) {
            AES CrAES = new();
            return CrAES.Decrypt(EncTxt, ExtractKey(Keys,1), ExtractKey(Keys,2), AES.CryptoMode.CBC);
        }

        public string EncryptAES (string Txt, string Keys) {
            AES CrAES = new();
            return CrAES.Encrypt(Txt, ExtractKey(Keys, 1), ExtractKey(Keys, 2), AES.CryptoMode.CBC);
        }

        public string EncodeB64 (string Txt) {
            Base64 B64 = new();
            return B64.Encode(Txt);
        }

        public string EncodeB64FromBytes (byte[] Data) {
            Base64 B64 = new();
            return B64.EncodeFromBytes(Data);
        }

        public string DecodeB64 (string Txt) {
            Base64 B64 = new();
            return B64.Decode(Txt);
        }

        public string EncryptAESGCM(string Txt,string Keys) {
            Aes_Gcm CrAES=new();
            return CrAES.Encrypt(Txt, ExtractKey(Keys, 1), ExtractKey(Keys, 2));
        }

        public string DencryptAESGCM (string Txt, string Keys) {
            Aes_Gcm CrAES = new();
            return CrAES.Decrypt(Txt, ExtractKey(Keys, 1), ExtractKey(Keys, 2));
        }

        public string DecodeHex (string HexTxt) {
            return General.HexToStr(HexTxt);
        }

        public string ExtractKey(string Key,int Part) {
            string Str=DecodeB64(DecodeHex(Key));
            string[] Parts = Str.Split("|");
            return Parts[Part-1];
        }
    }
}
