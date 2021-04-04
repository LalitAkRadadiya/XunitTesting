using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST.BAL;
using TEST.BAL.Interface;
using TEST.Model;
using TEST.WebApi.Controllers;
using Xunit;

namespace TEST.Xnuit
{
    public class PassengerTest
    {
        private readonly Mock<IPassengerManger> mockDataRepository = new Mock<IPassengerManger>();
        private readonly PassengerController _passengerController;
        public PassengerTest()
        {
            _passengerController = new PassengerController(mockDataRepository.Object);
        }
        [Fact]
        public void Test_AddUser()
        {

            var newPassenger = new Passenger();
            newPassenger.FirstName = "Lalit";
            newPassenger.LastName = "Radadiya";
            newPassenger.ContactNo = 1234;

            var addedPassenger = _passengerController.Post(newPassenger);

            // Act
            var response = mockDataRepository.Setup(
                x => x.CreatePassenger(newPassenger)
                )
                .Returns(addedPassenger);
            var result = _passengerController.Post(newPassenger);

            // Assert
            Assert.NotNull(result);
        }
    }
}
