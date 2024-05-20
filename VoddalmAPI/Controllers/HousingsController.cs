﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using VoddalmAPI.Data.Interfaces;
using VoddalmAPI.Data.Models;


namespace VoddalmAPI.Controllers
{
    [Route("api/[controller]")] // Author Felix o Kim J
    [ApiController]
    public class HousingsController : ControllerBase
    {
        private readonly IHousing housingRepo;
        private readonly IBroker brokerRepo;

        public HousingsController(IHousing housingRepository, IBroker BrokerRepo)
        {
            housingRepo = housingRepository;
            brokerRepo = BrokerRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Housing>>> GetHousings()
        {
            var housings = await housingRepo.GetHousingsAsync();
            return Ok(housings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Housing>> GetHousing(int id)
        {
            var housing = await housingRepo.GetHousingByIdAsync(id);
            if (housing == null)
            {
                return NotFound();
            }
            return Ok(housing);
        }

        [HttpPost] 
        public async Task<ActionResult<Housing>> PostHousing([FromBody] HousingDto housingDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var housing = new Housing
                {
                    Address = housingDto.Address,
                    InitialPrice = housingDto.InitialPrice,
                    LivingArea = housingDto.LivingArea,
                    AdditionalArea = housingDto.AdditionalArea,
                    PlotArea = housingDto.PlotArea,
                    Description = housingDto.Description,
                    NumberOfRooms = housingDto.NumberOfRooms,
                    MonthlyFee = housingDto.MonthlyFee,
                    AnnualOperatingCost = housingDto.AnnualOperatingCost,
                    YearBuilt = housingDto.YearBuilt,
                    CategoryId = housingDto.CategoryId,
                    MunicipalityId = housingDto.MunicipalityId,
                    IsActive = housingDto.IsActive
            };

                housing.Images = housingDto.Images;

                Console.WriteLine($"Images received: {string.Join(", ", housingDto.Images)}");

                if (!string.IsNullOrEmpty(housingDto.BrokerId))
                {
                    var broker = await brokerRepo.GetBrokerByIdAsync(housingDto.BrokerId);
                    if (broker == null)
                    {
                        return BadRequest("Invalid broker Id");
                    }
                    housing.Broker = broker;
                }

                await housingRepo.AddHousingAsync(housing);
                return CreatedAtAction(nameof(GetHousing), new { id = housing.Id }, housing);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut("{id}")] 
        public async Task<IActionResult> PutHousing(int id, [FromBody] HousingDto housingDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var housing = await housingRepo.GetHousingByIdAsync(id);
                if (housing == null)
                {
                    return NotFound($"Housing with Id {id} not found");
                }

                housing.Address = housingDto.Address;
                housing.InitialPrice = housingDto.InitialPrice;
                housing.LivingArea = housingDto.LivingArea;
                housing.AdditionalArea = housingDto.AdditionalArea;
                housing.PlotArea = housingDto.PlotArea;
                housing.Description = housingDto.Description;
                housing.NumberOfRooms = housingDto.NumberOfRooms;
                housing.MonthlyFee = housingDto.MonthlyFee;
                housing.AnnualOperatingCost = housingDto.AnnualOperatingCost;
                housing.YearBuilt = housingDto.YearBuilt;
                housing.CategoryId = housingDto.CategoryId;
                housing.BrokerId = housingDto.BrokerId; 
                housing.MunicipalityId = housingDto.MunicipalityId;
                housing.Images = housingDto.Images;
                housing.IsActive = housingDto.IsActive;

                await housingRepo.UpdateHousingAsync(housing);
                return NoContent();
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Internal server error");
            }
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHousing(int id)
        {
            var existingHousing = await housingRepo.GetHousingByIdAsync(id);
            if (existingHousing == null)
            {
                return NotFound();
            }

            await housingRepo.DeleteHousingAsync(existingHousing);
            return NoContent();
        }
    }

    public class HousingDto 
    {
        [Required]
        public string Address { get; set; }
        [Required]
        [Range(0.0001, double.MaxValue, ErrorMessage = "Value must be greater than 0")]
        public double InitialPrice { get; set; }
        [Required]
        [Range(0.0001, double.MaxValue, ErrorMessage = "Value must be greater than 0")]
        public double LivingArea { get; set; }
        public double AdditionalArea { get; set; }
        public double PlotArea { get; set; }
        public string Description { get; set; }
        public int NumberOfRooms { get; set; }
        public double MonthlyFee { get; set; }
        public double AnnualOperatingCost { get; set; }
        public int YearBuilt { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        public string? BrokerId { get; set; }
        public int MunicipalityId { get; set; }
        public List<string> Images { get; set; }
    }
}
