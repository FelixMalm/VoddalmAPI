﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VoddalmAPI.Data.Interfaces;
using VoddalmAPI.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace VoddalmAPI.Controllers //Author Felix o Kim
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

        [HttpPost] 
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
               
                Console.WriteLine($"Error adding broker: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutBroker(string id, [FromBody] BrokerDto brokerDto)
        {
            try
            {
                
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                
                var broker = await brokerRepo.GetBrokerByIdAsync(id);
                if (broker == null)
                {
                    
                    return NotFound($"Broker with Id {id} not found");
                }

                
                broker.FirstName = brokerDto.FirstName;
                broker.LastName = brokerDto.LastName;
                broker.Email = brokerDto.Email;
                broker.PhoneNumber = brokerDto.PhoneNumber;
                broker.ImageUrl = brokerDto.ImageUrl;
                broker.NormalizedEmail = brokerDto.Email.ToUpper(); 
                broker.NormalizedUserName = brokerDto.Email.ToUpper(); 
                broker.UserName = brokerDto.UserName;

               
                await brokerRepo.UpdateBrokerAsync(broker);

                
                return NoContent();
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Error updating broker: {ex.Message}");

               
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


    public class BrokerDto 
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
