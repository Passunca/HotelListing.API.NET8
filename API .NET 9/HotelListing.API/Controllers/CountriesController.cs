using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using HotelListing.API.Models.Country;
using AutoMapper;
using HotelListing.API.Contracts;

namespace HotelListing.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICountriesRepository _countriesRepository;

    public CountriesController(IMapper mapper, ICountriesRepository countriesRepository)
    {
        _mapper = mapper;
        _countriesRepository = countriesRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
    {
        var countries = await _countriesRepository.GetAllAsync();
        var records = _mapper.Map<List<GetCountryDto>>(countries);
        return records;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetCountryDetailsDto>> GetCountry(int id)
    {
        var country = await _countriesRepository.GetCountryDetails(id);

        if (country == null)
        {
            return NotFound();
        }

        GetCountryDetailsDto countryDto = _mapper.Map<GetCountryDetailsDto>(country);

        return countryDto;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountryDto)
    {
        if (id != updateCountryDto.Id)
        {
            return BadRequest();
        }

        var country = await _countriesRepository.GetAsync(id);

        if (country == null)
        {
            return NotFound();
        }

        _mapper.Map(updateCountryDto, country);

        try
        {
            await _countriesRepository.UpdateAsync(country);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await CountryExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Country>> PostCountry(CreateCountryDto countryDto)
    {
        Country country = _mapper.Map<Country>(countryDto);
        await _countriesRepository.AddAsync(country);

        return CreatedAtAction("GetCountry", new { id = country.Id }, country);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCountry(int id)
    {
        var country = await _countriesRepository.GetAsync(id);
        if (country == null)
        {
            return NotFound();
        }

        await _countriesRepository.DeleteAsync(id);
        return NoContent();
    }

    private async Task<bool> CountryExists(int id)
    {
        return await _countriesRepository.Exists(id);
    }
}
