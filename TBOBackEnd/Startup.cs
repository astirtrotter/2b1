using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NSwag.AspNetCore;
using TBOBackEnd.Helpers;
using TBOBackEnd.Services;

namespace TBOBackEnd
{
  public class Startup
  {
    public static string ConnectionString { get; private set; }
    public static ILoggerRepository repository { get; set; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
      repository = LogManager.CreateRepository("NETCoreRepository");
      XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.Configure<IISOptions>(options =>
      {
        options.AutomaticAuthentication = false;
      });

      // sql server database
      ConnectionString = Configuration.GetConnectionString("DefaultConnection");
      services.AddDbContext<_AppDbContext>(options => options.UseSqlServer(ConnectionString));
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      services.AddCors(options =>
      {
        options.AddPolicy("default", policy =>
        {
          policy.WithOrigins("http://localhost:3001")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
      });

      // configure strongly typed settings objects
      var appSettingsSection = Configuration.GetSection("AppSettings");
      services.Configure<AppSettings>(appSettingsSection);

      // configure jwt authentication
      var appSettings = appSettingsSection.Get<AppSettings>();
      var key = Encoding.ASCII.GetBytes(appSettings.Secret);
      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(x =>
      {
        x.Events = new JwtBearerEvents
        {
          OnTokenValidated = context =>
          {
            var adminService = context.HttpContext.RequestServices.GetRequiredService<IAdminService>();
            var adminId = context.Principal.Identity.Name;
            var admin = adminService.GetById(adminId);
            if (admin == null)
            {
                    // return unauthorized if admin no longer exists
                    context.Fail("Unauthorized");
            }
            return Task.CompletedTask;
          }
        };
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false
        };
      });

      // configure DI for application services
      services.AddScoped<IAdminService, AdminService>();

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
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      var log = LogManager.GetLogger(repository.Name, typeof(Startup));
      log.Info("Startup->Configure");

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
      app.UseAuthentication();
      app.UseMvc();
    }
  }
}
