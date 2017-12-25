using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traveller.Core.Contracts;
using Moq;
using Traveller.Commands.Creating;

namespace TravellerUnitTests.Command.Creating.CreateTicketCommandTests
{
    /// <summary>
    /// Summary description for Constructor_Should
    /// </summary>
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreatesTicket_WhenInputIsCorrect()
        {
            //Arrange
            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDataCollections>();

            //Act
            var ticketCreateCommand = new CreateTicketCommand(databaseMock.Object, factoryMock.Object);

            //Act and assert
            Assert.IsNotNull(ticketCreateCommand);

        }

        [TestMethod]
        public void ThrowsException_WhenFactoryIsNull()
        {
            // Arrange
            var databaseMock = new Mock<IDataCollections>();

            //Act and assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new CreateTicketCommand(databaseMock.Object, null));
        }

        [TestMethod]
        public void ThrowsException_WhenDatabaseIsNull()
        {
            // Arrange
            var factoryMock = new Mock<ITravellerFactory>();
            

            //Act and assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new CreateTicketCommand(null, factoryMock.Object));
        }

    }
}
