using System.Security.Cryptography;
using System.Text;

namespace Crypto {
    public class Sha256 {
        public string GenHashSha256(string TxtIn) {
            using SHA256 Sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(TxtIn);
            byte[] hashBytes = Sha256.ComputeHash(bytes);
            StringBuilder SB = new();
            foreach (byte b in hashBytes) {
                SB.Append(b.ToString("x2"));
            }
            return SB.ToString();
        }

        public string CompactHash(string Hash,int Size) {
            if (Hash.Length>=Size) {
                return Hash;
            } 
            if ((Hash.Length/2)>Size) {
                //return Hash.Substring(1,Size/2)+Hash.Substring(Hash.Length-(Size/2));
                return Hash.AsSpan(1,Size/2).ToString()+Hash.AsSpan(Hash.Length-(Size/2)).ToString();
            }else{
                return Hash.Substring(1, Size);
            }
        }
    }
}
