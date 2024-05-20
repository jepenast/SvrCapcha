using Microsoft.AspNetCore.Mvc;
using Sovys_Captcha.Interface;
using Sovys_Captcha.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sovys_Captcha.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CaptchaController : ControllerBase {

        private readonly ICaptchaService _captchaService;

        public CaptchaController (ICaptchaService captchaService) {
            _captchaService = captchaService;
        }


        // GET api/<CaptchaController>/5
        [HttpGet()]
        public IActionResult Get () {
            var captcha = _captchaService.GenerateCaptcha();
            return Ok(captcha);
        }


        //[HttpGet()]
        //public IActionResult GetCaptcha () {
        //    var captcha = _captchaService.GenerateCaptcha();
        //    return Ok(captcha);
        //}

        //[HttpPost]
        //public IActionResult ValidateCaptcha (CaptchaModel captchaModel) {
        //    var isCorrect = _captchaService.ValidateCaptcha(captchaModel.Id, captchaModel.Answer);
        //    if (isCorrect) {
        //        // Registro en la base de datos
        //        //_captchaService.SaveCaptchaLog(captchaModel.Id, captchaModel.Answer, true);
        //        return Ok("Captcha correcto");
        //    } else {
        //        //_captchaService.SaveCaptchaLog(captchaModel.Id, captchaModel.Answer, false);
        //        return BadRequest("Captcha incorrecto");
        //    }
        //}





    }
}



