namespace SvrCaptcha.Interface {
    public interface IToken {

        string KeyApp { get;set; }
        string ValueApp {get;set;}
        DateTime TimeInit {get;set;}  

        DateTime TimeEnd{get;set;}

        string HashCert{ get;set;}
    }
}
