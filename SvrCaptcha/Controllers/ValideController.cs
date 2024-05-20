using Microsoft.AspNetCore.Mvc;
using SvrCaptcha.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SvrCaptcha.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ValideController : ControllerBase {

        private readonly ICaptchaService CaptchaSvr;
          private readonly ITokenService TokenSvr;

        public ValideController (ICaptchaService CaptchaService, ITokenService TokenService) {
            CaptchaSvr = CaptchaService;
            TokenSvr = TokenService;
        }

        // POST api/<ValideController>
        [HttpPost]
        public IActionResult Post ([FromBody] Models.AnswerCaptcha value) {
            try{
                if (!string.IsNullOrEmpty(value.ToString())) {
                    if (TokenSvr.ValideToken(value.Token)==Models.TokenStatus.Ok){
                        Models.TokenModel Token= TokenSvr.ExtractToken(value.Token);
                        if (CaptchaSvr.ValideBlock(Token.KeyApp)){
                            if (CaptchaSvr.ValideCaptcha(value.Id, value.Answer, value.ImgB64)) {
                                return Ok("{\"Answer\":\"True\"}");
                            } else {
                                return BadRequest("{\"Answer\":\"False\"}");
                            }
                        } else {
                            return StatusCode(423, "Key bloqueada");
                        }
                    } else {
                        return StatusCode(401, "Token no valido");
                    }
                } else {
                    return BadRequest("Datos vacios o incompletos");
                }
            }catch(Exception Ex) {
                return BadRequest("Error al procesar la solicitud");
            }
        }
    }
}
