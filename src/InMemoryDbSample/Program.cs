using InMemoryDbSample.Repository.Dapper;
using InMemoryDbSample.Repository.EFCore;
using InMemoryDbSample.Repository.Interfaces;
using InMemoryDbSample.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace InMemoryDbSample
{
    internal class Program
    {
        private static IServiceProvider _serviceProvider;
        private static IExecute _execute;
        static async Task Main(string[] args)
        {            
            ConfigureServices();

            await Execute();
        }

        private static async Task Execute()
        {
            try
            {

                await _execute.ExecuteAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public static void ConfigureServices()
        {
            var services = new ServiceCollection();           

            var conn = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\DbProduct.mdf;Initial Catalog=DbProduct;Integrated Security=True;";
           
            conn = conn.Replace("|DataDirectory|", System.IO.Directory.GetCurrentDirectory());


            services
                .AddTransient<IDbConnection>(x => new SqlConnection(conn))
                .AddDbContext<DbContext>(
                options =>
                {                   
                    options.UseSqlServer(conn,
                    providerOptions =>
                    providerOptions.EnableRetryOnFailure());
                });


            services.AddTransient<IReadRepository, ReadRepository>();
            services.AddTransient<IWriteRepository, WriteRepository>();
            services.AddScoped<IExecute, Execute>();

            _serviceProvider = services.BuildServiceProvider();
            
            _execute = _serviceProvider.GetRequiredService<IExecute>();

           
        }
    }
}