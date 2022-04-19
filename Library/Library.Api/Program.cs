using Library.Application.Handlers;
using Library.Core.Interfaces.RepositoryInterfaces;
using Library.Infrastructure;
using Library.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(GetAllComicBooksQueryHandler));
//builder.Services.AddDbContext<LibraryContext>(options=>
//options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddDbContext<LibraryContext>();

builder.Services.AddTransient(typeof(IBookRepository), typeof(ComicBookRepository));
builder.Services.AddTransient(typeof(IClientRepository), typeof(ClientRepository));
builder.Services.AddTransient(typeof(ILendRepository), typeof(LendRepository));
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
