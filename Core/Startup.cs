using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.LibraryHelper;
using DEWESDb;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            services.AddDbContext<DbScheduleContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));
            services.AddSingleton(libraryManager);
            services.AddControllers();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Создаем базу если она ещё не создана
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<DbScheduleContext>();
                db.Database.Migrate();
                var libraryManager = serviceScope.ServiceProvider.GetService<LibraryManager>();
                
            }
            
            
            //На время разработки страница исключений всегда включена, а редирект на https выключен 
            app.UseDeveloperExceptionPage();
            //app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}