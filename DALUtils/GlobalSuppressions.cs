﻿// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Major Code Smell", "S112:General or reserved exceptions should never be thrown", Justification = "Generacion de un throw nuevo simple", Scope = "member", Target = "~M:DALUtils.Data.ExecuteCmd.StoreProcedure(System.String,Microsoft.Data.SqlClient.SqlParameter[])~Microsoft.Data.SqlClient.SqlDataReader")]
[assembly: SuppressMessage("Major Code Smell", "S3881:\"IDisposable\" should be implemented correctly", Justification = "Se implementa el minimo de Idisposable", Scope = "type", Target = "~T:DALUtils.Data.ExecuteCmd")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.Data.ParamBuiler.CreateParamsCaptcha(DALUtils.Models.Captcha)~Microsoft.Data.SqlClient.SqlParameter[]")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.Data.ParamBuiler.BlockAccess(DALUtils.Models.BlockAccess)~Microsoft.Data.SqlClient.SqlParameter[]")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.Data.ParamBuiler.CreateAnswer(DALUtils.Models.AnswerCaptcha)~Microsoft.Data.SqlClient.SqlParameter[]")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.Data.ParamBuiler.CreateParam(System.String,System.Object)~Microsoft.Data.SqlClient.SqlParameter")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.Data.ParamBuiler.CreateParamsApp(DALUtils.Models.IApplication)~Microsoft.Data.SqlClient.SqlParameter[]")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.SQLite.CmdBuilder.ClearRegistry~System.String")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.SQLite.CmdBuilder.DeleteBlock~System.String")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.SQLite.CmdBuilder.DeleteCache~System.String")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.SQLite.CmdBuilder.DeleteKey~System.String")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.SQLite.CmdBuilder.InsertBlock~System.String")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.SQLite.CmdBuilder.InsertCache~System.String")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.SQLite.CmdBuilder.InsertKey~System.String")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.SQLite.CmdBuilder.ReadCache~System.String")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.SQLite.CmdBuilder.UpdateBlock~System.String")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.SQLite.CmdBuilder.UpdateKey~System.String")]
[assembly: SuppressMessage("Major Code Smell", "S1144:Unused private types or members should be removed", Justification = "<pendiente>", Scope = "member", Target = "~M:DALUtils.ErrorHandler.GetThrowCustomError(System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S112:General or reserved exceptions should never be thrown", Justification = "<pendiente>", Scope = "member", Target = "~M:DALUtils.ErrorHandler.GetThrowCustomError(System.String)")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.ErrorHandler.GetlistError(System.Int32)~System.String")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.ErrorHandler.GetCustomError(System.String)~System.Exception")]
[assembly: SuppressMessage("CodeQuality", "IDE0051:Quitar miembros privados no utilizados", Justification = "<pendiente>", Scope = "member", Target = "~M:DALUtils.ErrorHandler.GetThrowCustomError(System.String)")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.ErrorHandler.GetThrowCustomError(System.String)")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.SQLite.CmdBuilder.ClearAppBlocks~System.String")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.SQLite.CmdBuilder.DeleteAppBlock~System.String")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.SQLite.CmdBuilder.InsertAppBlock~System.String")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.SQLite.CmdBuilder.InsertListAppBlock~System.String")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.SQLite.ParamBuilder.BlockAccess(DALUtils.Models.BlockAccess)~Microsoft.Data.Sqlite.SqliteParameter[]")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.SQLite.ParamBuilder.CreateParam(System.String,System.Object)~Microsoft.Data.Sqlite.SqliteParameter")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.SQLite.ParamBuilder.CreateParams(DALUtils.Models.Captcha)~Microsoft.Data.Sqlite.SqliteParameter[]")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "Miembro objeto", Scope = "member", Target = "~M:DALUtils.SQLite.ParamBuilder.InsertListAppBlock(System.Data.DataRow)~Microsoft.Data.SqlClient.SqlParameter[]")]
[assembly: SuppressMessage("Major Code Smell", "S1121:Assignments should not be made from within sub-expressions", Justification = "<pendiente>", Scope = "member", Target = "~M:DALUtils.Data.ParamBuiler.BlockAccess(DALUtils.Models.BlockAccess)~Microsoft.Data.SqlClient.SqlParameter[]")]
[assembly: SuppressMessage("Major Code Smell", "S1121:Assignments should not be made from within sub-expressions", Justification = "<pendiente>", Scope = "member", Target = "~M:DALUtils.Data.ParamBuiler.CreateAnswer(DALUtils.Models.AnswerCaptcha)~Microsoft.Data.SqlClient.SqlParameter[]")]
[assembly: SuppressMessage("Major Code Smell", "S1121:Assignments should not be made from within sub-expressions", Justification = "<pendiente>", Scope = "member", Target = "~M:DALUtils.Data.ParamBuiler.CreateParamsApp(DALUtils.Models.IApplication)~Microsoft.Data.SqlClient.SqlParameter[]")]
[assembly: SuppressMessage("Major Code Smell", "S1121:Assignments should not be made from within sub-expressions", Justification = "<pendiente>", Scope = "member", Target = "~M:DALUtils.Data.ParamBuiler.CreateParamsCaptcha(DALUtils.Models.Captcha)~Microsoft.Data.SqlClient.SqlParameter[]")]
[assembly: SuppressMessage("Major Code Smell", "S1121:Assignments should not be made from within sub-expressions", Justification = "<pendiente>", Scope = "member", Target = "~M:DALUtils.SQLite.ParamBuilder.InsertListAppBlock(System.Data.DataRow)~Microsoft.Data.SqlClient.SqlParameter[]")]
[assembly: SuppressMessage("Major Code Smell", "S6580:Use a format provider when parsing date and time", Justification = "<pendiente>", Scope = "member", Target = "~M:DALUtils.SQLite.Context.ReadCaptcha(System.String,System.String)~DALUtils.Models.Captcha")]
[assembly: SuppressMessage("CodeQuality", "IDE0076:\"SuppressMessageAttribute\" global no válido", Justification = "<pendiente>")]
[assembly: SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "<pendiente>", Scope = "member", Target = "~M:DALUtils.Data.ParamBuiler.CreateParamUrl(System.String,System.String)~Microsoft.Data.SqlClient.SqlParameter[]")]
[assembly: SuppressMessage("Usage", "CA1816:Los métodos Dispose deberían llamar a SuppressFinalize", Justification = "<pendiente>", Scope = "member", Target = "~M:DALUtils.Data.Context.Application.Dispose(System.Boolean)")]
[assembly: SuppressMessage("Usage", "CA1816:Los métodos Dispose deberían llamar a SuppressFinalize", Justification = "<pendiente>", Scope = "member", Target = "~M:DALUtils.Data.Context.Captcha.Dispose")]
[assembly: SuppressMessage("Major Code Smell", "S3881:\"IDisposable\" should be implemented correctly", Justification = "<pendiente>", Scope = "type", Target = "~T:DALUtils.Data.Connection")]
[assembly: SuppressMessage("Major Code Smell", "S3881:\"IDisposable\" should be implemented correctly", Justification = "<pendiente>", Scope = "type", Target = "~T:DALUtils.Data.Context.Application")]
[assembly: SuppressMessage("Major Code Smell", "S3881:\"IDisposable\" should be implemented correctly", Justification = "<pendiente>", Scope = "type", Target = "~T:DALUtils.Data.Context.BlockApp")]
[assembly: SuppressMessage("Major Code Smell", "S3971:\"GC.SuppressFinalize\" should not be called", Justification = "<pendiente>", Scope = "member", Target = "~M:DALUtils.Data.Context.Application.Dispose(System.Boolean)")]
[assembly: SuppressMessage("Major Code Smell", "S3971:\"GC.SuppressFinalize\" should not be called", Justification = "<pendiente>", Scope = "member", Target = "~M:DALUtils.Data.Context.Captcha.Dispose")]
