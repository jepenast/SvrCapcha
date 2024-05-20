using System.Text;

namespace Crypto {
    public class MD5 {

        public string CalculateMD5 (string Input) {
            byte[] Bytes = Encoding.UTF8.GetBytes(Input);
            uint a = 0x67452301;
            uint b = 0xefcdab89;
            uint c = 0x98badcfe;
            uint d = 0x10325476;
            for (int i = 0; i < Bytes.Length; i += 64) {
                uint[] x = new uint[16];
                int index = 0;
                for (int j = i; j < i + 64; j += 4) {
                    x[index++] = (uint)((Bytes[j] & 0xff) | ((Bytes[j + 1] & 0xff) << 8) | ((Bytes[j + 2] & 0xff) << 16) | ((Bytes[j + 3] & 0xff) << 24));
                }
                uint aa = a;
                uint bb = b;
                uint cc = c;
                uint dd = d;
                CombineR1(ref a,ref b,ref c,ref d, ref x);
                CombineR2(ref a,ref b,ref c, ref d, ref x);
                CombineR3(ref a, ref b, ref c, ref d, ref x);
                CombineR4(ref a, ref b, ref c, ref d, ref x);
                a += aa;
                b += bb;
                c += cc;
                d += dd;
            }

            byte[] result = new byte[16];
            Array.Copy(BitConverter.GetBytes(a), 0, result, 0, 4);
            Array.Copy(BitConverter.GetBytes(b), 0, result, 4, 4);
            Array.Copy(BitConverter.GetBytes(c), 0, result, 8, 4);
            Array.Copy(BitConverter.GetBytes(d), 0, result, 12, 4);
            return ByteArrayToString(result);
        }

        private void CombineR1 (ref uint a,ref uint b, ref uint c, ref uint d, ref uint[] x) {
            Round1(ref a, b, c, d, x[0], 7, 0xd76aa478);
            Round1(ref d, a, b, c, x[1], 12, 0xe8c7b756);
            Round1(ref c, d, a, b, x[2], 17, 0x242070db);
            Round1(ref b, c, d, a, x[3], 22, 0xc1bdceee);
            Round1(ref a, b, c, d, x[4], 7, 0xf57c0faf);
            Round1(ref d, a, b, c, x[5], 12, 0x4787c62a);
            Round1(ref c, d, a, b, x[6], 17, 0xa8304613);
            Round1(ref b, c, d, a, x[7], 22, 0xfd469501);
            Round1(ref a, b, c, d, x[8], 7, 0x698098d8);
            Round1(ref d, a, b, c, x[9], 12, 0x8b44f7af);
            Round1(ref c, d, a, b, x[10], 17, 0xffff5bb1);
            Round1(ref b, c, d, a, x[11], 22, 0x895cd7be);
            Round1(ref a, b, c, d, x[12], 7, 0x6b901122);
            Round1(ref d, a, b, c, x[13], 12, 0xfd987193);
            Round1(ref c, d, a, b, x[14], 17, 0xa679438e);
            Round1(ref b, c, d, a, x[15], 22, 0x49b40821);
        }

        private void CombineR2 (ref uint a, ref uint b, ref uint c, ref uint d, ref uint[] x) {
            Round2(ref a, b, c, d, x[1], 5, 0xf61e2562);
            Round2(ref d, a, b, c, x[6], 9, 0xc040b340);
            Round2(ref c, d, a, b, x[11], 14, 0x265e5a51);
            Round2(ref b, c, d, a, x[0], 20, 0xe9b6c7aa);
            Round2(ref a, b, c, d, x[5], 5, 0xd62f105d);
            Round2(ref d, a, b, c, x[10], 9, 0x02441453);
            Round2(ref c, d, a, b, x[15], 14, 0xd8a1e681);
            Round2(ref b, c, d, a, x[4], 20, 0xe7d3fbc8);
            Round2(ref a, b, c, d, x[9], 5, 0x21e1cde6);
            Round2(ref d, a, b, c, x[14], 9, 0xc33707d6);
            Round2(ref c, d, a, b, x[3], 14, 0xf4d50d87);
            Round2(ref b, c, d, a, x[8], 20, 0x455a14ed);
            Round2(ref a, b, c, d, x[13], 5, 0xa9e3e905);
            Round2(ref d, a, b, c, x[2], 9, 0xfcefa3f8);
            Round2(ref c, d, a, b, x[7], 14, 0x676f02d9);
            Round2(ref b, c, d, a, x[12], 20, 0x8d2a4c8a);
        }

