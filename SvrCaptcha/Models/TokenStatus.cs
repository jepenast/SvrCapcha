namespace SvrCaptcha.Models {
    public enum TokenStatus {
        Ok = 1,
        ExpiredToken = 2,
        InvalidToken = 3,
        NotAutorized = 4
    }
}
