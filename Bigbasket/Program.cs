using Bigbasket_Ecommerce.Data;
using Bigbasket_Ecommerce.Repository;
using Bigbasket_Ecommerce.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Database Connection
var Connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(Connectionstring));
// Defendency injection

builder.Services.AddHttpContextAccessor();
// Repositories
builder.Services.AddScoped<IproductRepository, productRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICardItemRepository, CardItemRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // generic repo

// Services
builder.Services.AddScoped<ICardServices, CardServices>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddControllers();



//enable jwt token
var authKey = builder.Configuration.GetValue<string>("JwtSettings:key");
builder.Services.AddAuthentication(item =>
{
    item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


}).AddJwtBearer(item =>
{
    item.RequireHttpsMetadata = true;
    item.SaveToken = true;
    item.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authKey!)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero


    };
    item.Events = new JwtBearerEvents
    {
        OnMessageReceived = async context =>
        {
            var request = context.Request;

            // GET/DELETE: ?accessToken=xxx
            var token = request.Query["accessToken"].FirstOrDefault();

            // POST/PUT/PATCH: JSON body-? "accessToken"
            if (string.IsNullOrEmpty(token)
                && request.ContentLength > 0
                && request.ContentType?.Contains("application/json") == true)
            {
                request.EnableBuffering();
                using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
                var body = await reader.ReadToEndAsync();
                request.Body.Position = 0;

                try
                {
                    using var doc = JsonDocument.Parse(body);
                    if (doc.RootElement.ValueKind == JsonValueKind.Object &&
                        doc.RootElement.TryGetProperty("accessToken", out var prop))
                        token = prop.GetString();
                }
                catch (JsonException) { }
            }

            if (!string.IsNullOrEmpty(token))
                context.Token = token;
        }
    };

});




builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Angular app URL
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials();
                  ;
        });
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngularApp");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();



app.Run();
