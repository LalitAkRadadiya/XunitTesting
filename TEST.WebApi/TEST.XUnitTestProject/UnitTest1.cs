using Moq;
using System;
using System.Collections.Generic;
using TEST.BAL;
using TEST.BAL.Interface;
using TEST.Model;
using TEST.WebApi.Controllers;
using Xunit;

namespace TEST.XUnitTestProject
{
    public class UnitTest1
    {
        private readonly Mock<IPassengerManger> mockData= new Mock<IPassengerManger>();
        private readonly PassengerController _passengerController;
        public UnitTest1()
        {
            _passengerController = new PassengerController(mockData.Object);
        }
        [Fact]
        public void AddPassenger()
        {

            var newPassenger = new Passenger();
            newPassenger.Id = 100;
            newPassenger.FirstName = "Lalit";
            newPassenger.LastName = "Radadiya";
            newPassenger.ContactNo = 1234;

            //var addedPassenger = _passengerController.Post(newPassenger);
            var res = mockData.Setup(x => x.CreatePassenger(newPassenger)).Returns("Successfully Added");
            // Act
           
            var result = _passengerController.Post(newPassenger);

            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void AddPassengerTestFail()
        {
            //Arrange
            var passenger = new Passenger();
            var res = mockData.Setup(x => x.CreatePassenger(passenger)).Returns("model is null");

            //Act
            var result = _passengerController.Post(passenger);

            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void GetAllPPassengersTestPass()
        {
            //Arrange
            var result = mockData.Setup(x => x.GetAllPassenger()).Returns(GetPassenger());

            //Act
            var actualResult = _passengerController.Get();

            //Assert
            Assert.Equal(2, actualResult.Count);
        }

        //Static List of Passengers
        private static List<Passenger> GetPassenger()
        {
            List<Passenger> users = new List<Passenger>()
            {
                new Passenger() {Id=1, FirstName="Prince", LastName="Makwana", ContactNo=96246},
                new Passenger() {Id=2, FirstName="Kushal", LastName="Master", ContactNo=999998},

            };
            return users;
        }

        [Fact]
        public void GetPassengerByIdTestPass()
        {
            //Arrange
            var passenger = new Passenger();
            passenger.Id = 1;
            passenger.FirstName = "Prince";
            passenger.LastName = "Makwana";
            passenger.ContactNo = 96246;
            var res = mockData.Setup(x => x.GetPassenger(passenger.Id)).Returns(passenger);

            //Act
            var result = _passengerController.Get(passenger.Id);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetPassengerByIdTestFail()
        {
            //Arrange
            var passenger = new Passenger();
            var res = mockData.Setup(x => x.GetPassenger(3)).Returns(passenger);

            //Act
            var result = _passengerController.Get(passenger.Id);

            //Assert
            Assert.Null(result);
        }

        //Update any existing Passenger
        [Fact]
        public void UpdatePassengerTestPass()
        {
            //Arrange
            var passenger = new Passenger();
            passenger.Id = 1;
            passenger.FirstName = "iPrince";
            passenger.LastName = "Makwana";
            passenger.ContactNo = 9426;
            var res = mockData.Setup(x => x.UpdatePassenger(passenger)).Returns("Passenger Updated Successfully!");

            //Act
            var result = _passengerController.Put(passenger);

            //Assert
            Assert.Equal("Passenger Updated Successfully!", result);
        }

        [Fact]
        public void UpdatePassengerTestFail()
        {
            //Arrange
            var passenger = new Passenger();
            var res = mockData.Setup(x => x.UpdatePassenger(passenger)).Returns("model is null");

            //Act
            var result = _passengerController.Put(passenger);

            //Assert
            Assert.NotEqual("Successfully updated", result);
        }

        //Delete any particular existing Passenger.
        [Fact]
        public void DeletePassengerTestPass()
        {
            //Arrange
            var passenger = new Passenger();
            passenger.Id = 2;
            var res = mockData.Setup(x => x.DeletePassenger(passenger.Id)).Returns("Delete Successfully");

            //Act
            var result = _passengerController.Delete(passenger.Id);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void DeletePassengerTestFail()
        {
            //Arrange
            var passenger = new Passenger();
            passenger.Id = 4;
            var res = mockData.Setup(x => x.DeletePassenger(passenger.Id)).Returns("Delete Successfully");

            //Act
            var result = _passengerController.Delete(passenger.Id);

            //Assert
            Assert.NotNull(result);
        }


    }
}
