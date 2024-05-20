using SvrCaptcha.Interface;
using SvrCaptcha.Models;
using System.Drawing;
using System.Drawing.Imaging;

namespace SvrCaptcha.Service {
    public class CaptchaService:ICaptchaService {

        private readonly Random RND = new();
        private readonly Dictionary<string, string> Captchas;
        private readonly List<string> ListFonts;

        public CaptchaService() {
            Captchas = new ();
            ListFonts = [
                "Arial", 
                "Calibri", 
                "Comic Sans MS", 
                "Lucida Sans Unicode", 
                "Verdana", 
                "Tahoma", 
                "Consolas",
                "Britanic Bold",
                "Forte",
                "Informal Roman"
            ];
            CheckList();
        }

        public void CheckList() {
            if (Captchas.Count == 0) {
                Dictionary<string,string> LstCache=new CoreUtils.Cache().GetAnswer();
                foreach(KeyValuePair<string,string> Item in LstCache) {
                    Captchas.Add(Item.Key, Item.Value);
                }
            }
        }

        public Captcha GenerateCaptcha (string KeyApp) {
            Models.Captcha GenCap = new() {
                Id = Guid.NewGuid().ToString(),
                KeyApp = KeyApp,
                Answer = GenerateRandomAnswer(),
                ImgB64 = string.Empty,
            };
            GenCap.ImgB64 = GenerateCaptchaImage(GenCap.Answer);
            new CoreUtils.Data().SetCaptcha(GenCap);
            return GenCap;
        }

        public bool ValideCaptcha (string Id, string Answer,string B64Img) {
            CaptchaAnswer Ans = new() {
                IdCapcha = Id,
                Answer = Answer,
                ImgB64 = B64Img,
                IsCorrect = false
            };
            if (Captchas.TryGetValue(Id, out string? value)) {
                string AnswerCap = value;
                Captchas.Remove(Id);
                if( AnswerCap.Equals(Answer, StringComparison.OrdinalIgnoreCase)) {
                    Ans.IsCorrect = true;
                }
            } else {
                Ans.ImgB64 = "Captcha sin contexto o no existe en el proceso";
            }
            new CoreUtils.Data().SetAnswer(Ans);
            return Ans.IsCorrect;
        }

        public bool ValideBlock (string Key) {
            BlockApp Block=new CoreUtils.Data().CheckBlock(Key);
            if (!string.IsNullOrEmpty(Block.Key)){
                return true;
            }
            return false;
        }

        private string GenerateRandomAnswer () {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789¿?¡!:.";
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[RND.Next(s.Length)]).ToArray());
        }

        private string GenerateCaptchaImage (string Answer) {
            using Bitmap Map = new(200, 50);
            using Graphics Graph = Graphics.FromImage(Map);
            Graph.Clear(Color.White);
            // Dibujar líneas aleatorias
            for (int i = 0; i < 10; i++) {
                int x1 = RND.Next(200);
                int y1 = RND.Next(50);
                int x2 = RND.Next(200);
                int y2 = RND.Next(50);
                Graph.DrawLine(PensColor(), x1, y1, x2, y2);
            }
            //Dibujar circulos
            for (int i = 0; i < 5; i++) {
                int Radius = RND.Next(45);
                int X = RND.Next(50);
                int Y = RND.Next(50);
                Graph.DrawEllipse(PensColor(), X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            }
            // Dibujar texto
            Graph.DrawString(Answer, new Font(UseFont(), 20, FontStyle.Bold), Brushes.Black, new PointF(10, 10));
            // Guardar la imagen
            using MemoryStream ms = new();
            Map.Save(ms, ImageFormat.Png);
            byte[] imageBytes = ms.ToArray();
            return new CoreUtils.Crypto().EncodeB64FromBytes(imageBytes);
        }

        private string UseFont () {
            int NumRnd = RND.Next(0,9);
            return ListFonts[NumRnd];
        }

        private Pen PensColor(){
            Color ColorPen = Color.FromArgb(RND.Next(256), RND.Next(256), RND.Next(256));
            return new Pen(ColorPen);
        }
    }
}
