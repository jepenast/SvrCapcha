using Sovys_Captcha.Models;

namespace Sovys_Captcha.Interface {
    public interface ICaptchaService {
        CaptchaModel GenerateCaptcha ();
        bool ValidateCaptcha (string captchaId, string answer);
        //void SaveCaptchaLog (string captchaId, string userAnswer, bool isCorrect);
    }

}
