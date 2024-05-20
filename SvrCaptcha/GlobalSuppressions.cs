// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Style", "IDE0290:Usar constructor principal", Justification = "<pendiente>", Scope = "member", Target = "~M:SvrCaptcha.Controllers.GetController.#ctor(SvrCaptcha.Interface.ICaptchaService,SvrCaptcha.Interface.IKeyAppService,SvrCaptcha.Interface.ITokenService)")]
[assembly: SuppressMessage("Style", "IDE0290:Usar constructor principal", Justification = "<pendiente>", Scope = "member", Target = "~M:SvrCaptcha.Controllers.ValideController.#ctor(SvrCaptcha.Interface.ICaptchaService,SvrCaptcha.Interface.ITokenService)")]
[assembly: SuppressMessage("Style", "IDE0290:Usar constructor principal", Justification = "<pendiente>", Scope = "member", Target = "~M:SvrCaptcha.Middleware.LimitRequest.#ctor(Microsoft.AspNetCore.Http.RequestDelegate,System.Int32,System.TimeSpan)")]
[assembly: SuppressMessage("Style", "IDE0028:Simplificar la inicialización de la recopilación", Justification = "<pendiente>", Scope = "member", Target = "~M:SvrCaptcha.CoreUtils.Cache.GetAnswer~System.Collections.Generic.Dictionary{System.String,System.String}")]
[assembly: SuppressMessage("Style", "IDE0028:Simplificar la inicialización de la recopilación", Justification = "<pendiente>", Scope = "member", Target = "~M:SvrCaptcha.Service.CaptchaService.#ctor")]
[assembly: SuppressMessage("CodeQuality", "IDE0052:Quitar miembros privados no leídos", Justification = "<pendiente>", Scope = "member", Target = "~F:SvrCaptcha.CoreUtils.Cache.PathFile")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "<pendiente>", Scope = "member", Target = "~M:SvrCaptcha.Service.KeyAppService.CheckUrl(System.String,System.String)~System.Boolean")]
[assembly: SuppressMessage("Major Code Smell", "S6580:Use a format provider when parsing date and time", Justification = "<pendiente>", Scope = "member", Target = "~M:SvrCaptcha.Service.TokenService.ExtractToken(System.String)~SvrCaptcha.Models.TokenModel")]
[assembly: SuppressMessage("Interoperability", "CA1416:Validar la compatibilidad de la plataforma", Justification = "<pendiente>", Scope = "member", Target = "~M:SvrCaptcha.Service.CaptchaService.GenerateCaptchaImage(System.String)~System.String")]
[assembly: SuppressMessage("Interoperability", "CA1416:Validar la compatibilidad de la plataforma", Justification = "<pendiente>", Scope = "member", Target = "~M:SvrCaptcha.Service.CaptchaService.PensColor~System.Drawing.Pen")]
[assembly: SuppressMessage("Critical Code Smell", "S927:Parameter names should match base declaration and other partial definitions", Justification = "<pendiente>", Scope = "member", Target = "~M:SvrCaptcha.Service.CaptchaService.ValideCaptcha(System.String,System.String,System.String)~System.Boolean")]
[assembly: SuppressMessage("Critical Code Smell", "S927:Parameter names should match base declaration and other partial definitions", Justification = "<pendiente>", Scope = "member", Target = "~M:SvrCaptcha.Service.KeyAppService.GetValue(System.String,System.String)~System.String")]
[assembly: SuppressMessage("Critical Code Smell", "S927:Parameter names should match base declaration and other partial definitions", Justification = "<pendiente>", Scope = "member", Target = "~M:SvrCaptcha.Service.KeyAppService.ValideKey(System.String,System.String)~System.Boolean")]
