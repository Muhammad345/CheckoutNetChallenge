using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
using Shared;

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

            services.AddAutoMapper(GetAutoMapperProfilesFromAllAssemblies()
                .ToArray());
        }

        private static IEnumerable<Type> GetAutoMapperProfilesFromAllAssemblies()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var aType in assembly.GetTypes())
                {
                    if (aType.IsClass && !aType.IsAbstract && aType.IsSubclassOf(typeof(Profile)))
                        yield return aType;
                }
            }
        }

        private static void AddRepositoryDependencies(IServiceCollection services)
        {
            services.AddTransient<IRepository<MerchantConfig>, MerchantConfigRepository>();
            services.AddTransient<IRepository<CardDetail>, CardDetailRepository>();
            services.AddTransient<IRepository<PaymentDetail>, PaymentDetailRepository>();
        }

        private static void AddServicesDependencies(IServiceCollection services)
        {
            services.AddTransient<ICardApiService, CardApiService>();
            services.AddTransient<IPaymentDetailDataService, PaymentDetailDataService>();
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

            UpdateDatabase(app);
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<CheckoutPaymentGatewayAPIContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
