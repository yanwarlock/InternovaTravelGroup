using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Question_7_API.Models.Flight;
using Question_7_API.Services;
using Question_7_API.Services.Interfaces;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Question_7_API.Controllers
{
    /// <summary>
    /// FlightController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flightService"></param>
        public FlightController(FlightService flightService)
        {
            _flightService = flightService;
        }
        /// <summary>
        /// Create a new flight.
        /// </summary>
        /// <param name="request">Flight to be created.</param>
        /// <returns>Returns the flight created</returns>
        [HttpPost("CreateFlight")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(FlightRequest request)
        {
            try
            {
                if (request is null)
                    return BadRequest();
                var result = await _flightService.CreateAsync(request);
                return CreatedAtAction(nameof(Get), new { id = result.Data.Id }, result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { StatusCodes.Status409Conflict, ex.Message });
            }
        }
        /// <summary>
        /// Get a given flight its identifier
        /// </summary>
        /// <param name="request">Flight indentifier</param>
        /// <returns>Returns a flight</returns>
        [HttpGet("GetFlight")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get(string request)
        {
            var result = await _flightService.GetAsync(request);
            if (result.Data is null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
        /// <summary>
        /// Get all flights
        /// </summary>
        /// <returns>Returns a collection of flights</returns>
        [HttpGet("GetAllFlights")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get()
        {
            var result = await _flightService.GetAllAsync();
            if (result.Data is null)
                return NotFound(result);
            return Ok(result);
        }
        /// <summary>
        /// Delete a flight
        /// </summary>
        /// <param name="request">Flight identifier</param>
        /// <returns>Returns true or false</returns>
        [HttpDelete("DeleteFlight")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(string request)
        {
            var result = await _flightService.DeleteAsync(request);
            if (!result.Succeeded)
                return NotFound(result);
            return Ok(result);
        }
    }
}
