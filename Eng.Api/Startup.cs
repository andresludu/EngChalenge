using AutoMapper;
using Eng.Api.Infrastructure.IoC;
using Eng.Api.Models.Mapper;
using Eng.Data.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ServiceStartup = Eng.Service.Startup;

namespace Eng.Api
{

  public class Startup
  {
    private readonly IConfiguration config;

    public Startup(IConfiguration config)
    {
      this.config = config;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext();

      services.AddCors(options =>
      {
        options.AddPolicy(
            name: "AllowOrigin",
            builder =>
            {
          builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
      });

      // Auto Mapper Configurations
      var mappingConfig = new MapperConfiguration(mc =>
            {
              mc.AddProfile(new MappingProfile());
              mc.AddProfile(new AplicationData.Mappers.MappingProfile());
            });

      IMapper mapper = mappingConfig.CreateMapper();
      services.AddSingleton(mapper);

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Eng", Version = "v1" });
      });

      DependencyInjection.ConfigureServices(ref services);
      ServiceStartup.ConfigureServices(ref services, this.config);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseCors("AllowOrigin");

      DbInitializer.Initialize(app).Wait();

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Eng v1"));
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
