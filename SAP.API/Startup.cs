using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SAP.Core.Respositories.Concrete;
using SAP.Core.Respositories.Interface;
using SAP_BusinessLogic.DTOs;
using SAP_BusinessLogic.Extensions;
using SAP_BusinessLogic.Helpers;
using SAP_BusinessLogic.Models.Database.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAP.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SAP.API", Version = "v1" });
            });

            // Register Code First Migrations Dependencies
            services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(
           Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("SAP_BusinessLogic")));

            // Register Dapper Dependencies
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // Register Repositories
            services.AddScoped<IAccountCreationRepo, AccountCreationRepo>();

            // Register Helpers
            services.AddScoped<IUtil, Util>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SAP.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<RequestResponseLoggingMiddleware>();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
