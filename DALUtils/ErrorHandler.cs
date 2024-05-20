using System.ComponentModel;
using System.Reflection;

namespace DALUtils {
    internal class ErrorHandler {

        private readonly string LogFile;

        public ErrorHandler(){
            LogFile = ".\\Log\\" + Assembly.GetExecutingAssembly().FullName + "_err.log";
        }

        public Exception GetError(Exception Ex) {
            LogError(Ex);
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            var w32ex = (Win32Exception)Ex.InnerException;
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            return GetCustomError(GetlistError(w32ex.ErrorCode));
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
        }

        public Exception GetError(int ErrorCode,Exception Ex) {
            LogError(Ex);
            return GetCustomError(GetlistError(ErrorCode));
        }

        private void LogError(Exception ex){
            string LogMsg = $"[{DateTime.Now:u}] {ex.GetType().FullName}: {ex.Message}\n{ex.StackTrace}\n";
            try{
                File.AppendAllText(LogFile, LogMsg);
            }catch (Exception e){
                Console.WriteLine($"Error al escribir en el archivo de registro: {e.Message}");
            }
        }

        private Exception GetCustomError(string ErrMsg){
            return new Exception(ErrMsg);
        }

        private void GetThrowCustomError(string ErrMsg) {
            throw new Exception(ErrMsg);
        }

        private string GetlistError(int Err){
            if (!string.IsNullOrEmpty(Error.ResourceManager.GetString(Err.ToString()))){
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
                return Error.ResourceManager.GetString(Err.ToString());
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
            } else {
                return "Error no definido";
            }
        }

        //---------------------------

        public string ErrorConectionCache(Exception Ex) {
            LogError(Ex);
            return GetlistError(1003);
        }

        public string ErrorConectionData (Exception Ex) {
            LogError(Ex);
            return GetlistError(1000);
        }

    }
}
