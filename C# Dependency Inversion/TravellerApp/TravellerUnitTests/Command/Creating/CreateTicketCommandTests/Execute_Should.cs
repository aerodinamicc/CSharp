using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Traveller.Core.Contracts;
using Traveller.Models;
using Traveller.Models.Abstractions;
using Traveller.Commands.Creating;

namespace TravellerUnitTests.Command.Creating.CreateTicketCommandTests
{

    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void InvokesFactory_WhenParametersAreCorrect()
        {
            // Arrange
            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDataCollections>();

            var journeyMock = new Mock<IJourney>();
            var journeyList = new List<IJourney>() { journeyMock.Object };
            var ticketsList = new List<ITicket>();
            databaseMock.Setup(m => m.Tickets).Returns(ticketsList);
            databaseMock.Setup(m => m.Journeys).Returns(journeyList);

            var parameters = new List<string>() { "0", "250" };

            var ticketCreateCommand = new CreateTicketCommand(databaseMock.Object, factoryMock.Object);

            //Act
            ticketCreateCommand.Execute(parameters);

            //Assert
            factoryMock.Verify(m => m.CreateTicket(journeyMock.Object, 250), Times.Once());

        }

        [TestMethod]
        public void AddsTicketToDatabase_WhenParametersAreCorrect()
        {
            // Arrange
            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDataCollections>();

            var journeyMock = new Mock<IJourney>();
            var journeyList = new List<IJourney>() { journeyMock.Object };
            var ticketsList = new List<ITicket>();
            databaseMock.Setup(m => m.Tickets).Returns(ticketsList);
            databaseMock.Setup(m => m.Journeys).Returns(journeyList);

            var parameters = new List<string>() { "0", "250" };

            var ticketCreateCommand = new CreateTicketCommand(databaseMock.Object, factoryMock.Object);

            //Act
            ticketCreateCommand.Execute(parameters);

            //Assert
            Assert.AreEqual(1, databaseMock.Object.Tickets.Count);

        }

        [TestMethod]
        public void ThrowsAnException_WhenTheresNoJourneyAvailable()
        {
            // Arrange
            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDataCollections>();

            var parameters = new List<string>() { "0", "250" };

            var ticketCreateCommand = new CreateTicketCommand(databaseMock.Object, factoryMock.Object);

            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() =>
            ticketCreateCommand.Execute(parameters));
        }

        [TestMethod]
        public void PrintsTheCreationMessage_WhenParametersAreCorrect()
        {
            // Arrange
            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDataCollections>();

            string expectedResult = "Ticket with ID 1 was created.";

            var journeyMock = new Mock<IJourney>();
            var journeyList = new List<IJourney>() { journeyMock.Object };
            var ticketMock = new Mock<ITicket>();
            var ticketsList = new List<ITicket>() { ticketMock.Object };
            databaseMock.Setup(m => m.Tickets).Returns(ticketsList);
            databaseMock.Setup(m => m.Journeys).Returns(journeyList);

            var parameters = new List<string>() { "0", "100" };

            var ticketCreateCommand = new CreateTicketCommand(databaseMock.Object, factoryMock.Object);

            //Act
            var result = ticketCreateCommand.Execute(parameters);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
