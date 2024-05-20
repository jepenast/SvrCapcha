using Crypto;

namespace SvrCaptcha.CoreUtils {
    public class Utils {

        /// <summary>Convierte un formato de fecha y hora a formato unix</summary>
        /// <param name="TimeS">Fecha y hora a transformar</param>
        /// <returns>Un numero con el formato en unix que representa el tiempo indicado</returns>
        public long ConvertToUnixTimeStamp (DateTime TimeS) {
            //long UnixTimeStamp = (long)(TimeS - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            long UnixTimeStamp = (long)(TimeS - DateTime.UnixEpoch).TotalSeconds;
            return UnixTimeStamp;
        }

        /// <summary>Convierte un formato unix a formato de fecha y hora</summary>
        /// <param name="UnixFormat">formato unix transformar</param>
        /// <returns>un dato en Datetime con la fecha y hora que representaba el formato unix</returns>
        public DateTime ConvertUnixToDateTime (long UnixFormat) {
            //DateTime DateFormat = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime DateFormat = DateTime.UnixEpoch;
            return DateFormat.AddSeconds(UnixFormat);
        }

        /// <summary>Genera un hash de la informacion con un tamaño maximo de 32 caracteres</summary>
        /// <param name="Txt">Texto a generar el hash</param>
        public string GenerateHashSha (string Txt) {
            Sha256 Sha256 = new();
            return Sha256.CompactHash(Sha256.GenHashSha256(Txt), 32);
        }

        /// <summary>Genera un hash de la informacion con un tamaño maximo de 32 caracteres</summary>
        /// <param name="Txt">Texto a generar el hash</param>
        public string GenerateHashMD5 (string Txt) {
            MD5 HMD5 = new();
            return HMD5.CalculateMD5(Txt);
        }

        public string GenerateSalt () {
            return new Salt().Generate(32);
        }
    }
}
