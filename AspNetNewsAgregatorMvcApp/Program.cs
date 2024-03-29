using AspNetNewsAgregator.Business.ServicesImplementations;
using AspNetNewsAgregator.Core.Abstractions;
using AspNetNewsAgregator.Data.Abstractions;
using AspNetNewsAgregator.Data.Abstractions.Repositories;
using AspNetNewsAgregator.Data.Repositories;
using AspNetNewsAgregator.DataBase;
using AspNetNewsAgregator.DataBase.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

namespace AspNetNewsAgregatorMvcApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((ctx, lc) => 
            lc.WriteTo.File(
                @"C:\Users\Admi\Desktop\����� �����\logs\data.log",
                LogEventLevel.Information)
                .WriteTo.Console(LogEventLevel.Verbose));

            // Add services to the container.
            builder.Services.AddControllersWithViews(options =>
            {
            //    options.Filters.Add<CustomActionFilter>();
            //    // alternative options
            //    options.Filters.Add(typeof(CustomActionFilter));
            //    options.Filters.Add(new CustomActionFilter());
            });

            builder.Services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
                    options.LoginPath = new PathString(@"/Account/Login");
                    options.LogoutPath = new PathString(@"/Account/Login");
                    options.AccessDeniedPath = new PathString(@"/Account/Login");

                });

            var connectionString = builder.Configuration.GetConnectionString("Default");
                //"Server=L340;Database=GoodNewsAggregatorDataBase;Trusted_Connection=True;TrustServerCertificate=True";
            builder.Services.AddDbContext<GoodNewsAggregatorContext>(
                optionsBuilder => optionsBuilder.UseSqlServer(connectionString));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped<IArticleService, ArticleService>(); 
            builder.Services.AddScoped<ISourceService, SourceService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IAdditionalArticleRepository, ArticleGenericRepository>();
            builder.Services.AddScoped<IRepository<Source>, Repository<Source>>();
            builder.Services.AddScoped<IRepository<User>, Repository<User>>();
            builder.Services.AddScoped<IRepository<Role>, Repository<Role>>();
            builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
            builder.Services.AddScoped<ISourceRepository, SourceRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //builder.Services.AddScoped<ArticleCheckerActionFilter>(); -> registration filter for service filter

            builder.Configuration.AddJsonFile("secrets.json");

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

            app.UseAuthentication();  // set HttpContext.User
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}