using StaySync.Application.Interfaces.Services;
using StaySync.Application.DTOs.Responses;
using HotChocolate.Data;
namespace StaySync_Hotel_Booking.API.GraphQL;

public class Query
{
    // Слагаш атрибутите точно над метода
    [UseFiltering]
    [UseSorting]
    public async Task<IEnumerable<GuestResponse>> GetGuests([Service] IGuestService guestService)
    {
        return await guestService.GetAllAsync();
    }

    // Тук можеш да добавиш и метод за стаите по-късно, например:
    // [UseFiltering]
    // [UseSorting]
    // public async Task<IEnumerable<RoomResponse>> GetRooms([Service] IRoomService roomService) => await roomService.GetAllAsync();
}
