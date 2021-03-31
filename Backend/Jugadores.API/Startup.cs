using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Jugadores.Core.Interfaces;
using Jugadores.Core.Services;
using Jugadores.Infrastructure.Data;
using Jugadores.Infrastructure.Filters;
using Jugadores.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Jugadores.API
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Para ignorar la dependencia ciclica
            services.AddControllers(options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();

            }).AddNewtonsoftJson(options =>

                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            ).ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true; 
            });


            services.AddDbContext<JuegosContext>(options =>
                       options.UseSqlServer(Configuration.GetConnectionString("JuegosDB"))
               );

            ConfigureRepositories(services);
            ConfigureServicio(services);

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidationFilter));
                //options.Filters.Add<ValidationFilter>();

            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureRepositories(IServiceCollection services)
        {

      

            // Servicios
            services.AddTransient<IEquipoService, EquipoService>();
            services.AddTransient<IJugadorService, JugadorService>();

            // Repositorios
            services.AddTransient<IEquipoRepository, EquiposRepository>();
            services.AddTransient<IJugadorRepository, JugadorRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();



        }

        public void ConfigureServicio(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

        }
    }
}
