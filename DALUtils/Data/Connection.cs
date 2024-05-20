using DALUtils.Models;
using Microsoft.Data.SqlClient;

namespace DALUtils.Data {
    internal class Connection:IDisposable {

        /// <summary>Cadena de conexion a la base de datos</summary>
        private readonly string CnString;
        /// <summary>Conexion abierta</summary>
        public SqlConnection OpenConn { get; private set; }
        /// <summary>Obtiene o establece si hay una conexion abierta</summary>
        public bool IsConnect { get; private set; }

        /// <summary>Permite la conexion a la base de datos</summary>
        /// <param name="InfoServer">Ruta del servidor</param>
        /// <param name="Open">Indica se la conexion se abre automaticamente</param>
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public Connection (IInfoserver InfoServer, bool Open = false) {
            CnString = ""+ InfoServer.Server+ ""+ InfoServer.Database+ ""+ InfoServer.UserName+ ""+InfoServer.Password;
            if (Open) {
                OpenConnection();
            }
        }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.

        ~Connection () {
            CloseConnection();
        }

        public void OpenConnection () {
            try {
                OpenConn = new SqlConnection(CnString);
                IsConnect = true;
            } catch (Exception Ex) {
                IsConnect = false;
                new ErrorHandler().ErrorConectionData(Ex);
            }
        }

        public void CloseConnection () {
            if (IsConnect) {
                OpenConn.Close();
            }
        }

        public void Dispose () {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose (bool disposing) {
            if (disposing) {
                CloseConnection();
            }
        }
    }
}
