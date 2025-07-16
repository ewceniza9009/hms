using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// --- START CORS CONFIGURATION ---
// 1. Define a name for our policy
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// 2. Add the CORS services and define the policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200") // Trust your Angular app
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});
// --- END CORS CONFIGURATION ---


// This teaches the Gateway how to validate the tokens
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:7222";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot();

var app = builder.Build();

// --- CONFIGURE THE HTTP PIPELINE ---
// 3. Use the CORS policy we defined. This MUST come before UseOcelot.
app.UseCors(MyAllowSpecificOrigins);

// The Ocelot middleware will handle routing, authentication, etc.
await app.UseOcelot();

app.Run();