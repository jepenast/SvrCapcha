using SvrCaptcha.Models;

namespace SvrCaptcha.Interface {
    public interface IKeyAppService {

        string GenerateKey (string NameApp);

        bool ValideKey(string key,string value);

        string GetValue(string key,string Url);

        KeyApp GenerateValueKey (string Key, string NameApp, DateTime StartTimeLife, DateTime EndTimeLife);

    }
}
