using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ApplicationServices;
using Core.ApplicationServices.Services;
using Core.DomainServices;
using Infrastructure.SQL.Repositories;
using Infrastructure.SQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;


namespace WebShopF
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FruitContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

           // services.AddDbContext<FruitContext>(opt => opt.UseSqlite("Data Source = FruitShopDB.db"));
            

            services.AddScoped<IFruitRepo, FruitRepos>();
           

            services.AddScoped<IFruitService, FruitService>();
            ;

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                opt.SerializerSettings.MaxDepth = 2;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider
                    .GetRequiredService<FruitContext>();


                if (env.IsDevelopment())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    DBInitializer.Initialize(context);
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    DBInitializer.Initialize(context);
                    app.UseHsts();
                }
            }

            app.UseHttpsRedirection();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseMvc();
        }
    }
}
