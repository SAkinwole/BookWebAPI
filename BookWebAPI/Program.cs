using BookWebAPI.Data;
using BookWebAPI.Repositories;
using BookWebAPI.Services.Implementations;
using BookWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exceptionHandler =
            context.Features.Get<IExceptionHandlerFeature>();

        var exception = exceptionHandler?.Error;

        if (exception != null)
        {
            var logger = context.RequestServices
                .GetRequiredService<ILogger<Program>>();

            logger.LogError(
                exception,
                "Unhandled exception while processing request");
        }

        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("Internal Server Error");
    });
});
app.MapControllers();

app.Run();
