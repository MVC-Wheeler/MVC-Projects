using Ecom.Data;
using Ecom.Models;
using Ecom.Repo;
using Ecom.Repo.IRepo;
using Microsoft.EntityFrameworkCore;

namespace Ecom
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(
                opt=> opt.UseSqlServer(
                    builder.Configuration.GetConnectionString("conn")

                    )
                );
            // DI lifetimes
            // scoped
            builder.Services.AddScoped<IProductRepo,ProductRepo>();// register dependency
            // Singleton --> log
            //builder.Services.AddSingleton<IProductRepo,ProductRepo>();// register dependency
            //// Transient
            //builder.Services.AddTransient<IProductRepo,ProductRepo>();// register dependency

           // builder.Services.AddSingleton<Itest, Test>();
            //builder.Services.AddScoped<Itest, Test>();
            builder.Services.AddTransient<Itest, Test>();
          
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
