using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Question_7_API.Data;
using Question_7_API.Data.Entities;
using Question_7_API.Models;
using Question_7_API.Models.Flight;
using Question_7_API.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question_7_API.Services
{
    public class FlightService : IFlightService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public FlightService(ApplicationDbContext dbContext, IMapper mapper )
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ResponseAPI<FlightModel>> CreateAsync(FlightRequest request)
        {
            if (request is null)
                return new ResponseAPI<FlightModel>()
                {
                    Succeeded = false,
                    Message = "Create fail",
                };
            var newFlight = _mapper.Map<Flight>(request);
            await _dbContext.ListFlight.AddRangeAsync(newFlight);
            await _dbContext.SaveChangesAsync();
            var result = _mapper.Map<FlightModel>(newFlight);
            return new ResponseAPI<FlightModel>()
            {
                Succeeded = true,
                Message = "Create Success",
                Data = result
                
            };
        }

        public async Task<ResponseAPI> DeleteAsync(string id)
        {
            var flight = _dbContext.ListFlight.FirstOrDefault(c => c.Id == id);
            if (flight is null)
                return new ResponseAPI()
                {
                    Succeeded = false,
                    Message = "Delete fail flight not found",
                };
            _dbContext.ListFlight.Remove(flight);
            await _dbContext.SaveChangesAsync();
            return new ResponseAPI()
            {
                Succeeded = true,
                Message = "Delete Success",
            };
        }

        public async Task<ResponseAPI<IList<FlightModel>>> GetAllAsync()
        {
            var result = await _dbContext.ListFlight.ProjectTo<FlightModel>(_mapper.ConfigurationProvider)
                 .ToListAsync();
            return new ResponseAPI<IList<FlightModel>>()
            {
                Succeeded = true,
                Message = "GetAll Success",
                Data = result
            };
        }

        public async Task<ResponseAPI<FlightModel>> GetAsync(string id)
        {
            var result = await _dbContext.ListFlight.ProjectTo<FlightModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (result is null)
                return new ResponseAPI<FlightModel>()
                {
                    Succeeded = false,
                    Message = "Get fail flight not found",
                };
            return new ResponseAPI<FlightModel>()
            {
                Succeeded = true,
                Message = "Get Success",
                Data = result
            };
        }
    }
}
