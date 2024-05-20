namespace SvrCaptcha.Models {
    public class BlockApp {

        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime StartDim { get; set; }
        public DateTime EndDim { get; set; }

        public BlockApp() { 
            Key=string.Empty; 
            Value=string.Empty; 
            StartDim=DateTime.Now; 
            EndDim=DateTime.Now;
        }
    }
}
