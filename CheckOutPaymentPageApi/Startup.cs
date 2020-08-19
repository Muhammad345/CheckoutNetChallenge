using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckOutCore.AcquiringSettings;
using CheckOutCore.Client;
using CheckOutRepository.Context;
using CheckOutRepository.Model;
using Core.IServices;
using Core.Servcies;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using Repository.Models;
using Repository.Validation;

namespace CheckOutPaymentPageApi
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
            services.Configure<CheckOutSettings>(Configuration.GetSection("CheckOutSettings"));
            services.Configure<MerchantSetting>(Configuration.GetSection("MerchantSetting"));
            services.AddControllersWithViews().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CardDetailValidator>());

            services.AddTransient<IValidator<CardDetail>, CardDetailValidator>();
            services.AddSingleton<IHttpClient, CheckOutHttpClient>();
            AddRepositoryDependencies(services);
            AddServicesDependencies(services);

            services.AddDbContext<CheckoutPaymentGatewayAPIContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CheckOutSqlContext"))
             .EnableSensitiveDataLogging());
        }

        private static void AddRepositoryDependencies(IServiceCollection services)
        {
            services.AddTransient<IRepository<MerchantConfig>, MerchantConfigRepository>();
        }

        private static void AddServicesDependencies(IServiceCollection services)
        {
            services.AddTransient<ICardApiService, CardApiService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=CardDetails}/{action=Create}/{id?}");
            });
        }
    }
}
