using Identity.API;
using Identity.API.Data;
using Identity.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// *** CONFIGURE ENTITY FRAMEWORK CORE & OPENIDDICT ***
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.UseOpenIddict();
});

// *** CONFIGURE QUARTZ FOR BACKGROUND TASKS ***
builder.Services.AddQuartz(options =>
{
    options.UseMicrosoftDependencyInjectionJobFactory();
    options.UseSimpleTypeLoader();
    options.UseInMemoryStore();
});

// *** CONFIGURE OPENIDDICT SERVER ***
builder.Services.AddOpenIddict()
    .AddCore(options =>
    {
        options.UseEntityFrameworkCore()
               .UseDbContext<ApplicationDbContext>();
        options.UseQuartz();
    })
    .AddServer(options =>
    {
        options.SetTokenEndpointUris("/connect/token");
        options.AllowPasswordFlow();
        options.AllowRefreshTokenFlow();
        options.AddDevelopmentEncryptionCertificate()
               .AddDevelopmentSigningCertificate();

        // This is the new line that fixes our problem
        options.DisableAccessTokenEncryption();

        // --- THIS IS THE CRITICAL CHANGE ---
        // We replace EnableTokenEndpointPassthrough() with a more explicit configuration
        // for local development to prevent conflicts with Kestrel's HTTPS handling.
        options.UseAspNetCore()
            .EnableTokenEndpointPassthrough()
            .DisableTransportSecurityRequirement(); 
    })
    .AddValidation(options =>
    {
        options.UseLocalServer();
        options.UseAspNetCore();
    });

// *** CONFIGURE ASP.NET CORE IDENTITY ***
builder.Services.AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Configure authentication to use JWT Bearer tokens.
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Bearer";
    options.DefaultChallengeScheme = "Bearer";
});

builder.Services.AddControllers();
builder.Services.AddHostedService<Worker>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();