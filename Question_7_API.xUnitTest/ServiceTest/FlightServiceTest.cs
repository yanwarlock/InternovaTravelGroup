using Question_7_API.Models.Flight;
using Question_7_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Question_7_API.xUnitTest.ServiceTest
{
    public class FlightServiceTest
    {
        [Fact]
        public async Task CreateAsync()
        {
            var db = ServicesFactory.CreateDb();
            var mapper = ServicesFactory.CreateMapper();
            var serviceFlight = new FlightService(db, mapper);
            var request = new FlightRequest
            {
                FlightID = 1,
                FlightNumber = "FlightNumber",
                FlightTypeID = 1,
                MealTypeID = 1,
                PassengerName = "PassengerName"

            };

            var create = await serviceFlight.CreateAsync(request);

            Assert.True(create.Succeeded == true);
            Assert.True(create.Data.Id != null);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var db = ServicesFactory.CreateDb();
            var mapper = ServicesFactory.CreateMapper();
            var serviceFlight = new FlightService(db, mapper);
            var request = new FlightRequest
            {
                FlightID = 1,
                FlightNumber = "FlightNumber",
                FlightTypeID = 1,
                MealTypeID = 1,
                PassengerName = "PassengerName"

            };

            var insert = await serviceFlight.CreateAsync(request);

            var delete = await serviceFlight.DeleteAsync(insert.Data.Id);
            Assert.True(delete.Succeeded == true);
            Assert.True(!db.ListFlight.Select(c => c.Id == insert.Data.Id).Any());
        }

        [Fact]
        public async Task GetAllAsync()
        {
            var db = ServicesFactory.CreateDb();
            var mapper = ServicesFactory.CreateMapper();
            var serviceFlight = new FlightService(db, mapper);

            for (int i = 0; i < 10; i++)
            {
                var request = new FlightRequest
                {
                    FlightID = i,
                    FlightNumber = "FlightNumber" + i,
                    FlightTypeID = i,
                    MealTypeID = i,
                    PassengerName = "PassengerName" + i
                };
                await serviceFlight.CreateAsync(request);
            }

            var getAll = await serviceFlight.GetAllAsync();
            Assert.True(getAll.Succeeded == true);
            Assert.True(db.ListFlight.Count() == getAll.Data.Count);
        }
    }
}
