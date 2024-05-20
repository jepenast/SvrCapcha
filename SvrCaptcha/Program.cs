using SvrCaptcha.CoreUtils;
using SvrCaptcha.Interface;
using SvrCaptcha.Middleware;
using SvrCaptcha.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<ICaptchaService, CaptchaService>();
builder.Services.AddScoped<IKeyAppService, KeyAppService>();
builder.Services.AddScoped<ITokenService, TokenService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowSpecificOrigin",
        builder => {
            builder.WithOrigins("*")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


var app = builder.Build();

//Middlewares
//Limitar el uso del captcha por ip
app.UseRequestThrottling(ReqLimit: int.Parse(new ConfigApp().LoadKey("Utils", "ReqThrolling")), ReqWindow: TimeSpan.FromMinutes(1));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles(); // Middleware para archivos HTML por defecto
app.UseStaticFiles(); // Middleware para archivos estáticos
app.UseHttpsRedirection(); //Middleware para redireccionar al interno
app.UseAuthorization();
app.MapControllers();
app.Run();
