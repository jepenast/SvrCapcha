namespace DALUtils.SQLite {
    public class CmdBuilder {

        public string InsertCache () {
            return
                "INSERT INTO tbCacheCaptcha (Id,Image,KeyApp,TimeStamp)" +
                "VALUES (@Id,@Image,@KeyApp,@TimeStamp;";
        }

        public string ReadCache () {
            return
                "SELECT Id,Image,KeyApp,TimeStamp " +
                "FROM tbCacheCaptcha " +
                "WHERE Id=@Id AND KeyApp=@KeyApp " +
                "ORDER BY TimeStamp DESC LIMIT 1;";
        }

        public string DeleteCache () {
            return "DELETE FROM tbCacheCaptcha " +
                "WHERE Id=@Id AND KeyApp=@KeyApp;";
        }

        public string ClearRegistry () {
            return "DELETE FROM tbCacheCaptcha " +
                "WHERE TimeStamp BETWEEN @Init and @End;";
        }

        public string InsertAppBlock () {
            return
                "INSERT INTO tbCacheBlock (KeyApp,Value,StartDim,EndDim) " +
                "VALUE (@KeyApp,@Value,@StartDim,@EndDim);";
        }

        public string InsertListAppBlock () {
            return
                "INSERT OR REPLACE INTO tbCacheBlock (KeyApp,Value,StartDim,EndDim) " +
                "VALUE (@KeyApp,@Value,@StartDim,@EndDim);";

        }

        public string DeleteAppBlock () {
            return "DELETE FROM tbCacheBlock " +
                "WHERE KeyApp=@KeyApp;";
        }

        public string ClearAppBlocks () {
            return "DELETE " +
                "FROM tbCacheBlock;";
        }

        public string ReadAnswer () {
            return "SELECT " +
                "Id," +
                "Answer " +
                "FROM tbCacheAnswer;";
        }
    }
}
