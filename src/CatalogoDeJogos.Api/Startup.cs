using AutoMapper;
using CatalogoDeJogos.Api.Models;
using CatalogoDeJogos.Api.Entities;
using CatalogoDeJogos.Api.Interfaces.Services;
using CatalogoDeJogos.Api.Repositories;
using CatalogoDeJogos.Api.Services;
using CatalogoDeJogos.Api.Context;
using CatalogoDeJogos.Api.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System;
//using System.IO;

namespace CatalogoDeJogos.Api
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
            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1",
                    new OpenApiInfo()
                    {
                        Title = "Catalogo de Jogos",
                        Version = "v1"
                    });
                    
                c.IncludeXmlComments("CatalogoDeJogos.Api.xml");
            });

            services.AddScoped<IJogoRepository, JogoRepository>();
            services.AddScoped<IJogoService, JogoService>();
            

            services.AddDbContext<CatalogoDeJogosContext>(options => options.UseInMemoryDatabase("CatalogoDeJogos"));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalogo de Jogos - v1");
            });

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
