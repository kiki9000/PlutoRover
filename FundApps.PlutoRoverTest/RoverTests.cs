using FundApps.PlutoRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundApps.PlutoRoverTest
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void MoveCommandTest()
        {
            // Requirement 1:
            //  Given the command "FFRFF" would put the rover at 2,2 facing East.

            MoveCommand moveCommand = new MoveCommand() { Data = "FFRFF" };
            SimpleRover rover = new SimpleRover();

            rover.ExecuteCommand(moveCommand);
            SimpleTelemetry st = rover.GetTelemetry();
            Assert.AreEqual(2, st.X);
            Assert.AreEqual(2, st.Y);
            Assert.AreEqual(SimpleOrientation.East, st.Orientation);
        }
    }
}
