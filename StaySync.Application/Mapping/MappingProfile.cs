using AutoMapper;
using StaySync.Application.DTOs.Requests;
using StaySync.Application.DTOs.Responses;
using StaySync.Domain.Entities;


namespace StaySync.Application.Mapping;

/// <summary>
/// AutoMapper profile.
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Hotel mappings
        CreateMap<CreateHotelRequest, Hotel>();

        CreateMap<UpdateHotelRequest, Hotel>();

        CreateMap<Hotel, HotelResponse>();


        // Reservation mappings
        CreateMap<CreateReservationRequest, Reservation>();

        CreateMap<UpdateReservationRequest, Reservation>();

        CreateMap<Reservation, ReservationResponse>()
            .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(
                    src => src.Status.ToString()));
    }
}
