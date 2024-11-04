using DreamRosterBuilding.Business.DataProtection;
using DreamRosterBuilding.Business.Operations.Icon;
using DreamRosterBuilding.Business.Operations.Player;
using DreamRosterBuilding.Business.Operations.Setting;
using DreamRosterBuilding.Business.Operations.Team;
using DreamRosterBuilding.Business.Operations.User;
using DreamRosterBuilding.Data.Context;
using DreamRosterBuilding.Data.Repositories;
using DreamRosterBuilding.Data.UnitOfWork;
using DreamRosterBuilding.WebApi.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// ▼ Adding swagger token, authorize ▼
builder.Services.AddSwaggerGen(options =>
        {
            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Name = "Jwt Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Description = "Put only your JWT Bearer Token on texbox below please...",
                Reference=new OpenApiReference
                {
                    Id=JwtBearerDefaults.AuthenticationScheme,
                    Type=ReferenceType.SecurityScheme
                }
            };
            options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {jwtSecurityScheme,Array.Empty<string>() }
            });
        }
    );


// ▼ Creating CORS for using this api at my local frontend project ▼
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", builder =>
    {
        builder.WithOrigins("http://127.0.0.1:5500") 
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// ▼ For saving protection keys in directory. If we open this project other pc we cant open keys but with this way its ok. ▼
var keysDirectory = new DirectoryInfo(Path.Combine(builder.Environment.ContentRootPath, "App_Data", "Keys"));
builder.Services.AddDataProtection()
    .SetApplicationName("DreamRosterBuilding")
    .PersistKeysToFileSystem(keysDirectory);

// ▼ JWT settings here ▼
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],

            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],

            ValidateLifetime = true, // Token expire check

            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]!))
        };
    });

// ▼ Getting connection string from appsettings and add dbcontext service third and last step for ef core building before set configs and migration ▼
var connectionString = builder.Configuration.GetConnectionString("DreamRosterCS");
builder.Services.AddDbContext<DreamRosterBuildingDbContext>(options => options.UseSqlServer(connectionString));

// ▼ Adding services, dependency injection ▼
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // -> We use type of cause of generic type
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // -> UnitOfWork injection service
builder.Services.AddScoped<IUserService, UserManager>(); // -> User operation injection service
builder.Services.AddScoped<IDataProtection, DataProtection>(); // -> Data protection injection service
builder.Services.AddScoped<IPlayerService, PlayerManager>(); // -> Player operations injection service
builder.Services.AddScoped<IIconService, IconManager>();  // -> Icon operations injection service
builder.Services.AddScoped<ISettingService, SettingManager>(); // -> Setting operations like toggle maintenance mode injection service
builder.Services.AddScoped<ITeamService, TeamManager>(); // -> Team operations injection service

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMaintenanceMode(); // -> This is middleware I created for maintenance mode check you can find in 'Middlewares' folder

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowLocalhost"); // -> Adding my CORS for using this api at my local frontend project

app.UseStaticFiles(); // -> For images in wwwroot

app.Run();
