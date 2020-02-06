using ClassLibrary.Handlers;
using ClassLibrary.Repositories;
using Infra.Context;
using Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebAPI
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
            services.AddControllers();
            //services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("Centro"));  b => b.MigrationsAssembly("Infra")
            // in Memory Databases
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Infra")));
            services.AddTransient<ITodoRepository, TodoRepository>();
            services.AddTransient<TodoHandler, TodoHandler>(); // teria que criar 1 pra cada ação de command
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();
            //app.UseCors(x => x
            //.AllowAnyOrigin()
            //.AllowAnyMethod()
            //.AllowAnyHeader()
            //);

            //app.UseAuthentication();
            //app.UseAuthorization();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
