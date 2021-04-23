using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Устанавливаем базовую директорию в которой находиться exe файл
            Directory.SetCurrentDirectory(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location));
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}