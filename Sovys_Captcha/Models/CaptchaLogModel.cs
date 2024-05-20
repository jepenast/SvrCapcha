namespace Sovys_Captcha.Models {

    public class CaptchaLogModel {
        public int Id { get; set; }
        public string CaptchaId { get; set; }
        public string UserAnswer { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsCorrect { get; set; }
    }
}
