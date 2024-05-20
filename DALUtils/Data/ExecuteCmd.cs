using DALUtils.Models;
using Microsoft.Data.SqlClient;
namespace DALUtils.Data {
    internal class ExecuteCmd:IDisposable {


        private readonly Connection Conn;

        public ExecuteCmd(IInfoserver Server) {
            Conn = new Connection(Server,true);
        }

        ~ExecuteCmd() {
            Dispose();
        }

        public void Dispose () {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose (bool disposing) {
            if (disposing) {
                Conn.Dispose();
            }
        }

        public SqlDataReader StoreProcedure (string Command, SqlParameter Params) {
            SqlParameter[] Param= new SqlParameter[1];
            Param[1]= Params;
            return StoreProcedure(Command, Param);
        }

        public SqlDataReader StoreProcedure(string Command,SqlParameter[] Params) {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            SqlDataReader DR=null;
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            try{
                if (Conn.IsConnect){
                    using SqlCommand cmd = new(Command, Conn.OpenConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(Params);
                    cmd.CommandTimeout = 10;
                    DR = cmd.ExecuteReader();
                }
            }catch (Exception ex) {
                Exception Rex=new ErrorHandler().GetError(ex);
                throw new Exception(Rex.Message);
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return DR;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }
    }
}
