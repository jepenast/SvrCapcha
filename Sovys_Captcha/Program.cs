using Sovys_Captcha.Interface;
using Sovys_Captcha.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICaptchaService, CaptchaService>(); // Registra ICaptchaService con CaptchaService
// Add services to the container.

builder.Services.AddCors(options => {
    options.AddPolicy("AllowSpecificOrigin",
        builder => {
            builder.WithOrigins("*")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles(); // Middleware para archivos HTML por defecto
app.UseStaticFiles(); // Middleware para archivos estáticos
app.UseFileServer(enableDirectoryBrowsing: true); // Habilita la exploración de directorios si es necesario

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
