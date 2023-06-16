using HotelReservation.Models;
using HotelReservation.Repository;
using HotelReservation.Services;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IHotelReservation<Hotel>,HotelRepo>();
            builder.Services.AddTransient<IHotelReservation<City>, CityRepo>();
            builder.Services.AddTransient<IHotelReservation<Employee>, EmployeeRepo>();
            builder.Services.AddTransient<IHotelReservation<Guest>, GuestRepo>();
            builder.Services.AddTransient<IHotelReservation<Room>, RoomRepo>();
            builder.Services.AddDbContext<HotelContext>( a =>
    
              a.UseSqlServer("Server=.;Database=HotelReservation;Trusted_Connection=true")
            );
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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}