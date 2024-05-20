
namespace DALUtils.Models {
    public interface IApplication {
        
        string Name { get; set; }

        string Value{get; set;}

        string TypeApp{ get; set; }

        string URL{get; set;}

        string IdOwner{ get; set;}

        string Owner {get; set;}    

        string Email{get; set;}

        int LockAppTime {get;set;}
    }
}
