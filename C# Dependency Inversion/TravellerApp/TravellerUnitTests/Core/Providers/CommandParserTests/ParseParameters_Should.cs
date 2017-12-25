using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Traveller.Core.Factories;
using Traveller.Core.Providers;

namespace TravellerUnitTests.Core.Providers.CommandParserTests
{
    /// <summary>
    /// Summary description for ParseParameters_Should
    /// </summary>
    [TestClass]
    public class ParseParameters_Should
    {
        [TestMethod]
        public void ReturnsListOfParameters_WhenInputIsCorrect()
        {
            string correctInput = "createairplane 250 1 true";
            List < string > subset = new List<String>() { "250", "1", "true" };
            var factoryMock = new Mock<ICommandFactory>();
            var commandParserMock = new CommandParser(factoryMock.Object);

            //Act
            var result = commandParserMock.ParseParameters(correctInput);

            //Assert
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(subset[i], result[i]);
            }

            //CollectionAssert 
        }
    }
}