        private void CombineR3 (ref uint a, ref uint b, ref uint c, ref uint d, ref uint[] x) {
            Round3(ref a, b, c, d, x[5], 4, 0xfffa3942);
            Round3(ref d, a, b, c, x[8], 11, 0x8771f681);
            Round3(ref c, d, a, b, x[11], 16, 0x6d9d6122);
            Round3(ref b, c, d, a, x[14], 23, 0xfde5380c);
            Round3(ref a, b, c, d, x[1], 4, 0xa4beea44);
            Round3(ref d, a, b, c, x[4], 11, 0x4bdecfa9);
            Round3(ref c, d, a, b, x[7], 16, 0xf6bb4b60);
            Round3(ref b, c, d, a, x[10], 23, 0xbebfbc70);
            Round3(ref a, b, c, d, x[13], 4, 0x289b7ec6);
            Round3(ref d, a, b, c, x[0], 11, 0xeaa127fa);
            Round3(ref c, d, a, b, x[3], 16, 0xd4ef3085);
            Round3(ref b, c, d, a, x[6], 23, 0x04881d05);
            Round3(ref a, b, c, d, x[9], 4, 0xd9d4d039);
            Round3(ref d, a, b, c, x[12], 11, 0xe6db99e5);
            Round3(ref c, d, a, b, x[15], 16, 0x1fa27cf8);
            Round3(ref b, c, d, a, x[2], 23, 0xc4ac5665);
        }

        private void CombineR4 (ref uint a, ref uint b, ref uint c, ref uint d, ref uint[] x) {
            Round4(ref a, b, c, d, x[0], 6, 0xf4292244);
            Round4(ref d, a, b, c, x[7], 10, 0x432aff97);
            Round4(ref c, d, a, b, x[14], 15, 0xab9423a7);
            Round4(ref b, c, d, a, x[5], 21, 0xfc93a039);
            Round4(ref a, b, c, d, x[12], 6, 0x655b59c3);
            Round4(ref d, a, b, c, x[3], 10, 0x8f0ccc92);
            Round4(ref c, d, a, b, x[10], 15, 0xffeff47d);
            Round4(ref b, c, d, a, x[1], 21, 0x85845dd1);
            Round4(ref a, b, c, d, x[8], 6, 0x6fa87e4f);
            Round4(ref d, a, b, c, x[15], 10, 0xfe2ce6e0);
            Round4(ref c, d, a, b, x[6], 15, 0xa3014314);
            Round4(ref b, c, d, a, x[13], 21, 0x4e0811a1);
            Round4(ref a, b, c, d, x[4], 6, 0xf7537e82);
            Round4(ref d, a, b, c, x[11], 10, 0xbd3af235);
            Round4(ref c, d, a, b, x[2], 15, 0x2ad7d2bb);
            Round4(ref b, c, d, a, x[9], 21, 0xeb86d391);
        }

        static void Round1 (ref uint a, uint b, uint c, uint d, uint x, int s, uint t) {
            a = b + RotateLeft((a + ((b & c) | (~b & d)) + x + t), s);
        }

        static void Round2 (ref uint a, uint b, uint c, uint d, uint x, int s, uint t) {
            a = b + RotateLeft((a + ((b & d) | (c & ~d)) + x + t), s);
        }

        static void Round3 (ref uint a, uint b, uint c, uint d, uint x, int s, uint t) {
            a = b + RotateLeft((a + (b ^ c ^ d) + x + t), s);
        }

        static void Round4 (ref uint a, uint b, uint c, uint d, uint x, int s, uint t) {
            a = b + RotateLeft((a + (c ^ (b | ~d)) + x + t), s);
        }

        static uint RotateLeft (uint x, int n) {
            return (x << n) | (x >> (32 - n));
        }

        static string ByteArrayToString (byte[] array) {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < array.Length; i++) {
                builder.Append(array[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
