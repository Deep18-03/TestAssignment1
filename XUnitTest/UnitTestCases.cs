using System;
using Xunit;
using Moq;
using Newtonsoft.Json;
using TestingWebAPI.Repository.Interface;
using TestingWebAPI.Controllers;
using TestingWebAPI.Models;
using System.Collections.Generic;
using System.Web.Http.Results;
using System.IO;

namespace XUnitTest
{
    public class UnitTestCases
    {
        private readonly Mock<IPassengerRepository> mockDataRepo = new Mock<IPassengerRepository>();
        private readonly Passengers _passengerController;
        public UnitTestCases()
        {
            _passengerController = new Passengers(mockDataRepo.Object);
        }

        [Fact]
        public void TestGetPassengers()
        {
            //Arrange
            var resultType = mockDataRepo.Setup(x => x.GetPassengers()).Returns(GetPassengerList());
            //Act
            var response = _passengerController.GetPassengers();
            //Assert
            Assert.Equal(2, response.Count);
        }



        [Fact]
        public void TestCreatePassenger()
        {
            var pass = new Passenger() { PassengerNumber = new System.Guid(), FirstName = "Deep", Lastname = "Shah", PhoneNumber = "7744112255" };
            var response = mockDataRepo.Setup(x => x.CreatePassenger(pass)).Returns(AddPassenger());

            //Act
            var result = _passengerController.CreatePassenger(pass);
            Assert.NotNull(result);
        }

        [Fact]
        public void TestUpdatePassenger()
        {
            //Act
            var model = JsonConvert.DeserializeObject<Passenger>(File.ReadAllText("Data/UpdatePassenger.json"));

            //Arrange
            var result = mockDataRepo.Setup(x => x.Update(model)).Returns(model);
            var response = _passengerController.UpdatePassenger(model);

            //Assert
            Assert.Equal(model, response);
        }

        [Fact]
        public void TestDeletePassenger()
        {
            //Arrange
            var passenger = new Passenger();
            passenger.PassengerNumber = new System.Guid("62db39ab-f26c-5ff3-ba2b-4ff4056b07b6");

            var resultType = mockDataRepo.Setup(x => x.Delete(passenger.PassengerNumber.ToString())).Returns(true);
            //Act
            var response = _passengerController.DeletePassenger(passenger.PassengerNumber.ToString());
            //Assert
            Assert.True(response);
        }

        private static Passenger AddPassenger()
        {
            var passenger = new Passenger() { PassengerNumber = new System.Guid("95D66516-C3F6-4307-BFB9-9E8BE0D83040"), FirstName = "YATIN", Lastname = "SHARMA", PhoneNumber = "123456789" };
            return passenger;
        }


        private static List<Passenger> GetPassengerList()
        {
            List<Passenger> passengers = new List<Passenger>()
            {
                new Passenger(){PassengerNumber=new System.Guid("2CABC723-DB3B-3FF1-9353-6A1310AB03B*"),FirstName="Ramesh",Lastname="Shah",PhoneNumber="9293920200"},
                new Passenger(){PassengerNumber=new System.Guid("1f02f425-800a-4f8d-aa8b-c1450981ce1e"),FirstName="Suresh",Lastname="Jain",PhoneNumber="99493510200"},
                new Passenger(){PassengerNumber=new System.Guid("2CDBC447-CB3A-3EC1-8343-7A1220BC06B9"),FirstName="Riya",Lastname="Pandya",PhoneNumber="89765475656"}
            };
            return passengers;
        }


       
    }
}
