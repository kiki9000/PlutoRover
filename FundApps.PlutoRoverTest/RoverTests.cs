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
        /// <summary>
        /// Test move command execution
        /// </summary>
        [TestMethod]
        public void MoveCommandTest()
        {
            SimpleRover rover = new SimpleRover();
            SimpleTelemetry st;
            MoveCommand moveForward = new MoveCommand() { Data = "F" };
            MoveCommand moveBackward= new MoveCommand() { Data = "B" };

            //step forward
            rover.ExecuteCommand(moveForward);
            
            st = rover.GetTelemetry();
            Assert.AreEqual(1, st.X);
            Assert.AreEqual(0, st.Y);
            Assert.AreEqual(SimpleOrientation.North, st.Orientation);

            //step backward
            rover.ExecuteCommand(moveBackward);
            st = rover.GetTelemetry();
            Assert.AreEqual(0, st.X);
            Assert.AreEqual(0, st.Y);
            Assert.AreEqual(SimpleOrientation.North, st.Orientation);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Requirement1Test()
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
