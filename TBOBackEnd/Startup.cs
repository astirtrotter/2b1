using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSwag.AspNetCore;

namespace TBOBackEnd
{
  public class Startup
  {
    public static string ConnectionString { get; private set; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // sql server database
      ConnectionString = Configuration.GetConnectionString("DefaultConnection");
      services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      services.AddCors(options =>
      {
        options.AddPolicy("default", policy =>
        {
          policy.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
      });

      // Register the Swagger services
      services.AddSwaggerDocument(config =>
      {
        config.PostProcess = document =>
        {
          document.Info.Version = "v1";
          document.Info.Title = "ToBeOne";
          document.Info.Description = "ToBeOne Restful APIs";
          document.Info.TermsOfService = "None";
          document.Info.Contact = new NSwag.OpenApiContact
          {
            Name = "Pro Dev",
            Email = "prodev9999@gmail.com",
            Url = "https://github.com/prodev9999"
          };
          document.Info.License = new NSwag.OpenApiLicense
          {
            Name = "MIT",
            Url = "https://opensource.org/licenses/MIT"
          };
        };
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseCors("default");

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      // Register the Swagger generator and the Swagger UI middlewares
      app.UseOpenApi();
      app.UseSwaggerUi3();

      app.UseStaticFiles();
      app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}
