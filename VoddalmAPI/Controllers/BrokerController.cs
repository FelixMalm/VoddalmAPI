﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VoddalmAPI.Data.Interfaces;
using VoddalmAPI.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace VoddalmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrokerController : ControllerBase
    {
        private readonly IBroker brokerRepo;
        private readonly IAgency AgencyRepo;

        public BrokerController(IBroker brokerRepository, IAgency agencyRepo)
        {
            brokerRepo = brokerRepository;
            AgencyRepo = agencyRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Broker>>> GetBrokers()
        {
            var brokers = await brokerRepo.GetBrokersAsync();
            return Ok(brokers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Broker>> GetBroker(string id)
        {
            var broker = await brokerRepo.GetBrokerByIdAsync(id);
            if (broker == null)
            {
                return NotFound();
            }
            return Ok(broker);
        }

        [HttpPost] //Author Felix
        public async Task<ActionResult<Broker>> PostBroker([FromBody] BrokerDto brokerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var broker = new Broker
                {
                    FirstName = brokerDto.FirstName,
                    LastName = brokerDto.LastName,
                    Email = brokerDto.Email,
                    PhoneNumber = brokerDto.PhoneNumber,
                    ImageUrl = brokerDto.ImageUrl,
                    UserName = brokerDto.Email,
                    

                };

                if (brokerDto.AgencyId.HasValue)
                {
                    var agency = await AgencyRepo.GetAgencyByIdAsync(brokerDto.AgencyId.Value);
                    if (agency == null)
                    {
                        return BadRequest("Invalid agency Id");
                    }
                    broker.Agency = agency;
                }

                await brokerRepo.AddBrokerAsync(broker);
                return CreatedAtAction(nameof(GetBroker), new { id = broker.Id }, broker);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error adding broker: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutBroker(string id, [FromBody] BrokerDto brokerDto)
        {
            try
            {
                // Check if the model state is valid
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Attempt to find the broker by ID
                var broker = await brokerRepo.GetBrokerByIdAsync(id);
                if (broker == null)
                {
                    // Return 404 Not Found if broker is not found
                    return NotFound($"Broker with Id {id} not found");
                }

                // Update broker properties
                broker.FirstName = brokerDto.FirstName;
                broker.LastName = brokerDto.LastName;
                broker.Email = brokerDto.Email;
                broker.PhoneNumber = brokerDto.PhoneNumber;
                broker.ImageUrl = brokerDto.ImageUrl;
                broker.NormalizedEmail = brokerDto.Email.ToUpper(); // Normalize email
                broker.NormalizedUserName = brokerDto.Email.ToUpper(); // Normalize username
                broker.UserName = brokerDto.UserName;

                // Update the broker entity in the repository
                await brokerRepo.UpdateBrokerAsync(broker);

                // Return 204 No Content if update is successful
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error updating broker: {ex.Message}");

                // Return 500 Internal Server Error for any other exceptions
                return StatusCode(500, "Internal server error");
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBroker(string id)
        {
            var existingBroker = await brokerRepo.GetBrokerByIdAsync(id);
            if (existingBroker == null)
            {
                return NotFound();
            }

            await brokerRepo.DeleteBrokerAsync(existingBroker);
            return NoContent();
        }
    }


    public class BrokerDto //Author Felix
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public string UserName { get; set; }
        
        public int? AgencyId { get; set; }
    }
}
