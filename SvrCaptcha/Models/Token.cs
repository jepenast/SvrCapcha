using SvrCaptcha.Interface;

namespace SvrCaptcha.Models {
    public class TokenModel:IToken {

        public string KeyApp { get; set; }
        public string ValueApp { get; set; }
        public DateTime TimeInit { get; set; }
        public DateTime TimeEnd { get; set; }
        public string HashCert { get; set; }

        public TokenModel () {
            KeyApp = string.Empty;
            ValueApp = string.Empty;
            TimeInit = DateTime.MinValue;
            TimeEnd = DateTime.MinValue;
            HashCert = string.Empty;
        }
    }
}
