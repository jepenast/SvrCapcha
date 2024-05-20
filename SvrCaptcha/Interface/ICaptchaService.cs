namespace SvrCaptcha.Interface {
    public interface ICaptchaService {

        Models.Captcha GenerateCaptcha(string KeyApp);
        bool ValideCaptcha (string Id,string Answer,string ImgB64);
        bool ValideBlock (string Key);

    }
}
