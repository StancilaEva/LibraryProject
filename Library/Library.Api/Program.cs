using Azure.Storage.Blobs;
using Library.Application.Handlers;
using Library.Application.Interfaces;
using Library.Application.JwtTokenGeneration;
using Library.Application.Options;
using Library.Core.Interfaces.RepositoryInterfaces;
using Library.Infrastructure;
using Library.Infrastructure.AzureBlobStorage;
using Library.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(GetAllComicBooksQueryHandler));
builder.Services.AddDbContext<LibraryContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddCors(options => options
.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));


builder.Services.AddTransient(typeof(IBookRepository), typeof(ComicBookRepository));
builder.Services.AddTransient(typeof(IClientRepository), typeof(ClientRepository));
builder.Services.AddTransient(typeof(ILendRepository), typeof(LendRepository));
builder.Services.AddTransient(typeof(IReviewRepository), typeof(ReviewRepository));
builder.Services.AddTransient(typeof(IFavoritesRepository), typeof(FavoritesRepository));
builder.Services.AddTransient((global::System.Type)typeof(global::Library.Application.Interfaces.IUserRegistrator), (global::System.Type)typeof(global::Library.Infrastructure.UserRegistrator));
builder.Services.AddTransient(typeof(RegistrationService));

builder.Services.AddIdentityCore<IdentityUser>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 4;

})
    .AddEntityFrameworkStores<LibraryContext>();
//azure
Console.WriteLine(builder.Configuration.GetConnectionString("AzureBlobStorageConnectionString"));
builder.Services.AddSingleton(x => new BlobServiceClient(builder.Configuration.GetConnectionString("AzureBlobStorageConnectionString")));
builder.Services.AddTransient<IBlobService, BlobService>();
//Automapper
builder.Services.AddAutoMapper(typeof(Program));
//jwt
var jwtSettings = new JwtSettings();
builder.Configuration.Bind(nameof(JwtSettings), jwtSettings);
var jwtSection = builder.Configuration.GetSection(nameof(jwtSettings));
builder.Services.Configure<JwtSettings>(jwtSection);
builder.Services
           .AddAuthentication(a =>
           {
               a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               a.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
               a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           })
           .AddJwtBearer(jwt =>
           {
               jwt.SaveToken = true;
               jwt.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.StringKey)),
                   ValidateIssuer = true,
                   ValidIssuer = jwtSettings.Issuer,
                   ValidateAudience = true,
                   ValidAudiences = jwtSettings.Audiences,
                   RequireExpirationTime = false,
                   ValidateLifetime = true
               };
               jwt.Audience = jwtSettings.Audiences[0];
               jwt.ClaimsIssuer = jwtSettings.Issuer;
           });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
