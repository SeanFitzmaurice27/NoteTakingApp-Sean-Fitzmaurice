using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NoteTakingApp.DataAccess;
using NoteTakingApp.DataAccess.Entities;
using NoteTakingApp.Domain;

namespace NoteTakingApp.WebApp
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
            // ASP.NET implements a DI container
            // such that, you register services globally here,
            // and then, they'll be automatically instantiated and provided
            //    to the constructors that need them.

            // there are three "service lifetimes":
            // - singleton - one instance of the class, one object,
            //                shared among all objects that request one via ctor
            // - scoped - one instance shared within each "scope"
            //              (each HTTP request lifecycle is one scope)
            //              (the default for DbContexts)
            // - transient - no instances shared, every time a new object

            //services.AddSingleton(new Note { Text = "hello" });

            if (Configuration["OtherRepository"] == "true")
            {
                //services.AddScoped<IRepository, NonEfRepository>();
            }
            else
            {
                // "if a class asks for an IRepository, give it a Repository"
                services.AddScoped<IRepository, Repository>();
            }
            services.AddDbContext<NotesDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("NotesDb"));
                options.LogTo(Console.WriteLine);
            });

            services.AddControllersWithViews();
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
                //endpoints.MapControllerRoute(
                //    name: "userdetails",
                //    pattern: "userdetails/{email}",
                //    defaults: new { controller = "User", action = "Details" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
