namespace Crypto.Core {
    internal class LogEvent {

        /// <summary>Tipo de evento</summary>
        public enum Type {
            /// <summary>Evento de informacion</summary>
            Information=0,
            /// <summary>Evento de advertencia</summary>
            Warning=1,
            /// <summary>Evento de error</summary>
            Error=2
        }

        /// <summary>Obtiene el directorio actual de la aplicacion</summary>
        private string LoadPath () {
            string Folder = GetFolder(Directory.GetCurrentDirectory()+"\\Log");
            return Folder+"\\Sistem.Cripto.Err.log";
        }

        /// <summary>Ver si existe el archivo, en su defecto crearlo</summary>
        private void ValideFileLog () {
            if (!File.Exists(LoadPath())) {
                FileStream F = File.Create(LoadPath());
                F.Close();
            }
        }

        /// <summary>Guardar un evento en un archivo Log</summary>
        /// <param name="Process">Proceso que genera el error</param>
        /// <param name="Event">Evento generado</param>
        /// <param name="TEvent">Tipo de error presentado</param>
        public void SaveEvent (string Process, string Event,Type TEvent) {
            try {
                string PathFile = LoadPath();
                ValideFileLog();
                StreamWriter Wr = File.AppendText(PathFile);
                string iDate = DateTime.Now.ToString("yyyy-MM-dd");
                string iTime = DateTime.Now.ToString("H:mm:ss");
                Wr.WriteLine(iDate + " " + iTime + " | "+TEvent.ToString()+" - " + Process + ": " + Event);
                Wr.Close();
            } catch (Exception ex) {
                Console.Write(ex.InnerException);
            }
        }

        /// <summary>Valida si el directorio no exite crea uno</summary>
        /// <param name="Path">Ruta a validar</param>
        public string GetFolder (string Path) {
            if (!Directory.Exists(Path)) {
                Directory.CreateDirectory(Path);
            }
            return Path;
        }
    }
}
