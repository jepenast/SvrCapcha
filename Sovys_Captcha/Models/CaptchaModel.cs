namespace Sovys_Captcha.Models {
    public class CaptchaModel {
        public string Id { get; set; }
        public string ImageBase64 { get; set; }
        public string Answer { get; set; }
    }
}
