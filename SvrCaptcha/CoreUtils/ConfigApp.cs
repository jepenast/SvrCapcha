namespace SvrCaptcha.CoreUtils {
    public class ConfigApp {

        public static ConfigApp Instance = new();
        public string PathCache{get; set;}
        public int MaxTimeToken{ get; set; }
        public string KeyAES{get; set; }
        public CfgDataBase DBParam{ get; set;}
        public int ReqThrolling{ get; set;}

        public ConfigApp () {
            DBParam = new();
            PathCache = string.Empty;
            KeyAES = string.Empty;
            MaxTimeToken = 0;
            LoadConfig();
        }

        public void LoadConfig () {
            IConfiguration FileCfg = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            DBParam = new CfgDataBase() {
                Server = FileCfg["Data:Server"],
                DBName = FileCfg["Data:DBName"],
                Port = int.Parse(FileCfg["Data:Port"]),
                UCredential = new Crypto().ExtractKey(FileCfg["DBConnector:Credentials"],1),
                PCredential = new Crypto().ExtractKey(FileCfg["DBConnector:Credentials"],2)
            };
            PathCache=FileCfg["Data:Cache"];
            MaxTimeToken = int.Parse(FileCfg["Utils:MaxTimeToken"]);
            KeyAES = FileCfg["Utils:KEYCD"];
            ReqThrolling = int.Parse(FileCfg["Utils:ReqThrolling"]);
        }

        public string LoadKey (string Key, string Value) {
            IConfiguration FileCfg = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            return FileCfg[Key+":"+Value];
        }

    }

    public class CfgDataBase {

        /// <summary>Direccion del servidor incluido su instancia</summary>
        public string Server { get; set; }

        /// <summary>Nombre de la base de datos</summary>
        public string DBName { get; set; }

        /// <summary>Puerto por el que se realiza la conexion</summary>
        public int Port { get; set; }

        /// <summary>Nombre de usuario con el que se genera la conexion</summary>
        public string UCredential { get; set; }
        /// <summary>Contraseña del usuario</summary>
        public string PCredential { get; set; }

        public CfgDataBase () {
            Server = string.Empty;
            DBName = string.Empty;
            Port = 0;
            UCredential = string.Empty;
            PCredential = string.Empty;
        }
    }
}
