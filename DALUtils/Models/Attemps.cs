namespace DALUtils.Models {
    public class Attemps {

        public string Key {get;set;}
        public string NameApp {get;set;}
        public string Attemp {get;set;}
        public DateTime TimeStampStart {get;set;}
        public DateTime TimeStampLast {get;set;}
        public string IdAttemp {get;set;}

        public Attemps () {
            Key = string.Empty;
            NameApp=string.Empty;
            Attemp = string.Empty;
            TimeStampStart = DateTime.MinValue;
            TimeStampLast = DateTime.MinValue;
            IdAttemp = string.Empty;
        }
    }
}
