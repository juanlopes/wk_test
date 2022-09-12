using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using WKTest.Common;
using WKTest.DataAccessObject.Repositories;
using WKTest.DataAccessObject.Services;

namespace WKTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                new DataContext(new Config()).Database.EnsureCreated();
            }
            catch
            {
                throw new System.Exception("Não foi possível criar/conectar ao banco de dados, verifique suas credenciais em Common.Services.Config e tente novamente.");
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
