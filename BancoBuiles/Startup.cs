using Common.Middleware;
using DataAccess;
using DataAccess.Repositories;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BancoBuiles
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(
                Configuration.GetConnectionString("BancoBuilesConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            services.AddTransient(typeof(IClienteRepository), typeof(ClienteRepository));
            services.AddTransient(typeof(ICuentaRepository), typeof(CuentaRepository));
            services.AddTransient(typeof(IMovimientoRepository), typeof(MovimientoRepository));
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddTransient(typeof(IClienteServicio), typeof(ClienteServicio));
            services.AddTransient(typeof(ICuentaServicio), typeof(CuentaServicio));
            services.AddTransient(typeof(IMovimientoServicio), typeof(MovimientoServicio));       

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BancoBuiles", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BancoBuiles v1"));
            }

            app.UseMiddleware<ErrorHandlerMiddleware>();
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
