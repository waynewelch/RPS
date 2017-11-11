using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RpsPolicyApp.DbContext;
using Microsoft.EntityFrameworkCore;
using RpsPolicyApp.Models;
using RpsPolicyApp.ResponseObjects;
using RpsPolicyApp.Services;

namespace RpsPolicyApp
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    /// <summary>
    /// This method gets called by the runtime to add services to the container
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    public void ConfigureServices(IServiceCollection services)
    {
      const string connection = @"Server=tcp:rpspolicyappdbserver.database.windows.net,1433;Initial Catalog=RpsPolicyApp_db;Persist Security Info=False;User ID=waynewelch;Password=n3nehaP9;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
      services.AddDbContext<PolicyDbContext>(options => options.UseSqlServer(connection));
      services.AddTransient<IPolicy, Policy>();
      services.AddTransient<IPolicyService, PolicyService>();
      services.AddTransient<IPolicyResponse, PolicyResponse>();
      services.AddMvc();
    }

    /// <summary>
    /// This method gets called by the runtime to configure the HTTP request pipeline.
    /// </summary>
    /// <param name="app"><see cref="IApplicationBuilder"/></param>
    /// <param name="env"><see cref="IHostingEnvironment"/></param>
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
        {
          HotModuleReplacement = true
        });
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseStaticFiles();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");

        routes.MapSpaFallbackRoute(
                  name: "spa-fallback",
                  defaults: new { controller = "Home", action = "Index" });
      });
    }
  }
}
