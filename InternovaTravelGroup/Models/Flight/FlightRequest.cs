﻿namespace Question_7_API.Models.Flight
{
    public class FlightRequest
    {
        public int FlightID { get; set; }
        public int FlightTypeID { get; set; }
        public int? MealTypeID { get; set; }
        public string PassengerName { get; set; }
        public string FlightNumber { get; set; }
    }
}
