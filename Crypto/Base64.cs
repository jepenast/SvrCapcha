namespace Crypto {
    public class Base64 {

        private static readonly string B64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

        public string EncodeFromBytes(byte[] Data) {
            if (Data.Length==0) {
                return "Empty Data";
            }
            return EncodeData(Data);
        }

        public string Encode (string StrData) {
            if (string.IsNullOrEmpty (StrData)){
                return "Empty Text";
            }
            byte[] Data = System.Text.Encoding.UTF8.GetBytes(StrData);
            return EncodeData(Data);
        }

        public string EncodeData(byte[] Data) {
            string Base64 = "";
            int Length = Data.Length;
            int Padding = (3 - (Length % 3)) % 3;
            for (int i = 0; i < Length; i += 3) {
                int triple = (Data[i] << 16) + (i + 1 < Length ? Data[i + 1] << 8 : 0) + (i + 2 < Length ? Data[i + 2] : 0);
                Base64 += B64Chars[(triple >> 18) & 63];
                Base64 += B64Chars[(triple >> 12) & 63];
                Base64 += B64Chars[(triple >> 6) & 63];
                Base64 += B64Chars[triple & 63];
            }
            //return Base64.Substring(0, Base64.Length - Padding) + new string('=', Padding);
            return Base64.AsSpan(0, Base64.Length - Padding).ToString() + new string('=', Padding).ToString();
        }

        public string Decode (string base64) {
            int Length = base64.Length;
            int Padding = base64[Length - 1] == '=' ? (base64[Length - 2] == '=' ? 2 : 1) : 0;
            int ArrayLength = (Length * 3 / 4) - Padding;
            byte[] Data = new byte[ArrayLength];
            int DataIndex = 0;
            for (int i = 0; i < Length; i += 4) {
                int triple = (B64Chars.IndexOf(base64[i]) << 18) +
                             (B64Chars.IndexOf(base64[i + 1]) << 12) +
                             (B64Chars.IndexOf(base64[i + 2]) << 6) +
                             (B64Chars.IndexOf(base64[i + 3]));
                Data[DataIndex++] = (byte)((triple >> 16) & 255);
                if (DataIndex < ArrayLength)
                    Data[DataIndex++] = (byte)((triple >> 8) & 255);
                if (DataIndex < ArrayLength)
                    Data[DataIndex++] = (byte)(triple & 255);
            }
            return System.Text.Encoding.UTF8.GetString(Data); ;
        }
    }
}
