namespace DALUtils.Models {
    public class Captcha {

        public string Id { get; set;}
        public string ImgB64 { get; set; }
        public string KeyApp { get; set; }
        public DateTime TimeStamp { get; set; }

        public Captcha() { 
            Id=string.Empty;
            ImgB64=string.Empty;
            KeyApp=string.Empty;
            TimeStamp=DateTime.Now; 
        }
    }
}
