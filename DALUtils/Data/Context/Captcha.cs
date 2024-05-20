using DALUtils.Models;
using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace DALUtils.Data.Context {

    public class Captcha {

        private readonly IInfoserver InfServer;
        private readonly ParamBuiler PrBuiler;

        public Captcha(IInfoserver Server) {
            InfServer = Server;
            PrBuiler = new();
        }


        ~Captcha () {
            Dispose();
        }

        public void Dispose () {
            GC.SuppressFinalize(this);
        }

        public string Insert(Models.Captcha Data) {
            string Result = string.Empty;
            SqlParameter[] Param= PrBuiler.CreateParamsCaptcha(Data);
            try{
                using ExecuteCmd Exec = new(InfServer);
                using SqlDataReader DR = Exec.StoreProcedure("spSetCaptcha", Param);
                if (DR.HasRows) {
                    DR.Read();
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                    Result = DR.ToString();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                }
            } catch(Exception EX) {
                new ErrorHandler().GetError(EX);
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return Result;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public Models.Captcha GetCaptcha(string Key) {
            Models.Captcha Result = new();
            try{
                SqlParameter Param = PrBuiler.CreateParam("@IdKey",Key);
                using ExecuteCmd Exec = new(InfServer);
                using SqlDataReader DR = Exec.StoreProcedure("spGetCaptcha", Param);
                if (DR.HasRows) {
                    DR.Read();
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                    Result = JsonSerializer.Deserialize<Models.Captcha>(DR.GetString(0));
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                    DR.Close();
                }
            } catch (Exception EX) {
                new ErrorHandler().GetError(EX);
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return Result;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public Models.AnswerCaptcha GetAnswer(string IdCapcha) {
            Models.AnswerCaptcha Result = new();
            try {
                SqlParameter Param = PrBuiler.CreateParam("@IdCapcha", IdCapcha);
                using ExecuteCmd Exec = new(InfServer);
                using SqlDataReader DR = Exec.StoreProcedure("spGetAnswer", Param);
                if (DR.HasRows) {
                    DR.Read();
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                    Result = JsonSerializer.Deserialize<Models.AnswerCaptcha>(DR.GetString(0));
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                    DR.Close();
                }
            } catch (Exception EX) {
                new ErrorHandler().GetError(EX);
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return Result;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public string SetAnswer(Models.AnswerCaptcha Answer) {
            string Result=string.Empty;
            try {
                SqlParameter[] Param = PrBuiler.CreateAnswer(Answer);
                using ExecuteCmd Exec = new(InfServer);
                using SqlDataReader DR = Exec.StoreProcedure("spSetAnswer", Param);
                if (DR.HasRows) {
                    DR.Read();
                    Result = DR.GetGuid(DR.GetOrdinal("@IdAnwer")).ToString();
                }
            } catch (Exception EX) {
                new ErrorHandler().GetError(EX);
            }
            return Result;
        }

        public string SetCaptcha(Models.Captcha Capcha) {
            string Result=string.Empty;
            try {
                SqlParameter[] Param = PrBuiler.CreateParamsCaptcha(Capcha);
                using ExecuteCmd Exec = new(InfServer);
                using SqlDataReader DR = Exec.StoreProcedure("spSetCaptcha", Param);
                if (DR.HasRows) {
                    DR.Read();
                    Result = DR.GetString(0).ToString();
                }
            } catch (Exception EX) {
                new ErrorHandler().GetError(EX);
            }
            return Result;
        }

        public Models.Attemps GetAttemps (string KeyApp) {
            Attemps Result = new();
            try {
                SqlParameter Param = PrBuiler.CreateParam("@KeyApp",KeyApp);
                using ExecuteCmd Exec = new(InfServer);
                using SqlDataReader DR = Exec.StoreProcedure("spSetAnswer", Param);
                if (DR.HasRows) {
                    DR.Read();
                    Result = new() {
                        Key = DR.GetString(0),
                        NameApp = DR.GetString(1),
                        Attemp = DR.GetString(2),
                        TimeStampStart = DR.GetDateTime(3),
                        TimeStampLast = DR.GetDateTime(4),
                        IdAttemp = DR.GetString(5)
                    };
                }
            } catch (Exception EX) {
                new ErrorHandler().GetError(EX);
            }
            return Result;
        }
    }
}
