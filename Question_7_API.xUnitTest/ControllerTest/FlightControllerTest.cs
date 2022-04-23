using Microsoft.AspNetCore.Mvc;
using Question_7_API.Controllers;
using Question_7_API.Models.Flight;
using Question_7_API.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Question_7_API.xUnitTest.ControllerTest
{
    public class FlightControllerTest
    {
        [Fact]
        public async Task TestPostFlight()
        {
            var db = ServicesFactory.CreateDb();
            var mapper = ServicesFactory.CreateMapper();
            var serviceFlight = new FlightService(db, mapper);
            var controller = new FlightController(serviceFlight);

            var request = new FlightRequest
            {
                FlightID = 1,
                FlightNumber = "FlightNumber",
                FlightTypeID = 1,
                MealTypeID = 1,
                PassengerName = "PassengerName"

            };

            var response = await controller.Post(request);
            Assert.IsType<CreatedAtActionResult>(response);
        }

        [Fact]
        public async Task TestGetFlight()
        {
            var db = ServicesFactory.CreateDb();
            var mapper = ServicesFactory.CreateMapper();
            var serviceFlight = new FlightService(db, mapper);
            var controller = new FlightController(serviceFlight);

            var request = new FlightRequest
            {
                FlightID = 1,
                FlightNumber = "FlightNumber",
                FlightTypeID = 1,
                MealTypeID = 1,
                PassengerName = "PassengerName"

            };
            var response = await serviceFlight.CreateAsync(request);

            var getResponse = await controller.Get("id_not_valido");
            Assert.IsType<NotFoundObjectResult>(getResponse);
            getResponse = await controller.Get(response.Data.Id);
            Assert.IsType<OkObjectResult>(getResponse);

        }

        [Fact]
        public async Task TestDeleteFlight()
        {
            var db = ServicesFactory.CreateDb();
            var mapper = ServicesFactory.CreateMapper();
            var serviceFlight = new FlightService(db, mapper);
            var controller = new FlightController(serviceFlight);

            var request = new FlightRequest
            {
                FlightID = 1,
                FlightNumber = "FlightNumber",
                FlightTypeID = 1,
                MealTypeID = 1,
                PassengerName = "PassengerName"

            };
            var responseCreate = await serviceFlight.CreateAsync(request);

            var responseGet = await controller.Get(responseCreate.Data.Id);
            var responceDelete = await controller.Delete(responseCreate.Data.Id);

            Assert.IsType<OkObjectResult>(responseGet);
            Assert.IsType<OkObjectResult>(responceDelete);
        }
    }
}
