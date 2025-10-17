using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Route.GYM.BLL.Mapper;
using Route.GYM.BLL.Services.Analytics;
using Route.GYM.BLL.Services.Members;
using Route.GYM.BLL.Services.Plans;
using Route.GYM.BLL.Services.Sessions;
using Route.GYM.BLL.Services.Trainers;
using Route.GYM.DAL.Persistence.Data.Contexts;
using Route.GYM.DAL.Persistence.Data.DataSeeds;
using Route.GYM.DAL.Persistence.UnitOfWork;

namespace Route.MVCGYM.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region DI Container

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IUnitOfWork , UnitOfWork>();
            builder.Services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));
            builder.Services.AddScoped<IMemberService, MemberService>();
            builder.Services.AddScoped<ITrainerService, TrainerService>();
            builder.Services.AddScoped<ISessionService, SessionService>();
            builder.Services.AddScoped<IPlanService, PlanService>();
            builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();
            builder.Services.AddDbContext<GymDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            #endregion

            var app = builder.Build();

            #region Data Seeding

            using var scope = app.Services.CreateScope();

            var gemDbContext = scope.ServiceProvider.GetRequiredService<GymDbContext>();

            GymDataSeeding.SeedData(gemDbContext);

            #endregion

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
