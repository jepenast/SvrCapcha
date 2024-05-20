using DALUtils.Models;
using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace DALUtils.Data.Context {
    public class Application:IDisposable {

        private readonly IInfoserver InfServer;
        private readonly ParamBuiler PrBuiler;

        public Application (IInfoserver Server) {
            InfServer = Server;
            PrBuiler = new ();
        }

        ~Application () {
            Dispose();
        }

        public void Dispose () {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose (bool disposing) {
            if (disposing) {
                GC.SuppressFinalize(PrBuiler);
            }
        }

        /// <summary>Genera un registro de una aplicacion</summary>
        /// <param name="App">Informacion de la aplicacion a registrar</param>
        /// <returns></returns>
        public string Register (IApplication App) {
            string Result = string.Empty;
            SqlParameter[] Param = PrBuiler.CreateParamsApp(App);
            try {
                using ExecuteCmd Exec = new(InfServer);
                using SqlDataReader DR = Exec.StoreProcedure("spRegisterAp", Param);
                if (DR.HasRows) {
                    DR.Read();
                    Result = DR.GetGuid(DR.GetOrdinal("@KEYAPP")).ToString();
                }
            } catch (Exception EX) {
                new ErrorHandler().GetError(EX);
            }
            return Result;
        }

        /// <summary>Obtiene los datos de una aplicacion registrada</summary>
        /// <param name="KeyApp">Llave de registro de la aplicacion</param>
        public IApplication GetInformation(string KeyApp) {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            IApplication App=null;
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            SqlParameter Param = PrBuiler.CreateParam("@KeyApp",KeyApp);
            try {
                using ExecuteCmd Exec = new(InfServer);
                using SqlDataReader DR = Exec.StoreProcedure("spGetInfoAPP", Param);
                if (DR.HasRows) {
                    DR.Read();
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                    App = JsonSerializer.Deserialize<IApplication>(DR.GetString(0));
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                }
            } catch (Exception EX) {
                new ErrorHandler().GetError(EX);
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return App;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        /// <summary>Obtiene el Key de una aplicacion por el nombre</summary>
        /// <param name="NameApp">Nombre de la aplicacion</param>
        public Models.KeyAppActive GetKeyApp(string NameApp) {
            KeyAppActive App =new();
            SqlParameter Param = PrBuiler.CreateParam("@AppName", NameApp);
            try {
                using ExecuteCmd Exec = new(InfServer);
                using SqlDataReader DR = Exec.StoreProcedure("spGetKeyApp", Param);
                if (DR.HasRows) {
                    DR.Read();
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                    App = JsonSerializer.Deserialize<KeyAppActive>(DR.GetString(0));
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                }
            } catch (Exception EX) {
                new ErrorHandler().GetError(EX);
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return App;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public Models.KeyAppActive GetKeyValue(string Key) {
            KeyAppActive App = new();
            SqlParameter Param = PrBuiler.CreateParam("Key", Key);
            try {
                using ExecuteCmd Exec = new(InfServer);
                using SqlDataReader DR = Exec.StoreProcedure("spGetKeyValue",Param);
                if (DR.HasRows) {
                    DR.Read();
                    App = JsonSerializer.Deserialize<KeyAppActive>(DR.GetString(0));
                }
            }catch (Exception EX) {
                new ErrorHandler().GetError(EX);
            }
            return App;
        }

        public bool GetValideAccessUrl(string Key,string Url) {
            bool Result=false;
            SqlParameter[] Param = PrBuiler.CreateParamUrl(Key,Url);
            try {
                using ExecuteCmd Exec = new (InfServer);
                using SqlDataReader DR = Exec.StoreProcedure("spGetAccessUrl", Param);
                if (DR.HasRows) {
                    DR.Read();
                    Result = bool.Parse(DR.GetString(0));
                }
            } catch (Exception EX) {
                new ErrorHandler().GetError(EX);
            }
            return Result;
        }
    }
}
