using CRUD1.Data;
using CRUD1.Repositories;
using CRUD1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CRUD1
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
            //Conexão com o banco
            services.AddDbContext<Context>(options =>
                      options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IClientRepository, ClientRepository>();

            services.AddControllersWithViews();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Clients}/{action=Index}/{id?}");
            });
        }
    }
}