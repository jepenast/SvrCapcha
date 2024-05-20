using Microsoft.Data.Sqlite;
using DALUtils.Models;
using System.Data;

namespace DALUtils.SQLite {
    public class Context {

        private readonly ConnectionCache Conn;

        public Context (string StrPathDB) {
            Conn = new ConnectionCache(StrPathDB,true);
        }

        public bool InsertCaptcha (Captcha Data) {
            if (Conn.IsConnect){
                using SqliteCommand Cmd = new (new CmdBuilder().InsertCache(), Conn.OpenConn);
                Cmd.Parameters.AddRange(new ParamBuilder().CreateParams(Data));
                int Result = Cmd.ExecuteNonQuery();
                return Result > 0;
            } else {
                return false;
            }
        }

        public bool DeleteCaptcha (string KeyApp) {
            if (Conn.IsConnect) {
                using SqliteCommand Cmd = new (new CmdBuilder().DeleteCache(), Conn.OpenConn);
                Cmd.Parameters.Add(new ParamBuilder().CreateParam("@KeyApp", KeyApp));
                int Result = Cmd.ExecuteNonQuery();
                return Result > 0;
            } else {
                return false;
            }
        }

        public bool Clear () {
            if (Conn.IsConnect) {
                using SqliteCommand Cmd = new (new CmdBuilder().ClearRegistry(), Conn.OpenConn);
                Cmd.Parameters.Add(new ParamBuilder().CreateParam("@Init", DateTime.Now.ToString("yyy-MM-dd")+" 00:00:00"));
                Cmd.Parameters.Add(new ParamBuilder().CreateParam("@End", DateTime.Now.ToString("yyy-MM-dd")+" 23:59:59"));
                int Result = Cmd.ExecuteNonQuery();
                return Result > 0;
            } else {
                return false;
            }
        }

        public Captcha ReadCaptcha(string Id,string KeyApp) {
            Captcha CaptchaR = new();
            try{
                if (Conn.IsConnect) {
                    using SqliteCommand Cmd = new (new CmdBuilder().ReadCache(), Conn.OpenConn);
                    Cmd.Parameters.Add(new ParamBuilder().CreateParam("@Id",Id));
                    Cmd.Parameters.Add(new ParamBuilder().CreateParam("@KeyApp",KeyApp));
                    SqliteDataReader DR = Cmd.ExecuteReader();
                    if (DR.HasRows) {
                        DR.Read();
                        CaptchaR = new() {
                            Id = DR.GetString(0),
                            ImgB64 = DR.GetString(1),
                            KeyApp = DR.GetString(2),
                            TimeStamp = DateTime.Parse(DR.GetString(3))
                        };
                    }
                }
            } catch (SqliteException Ex){
                new ErrorHandler().ErrorConectionCache(Ex);
            }
            return CaptchaR;
        }

        public bool InsertAppBlock(BlockAccess App) {
            bool Result=false;
            try {
                if (Conn.IsConnect) {
                    using SqliteCommand Cmd = new (new CmdBuilder().InsertAppBlock(), Conn.OpenConn);
                    Cmd.Parameters.AddRange(new ParamBuilder().BlockAccess(App));
                    Result = (Cmd.ExecuteNonQuery()>0);
                } else {
                    Result=false;
                }
            }catch(SqliteException Ex) {
                new ErrorHandler().ErrorConectionCache(Ex);
            }
            return Result;
        }

        public bool InsertAppBlock(DataTable Data) {
            bool Result = false;
            try {
                if (Conn.IsConnect) {
                    try{
                        foreach(DataRow Row in Data.Rows){
                            using SqliteCommand Cmd = new (new CmdBuilder().InsertListAppBlock(), Conn.OpenConn);
                            Cmd.Parameters.AddRange(new ParamBuilder().InsertListAppBlock(Row));
                             Cmd.ExecuteNonQuery();
                        }  
                    }catch(SqliteException Ex) {
                        new ErrorHandler().GetError(Ex);
                        Result = false;
                    }
                } else {
                    Result = false;
                }
            } catch(SqliteException Ex) {
                new ErrorHandler().GetError(Ex);
            }
            return Result;
        }

        public bool DeleteAppBLock(string KeyApp) {
            bool Result = false;
            try {
                if (Conn.IsConnect) {
                    using SqliteCommand Cmd = new (new CmdBuilder().DeleteAppBlock(), Conn.OpenConn);
                    Cmd.Parameters.Add(new ParamBuilder().CreateParam("@KeyApp",KeyApp));
                    Result = (Cmd.ExecuteNonQuery()>0);
                }
            }catch(SqliteException Ex) {
                new ErrorHandler().ErrorConectionCache(Ex);
            }
            return Result;
        }

        public bool DeleteAppsBLocks () {
            bool Result = false;
            try {
                if (Conn.IsConnect) {
                    using SqliteCommand Cmd = new (new CmdBuilder().ClearAppBlocks(), Conn.OpenConn);
                    Result = (Cmd.ExecuteNonQuery() > 0);
                }
            } catch (SqliteException Ex) {
                new ErrorHandler().ErrorConectionCache(Ex);
            }
            return Result;
        }

        public Dictionary<string,string> ReadAnswers () {
            Dictionary<string, string> Result = new();
            try {
                if (Conn.IsConnect) {
                    using SqliteCommand Cmd = new(new CmdBuilder().ReadAnswer(), Conn.OpenConn);
                    using SqliteDataReader DR= Cmd.ExecuteReader();
                    if (DR.HasRows) {
                        DataTable DT = new();
                        DT.Load(DR);
                        foreach(DataRow Row in DT.Rows) {
                            Result.Add(Row.ItemArray[0].ToString(), Row.ItemArray[0].ToString());
                        }
                    }
                }
            } catch (SqliteException Ex) {
                new ErrorHandler().ErrorConectionCache(Ex);
            }
            return Result;
        }

    }
}
