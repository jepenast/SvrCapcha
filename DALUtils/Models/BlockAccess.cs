
namespace DALUtils.Models {
    public class BlockAccess {

        public string KeyApp {get; set;}

        public string Value { get; set;}

        public DateTime StartDim {get; set;}

        public DateTime EndDim {get; set;}

        public BlockAccess() {
            KeyApp = string.Empty;
            Value=string.Empty; 
            StartDim = DateTime.MinValue;
            EndDim = DateTime.MinValue;
        }
    }
}
