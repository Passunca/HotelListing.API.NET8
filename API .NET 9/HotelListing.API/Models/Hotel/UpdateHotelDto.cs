using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models.Hotel;

public class UpdateHotelDto : BaseHotelDto
{
    [Required]
    public int Id { get; set; }
}
