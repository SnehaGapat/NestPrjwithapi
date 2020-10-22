using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NestSeeker.Data.Model;
using NestSeeker.Persistence;
using NestSeeker.Persistence.Infrastructure;
using NestSeeker.Service;

namespace NestSeeker.Web
{
    public class Startup
    {
        //private readonly IConfigurationRoot _configRoot;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           /* IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            this._configRoot = builder.Build();*/
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IUserService,UserService>();
            services.AddTransient<NestSeekerContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>(); //RP
            services.AddTransient<IRepository<User>, Repository<User>>(); //RP
           // services.AddDbContext<NestSeekerContext>(Configuration, _configRoot);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
