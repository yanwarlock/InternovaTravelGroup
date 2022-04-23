using Question_7_API.Models;
using Question_7_API.Models.Flight;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Question_7_API.Services.Interfaces
{
    public interface IFlightService
    {
        Task<ResponseAPI<FlightModel>> CreateAsync(FlightRequest request);
        Task<ResponseAPI> DeleteAsync(string id);
        Task<ResponseAPI<IList<FlightModel>>> GetAllAsync();
        Task<ResponseAPI<FlightModel>> GetAsync(string id);
    }
}
