using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OlympicGames;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Providers;
using OlympicGames.Core;

namespace OlympicGamesUnitTest
{
    [TestClass]
    public class ShouldThrowArgumentNullException
    {
        [TestMethod]
        public void ShouldThrowArgumentNullException_WhenArgumentsAreIncorrect()
        {
            /*
             * IReader reader, IWriter writer,
            ICommandParser parser, ICommandProcessor processor
            */
            //Arrange
            Mock<IReader> reader = new Mock<IReader>();
            Mock<IWriter> writer = new Mock<IWriter>();
            Mock<ICommandParser> parser = new Mock<ICommandParser>();
            Mock<ICommandProcessor> processor = new Mock<ICommandProcessor>();

            //Act
            IEngine engine = new Engine(reader.Object, writer.Object, parser.Object, processor.Object);
            engine.Run();

            //Assert
            Assert.IsNull(engine);
        }
    }
}
