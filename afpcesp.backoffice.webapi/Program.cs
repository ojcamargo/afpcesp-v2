using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using afpcesp.dataaccess;
using afpcesp.backoffice.webapi.Configuration;
using afpcesp.application.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração do JWT Settings (compartilhado entre camadas)
builder.Services.Configure<afpcesp.backoffice.webapi.Configuration.JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.Configure<afpcesp.application.Services.JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<afpcesp.backoffice.webapi.Configuration.JwtSettings>();

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();

// Configuração do Swagger com suporte a JWT
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AFPCESP BackOffice API",
        Version = "v1",
        Description = "API do sistema de BackOffice da AFPCESP com autenticação JWT"
    });

    // Configuração de segurança JWT no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT desta forma: Bearer {seu token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddControllers();
builder.Services.AddDataAccessServices();

// Registra os serviços da camada Application
builder.Services.AddScoped<IAuthApplicationService, AuthApplicationService>();
builder.Services.AddScoped<IUserApplicationService, UserApplicationService>();

// Configuração da autenticação JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false; // Em produção, altere para true
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = jwtSettings?.ValidateIssuer ?? true,
        ValidateAudience = jwtSettings?.ValidateAudience ?? true,
        ValidateLifetime = jwtSettings?.ValidateLifetime ?? true,
        ValidateIssuerSigningKey = jwtSettings?.ValidateIssuerSigningKey ?? true,
        ValidIssuer = jwtSettings?.Issuer,
        ValidAudience = jwtSettings?.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSettings?.SecretKey ?? throw new InvalidOperationException("JWT SecretKey não configurada"))),
        ClockSkew = TimeSpan.Zero // Remove o tempo de tolerância padrão
    };
});

// Adiciona autorização
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// IMPORTANTE: A ordem é crucial!
// 1. Authentication (verifica o token)
app.UseAuthentication();

// 2. Authorization (verifica as permissões)
app.UseAuthorization();

// 3. MapControllers (roteia para os controllers)
app.MapControllers();

app.Run();