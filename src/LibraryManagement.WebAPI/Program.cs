using LibraryManagement.BL.Abstractions.Book;
using LibraryManagement.BL.Abstractions.Member;
using LibraryManagement.BL.Services.Book;
using LibraryManagement.BL.Services.Member;
using LibraryManagement.WebAPI.Middlewares;
using LibraryMangement.DL.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LibraryManagement.WebAPI;

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
