using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.Models.Country;
using HotelListing.API.Models.Hotel;

namespace HotelListing.API.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Hotel, CreateCountryDto>().ReverseMap();
        CreateMap<Hotel, GetCountryDto>().ReverseMap();
        CreateMap<Hotel, GetCountryDetailsDto>().ReverseMap();
        CreateMap<Hotel, UpdateCountryDto>().ReverseMap();

        CreateMap<Hotel, BaseHotelDto>().ReverseMap();
        CreateMap<Hotel, CreateHotelDto>().ReverseMap();
        CreateMap<Hotel, HotelDto>().ReverseMap();
        CreateMap<Hotel, UpdateHotelDto>().ReverseMap();
    }
}
