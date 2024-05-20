using DALUtils.Data.Context;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using SvrCaptcha.Interface;
using SvrCaptcha.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SvrCaptcha.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class GetController : ControllerBase {

        private readonly ICaptchaService CaptchaSvr;
        private readonly IKeyAppService KeyAppSvr;
        private readonly ITokenService TokenSvr;

        public GetController(ICaptchaService CaptchaService,IKeyAppService KeyService,ITokenService TokenService) {
            CaptchaSvr = CaptchaService;
            KeyAppSvr = KeyService;
            TokenSvr = TokenService;
        }

        // GET api/<GetCaptchaController>/5
        [HttpGet("{Key}")]
        public IActionResult Get (string Key) {
            return ProcessRequest(Key);
        }

        // POST api/<GetCaptchaController>
        [HttpPost]
        public IActionResult Post ([FromBody] IKeyModel value) {
            return ProcessRequest(value.Key);
        }

        private IActionResult ProcessRequest(string Key) {
            try {
                string KeyVal = KeyAppSvr.GetValue(Key,Request.GetEncodedUrl());
                //Validar si la aplicaion tiene permiso
                if (!string.IsNullOrEmpty(KeyVal)) {
                    if (CaptchaSvr.ValideBlock(Key)){
                        string Token = TokenSvr.GenerateToken(Key, KeyVal);
                        Models.Captcha CaptchaR = CaptchaSvr.GenerateCaptcha(Key);
                        return Ok(new DataCaptcha() {
                            KeyApp = CaptchaR.KeyApp,
                            Id = CaptchaR.Id,
                            ImgB64 = CaptchaR.ImgB64,
                            Token = Token
                        });
                    } else {
                        return StatusCode(423, "Key bloqueada");
                    }
                } else {
                    return Unauthorized("Key no valida");
                }
            } catch (Exception ex) {
                return BadRequest("Error al procesar la solicitud");
            }
        }

        private class DataCaptcha  {

            public string Id {get; set;}
            public string KeyApp { get; set; }
            public string ImgB64 { get; set; }
            public string Token{get; set;}

            public DataCaptcha () {
                Id = string.Empty;
                KeyApp = string.Empty;
                ImgB64 = string.Empty;
                Token = string.Empty;
            }
        }
    }
}
