using System;

namespace Question_7_API.Data.Entities
{
    public class FlightType
    {
        public string Id { get; set; }
        public int FlightTypeID { get; set; }
        public string Type { get; set; }
        public FlightType()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
