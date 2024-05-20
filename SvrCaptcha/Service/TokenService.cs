using SvrCaptcha.Interface;
using SvrCaptcha.CoreUtils;
using SvrCaptcha.Models;

namespace SvrCaptcha.Service {
    public class TokenService:ITokenService {

        private readonly Utils Utl;
        private readonly CoreUtils.Crypto Crypto;

        public TokenService () {
            Utl = new();
            Crypto = new();
        }
    

        /// <summary>Generar un token</summary>
        /// <param name="IdS">id de la subscripcion existente</param>
        /// <param name="IdCon">id de la conexion a realizar</param>
        /// <param name="IdUser">id del usuario</param>
        public string GenerateToken (string KeyApp,string ValueApp) {
            DateTime DateNow = DateTime.Now;
            string NToken = $"{KeyApp}:{ValueApp}:{Utl.ConvertToUnixTimeStamp(DateNow)}:" +
                $"{Utl.ConvertToUnixTimeStamp(DateNow.AddMinutes(ConfigApp.Instance.MaxTimeToken))}";
            string Hash = Utl.GenerateHashMD5(NToken);
            NToken += $":{Hash}";
            NToken = Crypto.EncryptAES(NToken, ConfigApp.Instance.KeyAES);
            return NToken;
        }


        /// <summary>Actualizar el token</summary>
        /// <param name="Token">Token que  se va a actualizar</param>
        public string RefreshToken (string Token) {
            if (ValideToken(Token) == TokenStatus.Ok) {
                Token = Crypto.DecryptAES(Token, ConfigApp.Instance.KeyAES);
                string[] DataTk = Token.Split(':');
                return GenerateToken(DataTk[1], DataTk[2]);
            } else {
                return ValideToken(Token).ToString();
            }
        }

        /// <summary>Validar que el token actual sea valido y cuente con acceso</summary>
        /// <param name="Token">Token a validar</param>
        public Models.TokenStatus ValideToken (string Token) {
            Token = Crypto.DecryptAES(Token, ConfigApp.Instance.KeyAES);
            string[] DataTk = Token.Split(':');
            Token = $"{DataTk[0]}:{DataTk[1]}:{DataTk[2]}:{DataTk[3]}:{DataTk[4]}";
            string Hash = Utl.GenerateHashMD5(Token);
            if (DataTk[5] == Hash) {
                DateTime DateN = Utl.ConvertUnixToDateTime(long.Parse(DataTk[4]));
                if (DateN <= DateTime.Now) {
                    if (new KeyAppService().ValideKey(DataTk[0],DataTk[1])) {
                        return Models.TokenStatus.Ok;
                    } else {
                        return Models.TokenStatus.NotAutorized;
                    }
                } else {
                    return Models.TokenStatus.ExpiredToken;
                }
            } else {
                return Models.TokenStatus.InvalidToken;
            }
        }

        /// <summary>Obtener los datos que estan en el token</summary>
        /// <param name="Token">Token a capturar los datos</param>
        public TokenModel ExtractToken (string Token) {
            Token = Crypto.DecryptAES(Token, ConfigApp.Instance.KeyAES);
            string[] DataTk = Token.Split(':');
            return new TokenModel() {
                KeyApp = DataTk[0],
                ValueApp = DataTk[1],
                TimeInit = DateTime.Parse(DataTk[2]),
                TimeEnd = DateTime.Parse(DataTk[3]),
                HashCert = DataTk[4]
            };
        }
    }
}
