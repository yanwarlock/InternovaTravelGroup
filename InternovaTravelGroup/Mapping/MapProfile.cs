using AutoMapper;
using Question_7_API.Data.Entities;
using Question_7_API.Models.Flight;

namespace Question_7_API.Mapping
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<FlightRequest, Flight>()
                .ReverseMap();
            CreateMap<FlightModel, Flight>()
                .ReverseMap();
        }
    }
}
