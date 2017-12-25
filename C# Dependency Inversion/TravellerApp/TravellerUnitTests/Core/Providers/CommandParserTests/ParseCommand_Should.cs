using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Traveller.Core.Factories;
using Traveller.Core.Providers;
using Traveller.Commands.Creating;
using Traveller.Core.Contracts;
using Traveller.Commands.Contracts;
using Traveller.Core;

namespace TravellerUnitTests.Core.Providers.CommandParserTests
{
    /// <summary>
    /// Summary description for ParseCommand_Should
    /// </summary>
    [TestClass]
    public class ParseCommand_Should
    {

        [TestMethod]
        public void InvokesCreateCommand_WhenParametersAreCorrect()
        {
            //Arrange
            string correctInput = "createairplane 250 1 true";
            var factoryMock = new Mock<ICommandFactory>();
            var commandParserMock = new CommandParser(factoryMock.Object);
            
            //Act
            commandParserMock.ParseCommand(correctInput);

            //Arrange
            factoryMock.Verify(m => m.CreateCommand(correctInput.Split(' ')[0]), Times.Once());
        }

        [TestMethod]
        public void ThrowsException_WhenCommandIsNotSupported()
        {
            //Arrange
            string incorrectInput = "create 250 1 true";
            var factoryMock = new Mock<ICommandFactory>();
            var commandParser = new CommandParser(factoryMock.Object);

            //Act & assert
            Assert.ThrowsException<ArgumentException>(() =>
            commandParser.ParseCommand(incorrectInput));
        }
    }
}
