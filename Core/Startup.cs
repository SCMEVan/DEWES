using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.LibraryHelper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var libraryManager = new LibraryManager();
            if (!libraryManager.DataConverterLibrariesLoader.CheckDuplicates)
                throw new Exception("Обнаружены дубли в библиотеках конвертерах");
            
            services.AddSingleton(new LibraryManager());
            services.AddControllers();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //На время разработки страница исключений всегда включена, а редирект на https выключен 
            app.UseDeveloperExceptionPage();
            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}