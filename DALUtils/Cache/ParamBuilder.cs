using DALUtils.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System.Data;

namespace DALUtils.SQLite {
    internal class ParamBuilder {

        public SqliteParameter CreateParam (string Param, object value) {
            return new SqliteParameter("@"+Param, value);
        }

        public SqliteParameter[] CreateParams (Captcha Data) {
            SqliteParameter[] Params = new SqliteParameter[] {
                new SqliteParameter("@Id",Data.Id),
                new SqliteParameter("@Image",Data.ImgB64),
                new SqliteParameter("@KeyApp",Data.KeyApp),
                new SqliteParameter("@TimeStamp",Data.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            return Params;
        }

        public SqliteParameter[] BlockAccess (BlockAccess Data) {
            SqliteParameter[] Params = new SqliteParameter[] {
                new SqliteParameter("@KeyApp",Data.KeyApp),
                new SqliteParameter("@Value",Data.Value),
                new SqliteParameter("@StartDim",Data.StartDim.ToString("u")),
                new SqliteParameter("@EndDim",Data.EndDim)
            };
            return Params;
        }

        public SqlParameter[] InsertListAppBlock (DataRow Data) {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            return new SqlParameter[] {
                (SqlParameter)(new SqlParameter("@KeyApp",DbType.String).Value=Data[0].ToString().Trim()),
                (SqlParameter)(new SqlParameter("@Value",DbType.String).Value=Data[1].ToString().Trim()),
                (SqlParameter)(new SqlParameter("@StartDim",DbType.String).Value=Data[2].ToString().Trim()),
                (SqlParameter)(new SqlParameter("@EndDim",DbType.String).Value=Data[3].ToString().Trim()),
            };
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
        }
    }
}
