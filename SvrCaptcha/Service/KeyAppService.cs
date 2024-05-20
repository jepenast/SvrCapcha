using SvrCaptcha.Interface;
using SvrCaptcha.Models;

namespace SvrCaptcha.Service {
    public class KeyAppService:IKeyAppService {

        /// <summary>Generar una llave unica para la aplicacion</summary>
        /// <param name="NameApp">Nombre de la aplicacion a generar el Key</param>

        public string GenerateKey (string NameApp) {
            if (string.IsNullOrEmpty(NameApp)){
                return new Guid(NameApp).ToString();
            } else {
                return string.Empty;
            }
        }


        /// <summary>Validar que los datos agregados son de coherentes</summary>
        /// <param name="Key">ID de la aplicacion</param>
        /// <param name="Value">LLave validadora de la aplicacion</param>
        public bool ValideKey(string Key, string Value) {
            bool Result=false;
            CoreUtils.Data DApp = new();
            KeyApp KeyA = DApp.GetKeys(Key);
            if (!string.IsNullOrEmpty(KeyA.Key)){
                Result = KeyA.value == Value;
            }
            return Result;
        }

        /// <summary>Obtener la llave de validacion de la aplicacion</summary>
        /// <param name="Key">ID de la aplicacion</param>
        public string GetValue(string Key, string Url) {
            if (!string.IsNullOrEmpty(Key) ) {
                if (CheckUrl(Key,Url)) {
                    CoreUtils.Data DApp = new();
                    return DApp.GetValue(Key);
                } else {
                    return "Key Vacia";
                }
            }else {
                return "Url no permitida";
            }
        }

        /// <summary>Validar que la url si este permitida para el key enviado</summary>
        /// <param name="Key">LLave de la aplicacion</param>
        /// <param name="Url">Url a validar</param>
        private bool CheckUrl(string Key, string Url) {
            int IdxThird = Url.IndexOf('/', Url.IndexOf('/', Url.IndexOf('/') + 1) + 1);
            if (IdxThird != -1) {
                // Obtiene la subcadena de la URL hasta el tercer '/'
                Url=Url[..IdxThird];
            }
            CoreUtils.Data DApp = new();
            return DApp.GetValueUrl(Key,Url);
        }

        /// <summary>Generar la llave de validacion de la aplicacion</summary>
        /// <param name="Key">Id de identificacion de la aplicacion</param>
        /// <param name="NameApp">Nombre de la aplicacion</param>
        /// <param name="StartTimeLife">Fecha de inicio de inscripcion de aplicacion</param>
        /// <param name="EndTimeLife">Fecha fin de inscripcion de la aplicacion</param>
        public KeyApp GenerateValueKey(string Key,string NameApp,DateTime StartTimeLife, DateTime EndTimeLife) {
            CoreUtils.Utils Utl = new();
            string Value=Utl.GenerateSalt()+Utl.GenerateHashSha(Key+NameApp)+"."+Utl.ConvertToUnixTimeStamp(StartTimeLife) + Utl.ConvertToUnixTimeStamp(EndTimeLife);
            string Sing = Utl.GenerateHashMD5(Value);
            Value = Utl.GenerateHashSha((Value + "." + Sing));
            return new KeyApp() {
                Key = Key,
                value = Value
            };
        }

    }
}
