using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traveller.Core.Factories;
using Moq;
using Traveller.Core.Providers;

namespace TravellerUnitTests.Core.Providers.CommandParserTests
{
    /// <summary>
    /// Summary description for Constructor_Should
    /// </summary>
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnsACommandParser_WhenCalled()
        {
            //Arrange
            var commandFactoryMock = new Mock<ICommandFactory>();

            //Act
            var commandParserMock = new CommandParser(commandFactoryMock.Object);

            //Assert
            Assert.IsNotNull(commandFactoryMock);
        }

        [TestMethod]
        public void ThrowsNullException_WhenInputIsIncorrect()
        {
            //Arrange, Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new CommandParser(null));
        }
    }
}
