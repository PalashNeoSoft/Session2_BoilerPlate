using Microsoft.EntityFrameworkCore;
using Session2_BoilerPlate.AppDbContext;
using Session2_BoilerPlate.Configurations;
using Session2_BoilerPlate.Repository;
using Session2_BoilerPlate.Services;
using System.Text;

namespace Session2_BoilerPlate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            string con = builder.Configuration.GetConnectionString("localConnectionString");
            builder.Services.AddDbContext<UserDbContext>(p => p.UseSqlServer(con));
            builder.Services.AddAutoMapper(typeof(MapperConfig));
            builder.Services.AddScoped<IUserServices , UserServices>();

            builder.Services.AddScoped<IUserRepository , UserRepository>();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Index}/{id?}");

            app.Run();
        }
    }
}