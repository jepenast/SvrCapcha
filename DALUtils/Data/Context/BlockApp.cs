using DALUtils.Models;
using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace DALUtils.Data.Context {
    public class BlockApp:IDisposable {

        private readonly IInfoserver InfServer;
        private readonly ParamBuiler PrBuiler;

        public BlockApp (IInfoserver Server) {
            InfServer = Server;
            PrBuiler = new ();
        }

        ~BlockApp () {
            Dispose();
        }

        public void Dispose () {
            GC.SuppressFinalize(this);
        }

        public BlockAccess GetLockApp(string KeyApp) {
            BlockAccess Result = new();
            SqlParameter Param = PrBuiler.CreateParam("@Key",KeyApp);
            try {
                using ExecuteCmd Exec = new(InfServer);
                using SqlDataReader DR = Exec.StoreProcedure("spGetBlockApp", Param);
                if (DR.HasRows) {
                    DR.Read();
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                    Result = JsonSerializer.Deserialize<BlockAccess>(DR.GetString(0));
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                }
            } catch (Exception EX) {
                new ErrorHandler().GetError(EX);
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return Result;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public bool UnlockApp(string KeyApp) {
            bool Result=false;
            SqlParameter Param = PrBuiler.CreateParam("@KeyApp", KeyApp);
            try {
                using ExecuteCmd Exec = new(InfServer);
                using SqlDataReader DR = Exec.StoreProcedure("spUnlockApp", Param);
                if (DR.HasRows) {
                    DR.Read();
                    Result = DR.GetBoolean(0);
                }
            } catch (Exception EX) {
                new ErrorHandler().GetError(EX);
            }
            return Result;
        }

    }
}
