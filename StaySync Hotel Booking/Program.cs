using Microsoft.EntityFrameworkCore;
using StaySync.Application.Interfaces.Services;
using StaySync.Application.Mapping;
using StaySync.Application.Services;
using StaySync.Infrastructure.Persistence.Context;
using StaySync.Infrastructure.Services;
using StaySync_Hotel_Booking.MiddleWare;
namespace StaySync_Hotel_Booking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StaySyncDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString(
                        "DefaultConnection")));

            builder.Services.AddAutoMapper(
                typeof(MappingProfile));


            // Services
            builder.Services.AddScoped<IHotelService, HotelService>();

            builder.Services.AddScoped<IReservationService, ReservationService>();

            builder.Services.AddScoped<IRoomService, RoomService>();

            builder.Services.AddScoped<IGuestService, GuestService>();

            var app = builder.Build();

            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
