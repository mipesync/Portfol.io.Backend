using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Portfol.io.Application;
using Portfol.io.Persistence;
using Portfol.io.WebAPI;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//TODO: Доделать настройки авторизации + добавить авторизацию через ВК и т.д.
//TODO: Сделать авторизацию через IdentitServer 4, в куках хранить userId и credentialId
builder.Services.AddAuthentication(conf =>
{
    conf.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    conf.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer("Bearer", opt =>
{
    opt.Authority = "https://localhost:7150";
    opt.Audience = "PortfolioWebAPI";
    opt.RequireHttpsMetadata = false;
});
    /*.AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthenticationOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthenticationOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthenticationOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
    })
    .AddGoogle(options =>
    {
        IConfigurationSection googleConfig = config.GetSection("Authenfication:Google");
        options.ClientId = googleConfig["ClientId"];
        options.ClientSecret = googleConfig["ClientSecret"];
    });*/

var connectionString = builder.Configuration.GetConnectionString("PostgreSQL");
builder.Services.AddPersistence(connectionString);
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<PortfolioDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception e)
    {
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(e, $"An error occured while initializing the database: {e.Message}");
    }
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
