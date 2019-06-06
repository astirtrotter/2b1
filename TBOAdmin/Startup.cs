using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace TBOAdmin
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public static string ConnectionString { get; private set; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // cookie
      services.Configure<CookiePolicyOptions>(options =>
      {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });
      
      // sql server database
      ConnectionString = Configuration.GetConnectionString("DefaultConnection");
      services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));

      // mvc
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      // swagger
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info
        {
          Title = "ToBeOne API",
          Version = "v1",
          Description = "ToBeOne Web API",
          TermsOfService = "None",
          Contact = new Contact
          {
            Name = "Pro Dev",
            Email = "prodev9999@gmail.com",
            Url = "https://github.com/prodev9999"
          },
          License = new License
          {
            Name = "MIT",
            Url = "https://opensource.org/licenses/MIT"
          }
        });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseCookiePolicy();

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToBeOne API v1");
        c.RoutePrefix = string.Empty;
      });

      app.UseMvcWithDefaultRoute();
      //app.UseMvc(routes =>
      //{
      //  routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
      //});
    }
  }
}
