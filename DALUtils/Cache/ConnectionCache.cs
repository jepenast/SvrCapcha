using Microsoft.Data.Sqlite;

namespace DALUtils.SQLite {
    public class ConnectionCache {

        private string CnString{get;set;}

        public SqliteConnection OpenConn { get; private set; }
        public bool IsConnect{ get;private set;}

        public ConnectionCache (string ConnString,bool Open=false) {
            if (!string.IsNullOrEmpty(ConnString)){
                CnString = ConnString;
            } else {
                CnString= string.Empty;
            }
            if (Open) {
                OpenConnection();
            }
        }

        ~ConnectionCache () {
            CloseConnection();
        }

        public void OpenConnection () {
            try{
                OpenConn= new SqliteConnection(CnString);
                IsConnect = true;
            }catch (Exception Ex) {
                IsConnect = false;
                new ErrorHandler().ErrorConectionCache(Ex);
            }
        }

        public void CloseConnection () {
            if (IsConnect) {
                OpenConn.Close();
            }
        }
    }
}