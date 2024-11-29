using LibaryManagement.BL.Abstractions.Book;
using LibaryManagement.BL.Abstractions.Member;
using LibaryManagement.BL.Services.Book;
using LibaryManagement.BL.Services.Member;
using LibaryManagement.WebAPI.Middlewares;
using LibaryMangement.DL.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LibaryManagement.WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddTransient<ExceptionHandlerMidddleware>();

        builder.Services.AddDbContext<AppDbContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("DafaultConnection")));

        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

        builder.Services.AddScoped<IBookService, BookService>();
        builder.Services.AddScoped<IMemberService, MemberService>();

        WebApplication app = builder.Build();

        app.UseMiddleware<ExceptionHandlerMidddleware>();
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
