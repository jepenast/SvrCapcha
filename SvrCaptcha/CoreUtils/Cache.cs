using System.Text.Json;

namespace SvrCaptcha.CoreUtils {
    public class Cache {

        private readonly ConfigApp Cfg;
        private readonly DALUtils.SQLite.Context DataCache;
        private readonly string PathFile;

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public Cache() {
            Cfg = new ConfigApp();
            Cfg.LoadConfig();
            PathFile = Cfg.PathCache;
        }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.

        /// <summary>Valida si una aplicacion esta bloqueada</summary>
        /// <param name="Key">Llave de la apliacion para validar</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Models.BlockApp CheckBlock (string Key) {
            Models.BlockApp Data = new();
            try{
                Data=new CoreUtils.Data().CheckBlock(Key);
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return Data;
        }

        public Dictionary<string,string> GetAnswer () {
            Dictionary<string, string> Ans= new ();
            try {
                Ans = DataCache.ReadAnswers();
            }catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return Ans;
        }
    }
}
