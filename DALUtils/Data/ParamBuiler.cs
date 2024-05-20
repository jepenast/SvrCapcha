using DALUtils.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DALUtils.Data {
    public class ParamBuiler {

        public SqlParameter CreateParam (string Param, object value) {
            return new ("@" + Param, value);
        }

        public SqlParameter[] CreateParamsCaptcha (Captcha Data) {
            SqlParameter[] Param= new SqlParameter[] {
                new ("@Id",Data.Id),
                new ("@Image",Data.ImgB64),
                 new ("@KeyApp",Data.KeyApp),
                new ("@TimeStamp",Data.TimeStamp.ToString("u"))
            };
            Param[0].DbType = DbType.String;
            Param[1].DbType = DbType.String;
            Param[2].DbType = DbType.String;
            Param[3].DbType = DbType.DateTime;
            return Param;
        }

        public SqlParameter[] CreateAnswer (AnswerCaptcha Answer) {
            SqlParameter[] Param = new SqlParameter[] {
                new ("@Id",Answer.Id.Trim()),
                new ("@Answer",Answer.Answer.Trim()),
                new ("@Timestamp",Answer.Timestamp.ToString("u").Trim()),
                new ("@IsCorrect",Answer.IsCorrect)
            };
            Param[0].DbType = DbType.String;
            Param[1].DbType = DbType.String;
            Param[2].DbType = DbType.DateTime;
            Param[3].DbType = DbType.Boolean;
            return Param;
        }

        public SqlParameter[] BlockAccess (BlockAccess Data) {
            SqlParameter[] Param= new SqlParameter[] {
                new ("@KeyApp",Data.KeyApp.Trim()),
                new ("@Value",Data.Value.Trim()),
                new ("@StartDim",Data.StartDim),
                new ("@EndDim",Data.EndDim)
            };
            Param[0].DbType = DbType.String;
            Param[1].DbType = DbType.String;
            Param[2].DbType = DbType.DateTime;
            Param[3].DbType = DbType.DateTime;
            return Param;
        }

        public SqlParameter[] CreateParamsApp (IApplication app) {
            SqlParameter[] Param= new SqlParameter[] {
                new ("@KeyApp",app.Name.Trim()),
                new ("@Value",app.Value.Trim()),
                new ("@StartDim",app.TypeApp.Trim()),
                new ("@EndDim",app.URL.Trim()),
            };
            Param[0].DbType = DbType.String;
            Param[1].DbType = DbType.String;
            Param[2].DbType = DbType.String;
            Param[3].DbType = DbType.String;
            return Param;
        }

        public SqlParameter[] CreateParamUrl(string Key,string Url) {
            SqlParameter[] Data=new SqlParameter[] {
               new ("@KeyApp",Key),
               new ("@URL",Url)
            };
            Data[0].SqlDbType=SqlDbType.NVarChar;
            Data[1].SqlDbType=SqlDbType.NVarChar;
            return Data;
        }
    }
}
