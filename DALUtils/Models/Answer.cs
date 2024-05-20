
namespace DALUtils.Models {
    public class AnswerCaptcha {
        public string Id { get; set; }
        public string Answer { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsCorrect { get; set; }


        public AnswerCaptcha() { 
            Id = string.Empty;
            Answer = string.Empty;
            Timestamp = DateTime.MinValue;
            IsCorrect = false;
        }
    }
}
