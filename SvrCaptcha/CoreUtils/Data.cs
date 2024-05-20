using SvrCaptcha.Models;

namespace SvrCaptcha.CoreUtils {
    public class Data {

        private readonly ConfigApp Cfg;
        private DALUtils.Data.Context.Application DataApp;
        private DALUtils.Data.Context.BlockApp BlockApp;
        private DALUtils.Data.Context.Captcha DataCap;
        private readonly DALUtils.Models.IInfoserver InfServer;

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public Data() {
            Cfg = new ConfigApp();
            Cfg.LoadConfig();
            GetInfServer();
        }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.

        ~Data() {
            DataApp?.Dispose();
            BlockApp?.Dispose();
            DataCap?.Dispose();
        }

        private void GetInfServer() {
            InfServer.Server=Cfg.DBParam.Server;
            InfServer.Database=Cfg.DBParam.DBName;
            InfServer.UserName=Cfg.DBParam.UCredential;
            InfServer.Password=Cfg.DBParam.UCredential;
        }

        /// <summary>Obtiene la informacion key/value de una aplicacion</summary>
        /// <param name="Key">key a validar</param>
        public KeyApp GetKeys (string Key) {
            DataApp = new(InfServer);
            var Res=DataApp.GetKeyValue(Key);
            DataApp.Dispose();
            return new KeyApp() {
                Key = Key,
                value = Res.Value
            };
        }

        public BlockApp CheckBlock (string KeyApp) {
            BlockApp = new(InfServer);
            var Result = BlockApp.GetLockApp(KeyApp);
            BlockApp.Dispose();
            return new BlockApp() {
                Key = KeyApp,
                Value = Result.Value,
                StartDim = Result.StartDim,
                EndDim = Result.EndDim
            };
        }

        /// <summary>Obtener el Value de la aplicacion</summary>
        /// <param name="Key">Key para obtener el value</param>
        public string GetValue (string Key) {
            DataApp = new(InfServer);
            return DataApp.GetKeyValue(Key).Value;
        }

        /// <summary>Obtiene un boleano que indica si la url esta permiditida</summary>
        /// <param name="Key">Key de la aplicacion a validar</param>
        /// <param name="Url">Url a validar</param>
        public bool GetValueUrl(string Key,string Url) {
            DataApp = new(InfServer);
            return DataApp.GetValideAccessUrl(Key,Url);
        }

        /// <summary>Guarda el resultado de la respuesta data de un captcha</summary>
        /// <param name="Answer">Informacion de la respuesta</param>z
        public bool SetAnswer(CaptchaAnswer Answer) {
            DataCap = new(InfServer);
            DALUtils.Models.AnswerCaptcha CapAns = new() {
                Id = Answer.IdCapcha,
                Answer = Answer.Answer,
                IsCorrect = Answer.IsCorrect,
                Timestamp = DateTime.Now,
            };
            string Result= DataCap.SetAnswer(CapAns);
            DataCap.Dispose();
            return !string.IsNullOrEmpty(Result);
        }

        public bool SetCaptcha(Captcha GenCaptcha) {
            DataCap = new(InfServer);
            DALUtils.Models.Captcha Capt = new() {
                Id=GenCaptcha.Id,
                ImgB64 = GenCaptcha.ImgB64,
                KeyApp=GenCaptcha.KeyApp,
                TimeStamp=DateTime.Now
            };
            string Result = DataCap.SetCaptcha(Capt);
            DataCap.Dispose();
            return !string.IsNullOrEmpty(Result);
        }
    }
}
