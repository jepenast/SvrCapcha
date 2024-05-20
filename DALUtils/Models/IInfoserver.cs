
namespace DALUtils.Models {
    public interface IInfoserver {

        string Server{ get; set; }

        string Database {get; set;}

        string UserName{get; set;}

        string Password{get; set;} 
    }
}
