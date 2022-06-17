using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SAP.Core.Respositories.Interface;
using SAP.Domain.Configuration;
using SAP.Domain.Respositories.Concrete;
using SAP_BusinessLogic.DTOs;
using SAP_BusinessLogic.Extensions;
using SAP_BusinessLogic.Helpers;
using SAP_BusinessLogic.Models.Database.Logs;
using SAP_BusinessLogic.Services.Concrete;
using SAP_BusinessLogic.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data;
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

            // Add functionality to inject IOptions<T>
            services.AddOptions();

            // Add our Config object so it can be injected
            services.Configure<SAPConfig>(Configuration.GetSection("SAP"));

            // Add service health check
            services.AddHealthChecks();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SAP.API", Version = "v1" });
                //c.OperationFilter<CustomHeaderFilter>
            });

            // Register Code First Migrations Dependencies
            services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(
           Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("SAP_BusinessLogic")));

            // Register Dapper Dependencies
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddTransient<IDbConnection>(prov => new SqlConnection(prov.GetService<IConfiguration>().GetConnectionString("DefaultConnection")));

            // Register Repositories
            services.AddScoped<IAccountCreationRepo, AccountCreationRepo>();


            // Register Services
            services.AddTransient<IAccountSetupService, AccountSetupService>();
            //services.AddTransient<ICategoriesRepository, CategoriesRepository>();
            //services.AddTransient<IQtResponseRepository, QtResponseRepository>();
            //services.AddTransient<IPaymentItemsRepository, PaymentItemsRepository>();
            //services.AddTransient<IPageFlowInfoRepository, PageFlowInfoRepository>();


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
                app.UseHttpsRedirection();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "SAP.API v1"));
            }

            //app.UseSwagger();
            //app.UseSwaggerUI(c => c.SwaggerEndpoint("../v1/swagger.json", "SAP.API v1"));

            

            app.UseRouting();

            //app.UseMiddleware<RequestResponseLoggingMiddleware>();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
