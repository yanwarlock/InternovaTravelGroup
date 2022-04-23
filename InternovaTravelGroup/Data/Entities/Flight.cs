using System;

namespace Question_7_API.Data.Entities
{
    public class Flight
    {
        public string Id { get; set; }
        public int FlightID { get; set; }
        public int FlightTypeID { get; set; }
        public int? MealTypeID { get; set; }
        public string PassengerName { get; set; }
        public string FlightNumber { get; set; }

        public Flight()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
