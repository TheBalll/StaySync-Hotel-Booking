using Microsoft.EntityFrameworkCore;
using StaySync.Application.Interfaces.Repositories;
using StaySync.Application.Interfaces.Services;
using StaySync.Application.Mapping;
using StaySync.Application.Services;
using StaySync.Infrastructure.Persistence.Context;
using StaySync.Infrastructure.Repositories;
using StaySync.Infrastructure.Services;
using StaySync_Hotel_Booking.MiddleWare;
using FluentValidation;
using FluentValidation.AspNetCore;
using StaySync.Application.Validators;
using StaySync_Hotel_Booking.API.GraphQL;
namespace StaySync_Hotel_Booking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
              // Това прави така, че ако моделът е невалиден, 
              // да се връщат точно твоите FluentValidation съобщения.
             options.SuppressModelStateInvalidFilter = false;
            });

            builder.Services.AddControllers(options =>
            {
                // Изключва автоматичното [Required] за string полета без ?
                options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
            })
              .ConfigureApiBehaviorOptions(options =>
              {
               options.SuppressModelStateInvalidFilter = false;
              });

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<CreateGuestRequestValidator>();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StaySyncDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString(
                        "DefaultConnection")));

            builder.Services.AddAutoMapper(
                typeof(MappingProfile));

            builder.Services.AddScoped<IHotelRepository, HotelRepository>();

            builder.Services.AddDbContext<StaySyncDbContext>(options =>
            options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            x => x.MigrationsAssembly("StaySync.Infrastructure")));

            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

            // Services
            builder.Services.AddScoped<IHotelService, HotelService>();

            builder.Services.AddScoped<IReservationService, StaySync.Infrastructure.Services.ReservationService>();

            builder.Services.AddScoped<IRoomService, RoomService>();

            builder.Services.AddScoped<IGuestService, GuestService>();

            builder.Services.AddScoped<IAdditionalService, AdditionalServiceImplementation>();

            builder.Services
           .AddGraphQLServer()
           .AddQueryType<Query>()
           .AddFiltering()  // Добави това
           .AddSorting();

            var app = builder.Build();

            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseMiddleware<ExceptionMiddleware>();
            
            app.MapGraphQL();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
