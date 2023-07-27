using FretesWebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FretesWebApplication.Authentication;
using FretesWebApplication.Interface;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FretesWebApplicationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("FretesWebApplicationContext") ?? throw new InvalidOperationException("Connection string 'FretesWebApplication' not found.")));

byte[] key = new byte[16];
using (var rng = RandomNumberGenerator.Create())
{
    rng.GetBytes(key);
}


// Criar um objeto SymmetricSecurityKey usando a chave gerada
var symmetricSecurityKey = new SymmetricSecurityKey(key);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "localhost",
            ValidAudience = "MinhaAplicacaoLocal",
            IssuerSigningKey = symmetricSecurityKey
        };
    });

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "create-frete",
    pattern: "Fretes/Create",
    defaults: new { controller = "Fretes", action = "Create" });

app.MapControllerRoute(
    name: "login",
            pattern: "Login/Login",
            defaults: new { controller = "Login", action = "Login" });


app.Run();
