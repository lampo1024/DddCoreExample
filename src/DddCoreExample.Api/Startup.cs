using DddCoreExample.Api.Extensions;
using DddCoreExample.Application.Customers;
using DddCoreExample.Domain.Models.Countries;
using DddCoreExample.Domain.Models.Customers;
using DddCoreExample.Domain.Models.Products;
using DddCoreExample.Domain.Models.Tax;
using DddCoreExample.Domain.Repository;
using DddCoreExample.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DddCoreExample.Api
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
            //services.AddSingleton<MemoryRepository<Customer>>();
            //services.AddSingleton<MemoryRepository<Country>>();
            //services.AddSingleton<MemoryRepository<CountryTax>>();
            //services.AddSingleton<MemoryRepository<Product>>();
            //services.AddSingleton<MemoryRepository<ProductCode>>();
            //services.AddSingleton<MemoryRepository<Purchase>>();

            services.AddSingleton(typeof(MemoryRepository<>));

            services.AddSingleton(typeof(IRepository<>), typeof(MemoryRepository<>));
            services.AddScoped<IUnitOfWork, MemoryUnitOfWork>();


            services.AddScoped<IRepository<Customer>, StubDataCustomerRepository>();
            services.AddScoped<IRepository<ProductCode>, StubDataProductCodeRepository>();
            services.AddScoped<IRepository<Country>, StubDataCountryRepository>();
            services.AddScoped<IRepository<CountryTax>, StubDataCountryTaxRepository>();
            services.AddScoped<IRepository<Product>, StubDataProductRepository>();

            services.AddScoped<ICustomerService, CustomerService>();

            services.AddAutoMapperService();

            services.AddRazorPages();
            services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; });
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            //app.UseMvc(routes => { routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}"); });
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
