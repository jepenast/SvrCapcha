using Sovys_Captcha.Interface;
using Sovys_Captcha.Models;
using Sovys_Captcha.Services;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Sovys_Captcha.Services {
    public class CaptchaService : ICaptchaService {
        
        
        private readonly Dictionary<string, string> _captchas = new Dictionary<string, string>();
        private readonly string _connectionString = "tu_cadena_de_conexion_a_SQL_Server";
        private readonly Random random = new Random();


        public CaptchaModel GenerateCaptcha () {
            string id = Guid.NewGuid().ToString();
            string answer = GenerateRandomAnswer();
            string imageBase64 = GenerateCaptchaImage(answer);

            _captchas.Add(id, answer);

            return new CaptchaModel { Id = id, ImageBase64 = imageBase64 };
        }

        public bool ValidateCaptcha (string captchaId, string answer) {
            if (_captchas.ContainsKey(captchaId)) {
                string correctAnswer = _captchas[captchaId];
                _captchas.Remove(captchaId);
                return correctAnswer.Equals(answer, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        //public void SaveCaptchaLog (string captchaId, string userAnswer, bool isCorrect) {
        //    using (var connection = new SqlConnection(_connectionString)) {
        //        connection.Open();
        //        string query = "INSERT INTO CaptchaLog (CaptchaId, UserAnswer, Timestamp, IsCorrect) VALUES (@CaptchaId, @UserAnswer, @Timestamp, @IsCorrect)";
        //        using (var command = new SqlCommand(query, connection)) {
        //            command.Parameters.AddWithValue("@CaptchaId", captchaId);
        //            command.Parameters.AddWithValue("@UserAnswer", userAnswer);
        //            command.Parameters.AddWithValue("@Timestamp", DateTime.Now);
        //            command.Parameters.AddWithValue("@IsCorrect", isCorrect);
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

        private string GenerateRandomAnswer () {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789¿?¡!";
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string GenerateCaptchaImage (string answer) {
            using (Bitmap bitmap = new Bitmap(200, 50)) {
                using (Graphics graphics = Graphics.FromImage(bitmap)) {
                    graphics.Clear(Color.White);

                    // Dibujar líneas aleatorias
                    for (int i = 0; i < 10; i++) {
                        int x1 = random.Next(200);
                        int y1 = random.Next(50);
                        int x2 = random.Next(200);
                        int y2 = random.Next(50);
                        graphics.DrawLine(Pens.LightGray, x1, y1, x2, y2);
                    }

                    // Dibujar texto
                    graphics.DrawString(answer, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(10, 10));

                    // Guardar la imagen
                    using (MemoryStream ms = new MemoryStream()) {
                        bitmap.Save(ms, ImageFormat.Png);
                        byte[] imageBytes = ms.ToArray();
                        return Convert.ToBase64String(imageBytes);
                    }
                }
            }
        }
    }
}
