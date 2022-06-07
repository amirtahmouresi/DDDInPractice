using DDDInPractice.Logic;
using DDDInPractice.Logic.Context;
using DDDInPractice.Logic.Interface.Repository;
using DDDInPractice.Logic.Interface.Repository.SnackMachines;
using DDDInPractice.Logic.Repository;
using DDDInPractice.Logic.Repository.SnackMachines;
using DDDInPractice.Logic.Service.SnackMachines;
using DDDInPractice.UI.Models;
using Microsoft.EntityFrameworkCore;

namespace DDDInPractice.UI
{
    public class Startup
    {
        private IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ISnackMachineRepository, SnackMachineRepository>();
            services.AddScoped<ISnackMachineService, SnackMachineService>();
            services.AddScoped<SnackMachineViewModel>();

            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyConnection")), ServiceLifetime.Singleton);
        }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoint =>
            {

                endpoint.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });

           
        }
    }
}
