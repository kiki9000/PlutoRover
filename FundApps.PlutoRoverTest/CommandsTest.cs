using FundApps.PlutoRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FundApps.PlutoRoverTest
{
    [TestClass]
    public class CommandsTest
    {
        [TestMethod]
        public void MoveCommandTest()
        {
            MoveCommand moveCommand = new MoveCommand() { Data = "FFRFF" };

            Assert.AreEqual("FFRFF", moveCommand.Data);
        }
    }
}
