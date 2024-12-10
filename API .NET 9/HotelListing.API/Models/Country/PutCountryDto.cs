using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models.Country;

public class UpdateCountryDto : BaseCountryDto
{
    [Required]
    public int Id { get; set; }
}
