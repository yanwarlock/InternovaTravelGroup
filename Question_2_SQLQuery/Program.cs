using System;
using System.Collections.Generic;
using System.Linq;

namespace Question_2_SQLQuery
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var tableFlightTypeID = new List<FlightType>()
            {
                new FlightType(){  FlightTypeID =1,  Type = "One Way", },
                new FlightType() {  FlightTypeID =2, Type = "Round Trip",}
            };
            var tableMealType = new List<MealType>()
            {
                new MealType() { MealTypeID = 1, Type ="Chicken",},
                new MealType() { MealTypeID = 2, Type ="Beef",},
                new MealType() { MealTypeID = 3, Type ="Vegetarian",},
            };
            var tableFlight = new List<Flight>()
            {
                new Flight(){FlightID = 1,FlightTypeID =1,MealTypeID = 1,PassengerName = "John",FlightNumber = "AA123"},
                new Flight(){FlightID = 2,FlightTypeID =2,MealTypeID = 1,PassengerName = "Wendy",FlightNumber = "UA471"},
                new Flight(){FlightID = 3,FlightTypeID =2,MealTypeID = null,PassengerName = "Sarah",FlightNumber = "DL111"},
                new Flight(){FlightID = 4,FlightTypeID =2,MealTypeID = 3,PassengerName = "Paul",FlightNumber = "AC99"},
            };

            var result = (from flight in tableFlight
                     join flightTypeID in tableFlightTypeID on
                     flight.FlightTypeID equals flightTypeID.FlightTypeID
                     join mealType in tableMealType on
                     flight.MealTypeID equals mealType.MealTypeID
                     select new
                     {
                         FlightID = flight.FlightID,
                         PassengerName = flight.PassengerName,
                         FlightNumber = flight.FlightNumber,
                         FlightType = flightTypeID.Type,
                         MealType = mealType.Type,
                     });

            foreach (var item in result)
            {
                Console.WriteLine($"FlightID :{ item.FlightID} - PassengerName :{item.PassengerName} - " +
                    $"FlightNumber :{item.FlightNumber} - FlightType :{item.FlightType} - MealType :{item.MealType}");
            }


        }
    }
    public class FlightType 
    {
        public int FlightTypeID { get; set; }
        public string Type { get; set; }
    }
    public class MealType
    {
        public int MealTypeID { get;  set; }
        public string Type { get; set; }
    }
    public class Flight
    {
        public int FlightID { get; set; }
        public int FlightTypeID { get; set; }
        public int? MealTypeID { get; set; }
        public string PassengerName { get; set; }
        public string FlightNumber { get; set; }
    }
}

