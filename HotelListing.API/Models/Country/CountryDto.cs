using HotelListing.API.Models.Hotel;

namespace HotelListing.API.Models.Country;

public class CountryDto : GetCountryDto
{
    public List<GetHotelDto> Hotels { get; set; }
}
