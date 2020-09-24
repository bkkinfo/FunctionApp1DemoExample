using FunctionApp1DemoExample.Data;
using FunctionApp1DemoExample.Repository;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(FunctionApp1DemoExample.Startup))]
namespace FunctionApp1DemoExample
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string sqlConnection = Environment.GetEnvironmentVariable("DevConnection");
            builder.Services.AddDbContext<LibraryDbContext>(x => x.UseSqlServer(sqlConnection));
            builder.Services.AddScoped<IBookRepository, BooksRepository>();
        }
        //public IConfiguration Configuration { get; }
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public override void Configure(IFunctionsHostBuilder builder)
        //{
        //    string sqlConnection = Configuration.GetConnectionString("DevConnection");
        //    builder.Services.AddDbContext<LibraryDbContext>(x => x.UseSqlServer(sqlConnection));
        //    builder.Services.AddScoped<IBookRepository, BooksRepository>();
        //}


    }
    public class LibraryDbContextFactory : IDesignTimeDbContextFactory<LibraryDbContext>
    {
        public LibraryDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryDbContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DevConnection"));
            return new LibraryDbContext(optionsBuilder.Options);
        }
    }
}