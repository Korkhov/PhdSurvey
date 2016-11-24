using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PhdSurvey.Models;
using PhdSurvey.Models.ViewModels;

namespace PhdSurvey
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            Globals.Surveys = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SurveyViewModel>>(System.IO.File.ReadAllText(env.ContentRootPath + @"\Surveys.json"));
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<PhdSurveyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationScheme = "CookieAuthenticationInstance",
                LoginPath = new PathString("/Account/Login/"),
                AccessDeniedPath = new PathString("/Account/Login/"),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
