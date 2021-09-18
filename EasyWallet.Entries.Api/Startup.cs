using EasyWallet.Data;
using EasyWallet.Entries.Business.Abstractions;
using EasyWallet.Entries.Business.Services;
using EasyWallet.Entries.Data;
using EasyWallet.Entries.Data.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore;

namespace EasyWallet.Entries.Api
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
            services.AddDbContextPool<EntryContext>(o => {
                var version = new MySqlServerVersion(new Version(5, 7));
                o.UseMySql(
                    Configuration["ConnectionString"], 
                    version, 
                    x => x.MigrationsAssembly("EasyWallet.Entries.Data"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IEntryService, EntryService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}