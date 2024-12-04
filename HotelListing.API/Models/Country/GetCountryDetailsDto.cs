using HotelListing.API.Models.Hotel;

namespace HotelListing.API.Models.Country;

public class GetCountryDetailsDto : GetCountryDto
{
    public List<BaseHotelDto> Hotels { get; set; }
}
