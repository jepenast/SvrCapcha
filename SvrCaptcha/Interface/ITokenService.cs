using SvrCaptcha.Models;

namespace SvrCaptcha.Interface {
    public interface ITokenService {

        string GenerateToken(string KeyApp, string ValueApp);

        string RefreshToken (string Token);

        TokenStatus ValideToken (string Token);

        TokenModel ExtractToken (string Token);
    }
}
