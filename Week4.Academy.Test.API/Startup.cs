using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week4.Academy.Test.Core.BusinessLayer;
using Week4.Academy.Test.Core.Repositories;
using Week4.Academy.Test.EF;
using Week4.Academy.Test.EF.Repositories;

namespace Week4.Academy.Test.API
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
            services.AddControllers();

            //services.AddTransient<MainBusinessLayer>();
            services.AddTransient<IBusinessLayer, MainBusinessLayer>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddTransient<ICustomerRepository, EFCustomerRepository>();
            services.AddDbContext<ServicesContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("servicesDb"));
            }
            );
        }

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
