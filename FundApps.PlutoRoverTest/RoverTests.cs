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
        /// Test rotation (L/R) command execution
        /// </summary>
        [TestMethod]
        public void RotateCommandTest()
        {
            SimpleRover rover = new SimpleRover();
            SimpleTelemetry st;
            MoveCommand rotateLeft = new MoveCommand() { Data = "L" };
            MoveCommand rotateRight = new MoveCommand() { Data = "R" };

            //rotate 1 right, to the east
            rover.ExecuteCommand(rotateRight);
            st = rover.GetTelemetry();
            Assert.AreEqual(0, st.X);
            Assert.AreEqual(0, st.Y);
            Assert.AreEqual(SimpleOrientation.East, st.Orientation);

            //rotate 1 left, to the south
            rover.ExecuteCommand(rotateRight);
            st = rover.GetTelemetry();
            Assert.AreEqual(0, st.X);
            Assert.AreEqual(0, st.Y);
            Assert.AreEqual(SimpleOrientation.South, st.Orientation);

            //rotate 1 left, to the west
            rover.ExecuteCommand(rotateRight);
            st = rover.GetTelemetry();
            Assert.AreEqual(0, st.X);
            Assert.AreEqual(0, st.Y);
            Assert.AreEqual(SimpleOrientation.West, st.Orientation);

            //rotate 1 left, to the north
            rover.ExecuteCommand(rotateRight);
            st = rover.GetTelemetry();
            Assert.AreEqual(0, st.X);
            Assert.AreEqual(0, st.Y);
            Assert.AreEqual(SimpleOrientation.North, st.Orientation);

            //...and final 1 left to the east
            rover.ExecuteCommand(rotateRight);
            st = rover.GetTelemetry();
            Assert.AreEqual(0, st.X);
            Assert.AreEqual(0, st.Y);
            Assert.AreEqual(SimpleOrientation.East, st.Orientation);


            //now, let's go other way
            // atm we are at: 0,0,r (east)

            // after 1 right we should be looking north
            rover.ExecuteCommand(rotateLeft);
            st = rover.GetTelemetry();
            Assert.AreEqual(0, st.X);
            Assert.AreEqual(0, st.Y);
            Assert.AreEqual(SimpleOrientation.North, st.Orientation);

            //rotate 1 right, to the west
            rover.ExecuteCommand(rotateLeft);
            st = rover.GetTelemetry();
            Assert.AreEqual(0, st.X);
            Assert.AreEqual(0, st.Y);
            Assert.AreEqual(SimpleOrientation.West, st.Orientation);

            //rotate 1 right, to the south
            rover.ExecuteCommand(rotateLeft);
            st = rover.GetTelemetry();
            Assert.AreEqual(0, st.X);
            Assert.AreEqual(0, st.Y);
            Assert.AreEqual(SimpleOrientation.South, st.Orientation);

            //rotate 1 right, to the east
            rover.ExecuteCommand(rotateLeft);
            st = rover.GetTelemetry();
            Assert.AreEqual(0, st.X);
            Assert.AreEqual(0, st.Y);
            Assert.AreEqual(SimpleOrientation.East, st.Orientation);

            //rotate 1 right, to the north
            rover.ExecuteCommand(rotateLeft);
            st = rover.GetTelemetry();
            Assert.AreEqual(0, st.X);
            Assert.AreEqual(0, st.Y);
            Assert.AreEqual(SimpleOrientation.North, st.Orientation);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void SimpleTest()
        {
            // move:
            //  2 forward
            //  2 backward
            //  rotate right
            //  101 forward, step by step
            //  rotate left
            // and we should be at 0,0, north
            MoveCommand moveCommand;
            SimpleTelemetry st;
            SimpleRover rover = new SimpleRover();

            // move 2 forward
            moveCommand = new MoveCommand() { Data = "FF" };
            rover.ExecuteCommand(moveCommand);
            st = rover.GetTelemetry();
            Assert.AreEqual(2, st.X);
            Assert.AreEqual(0, st.Y);
            Assert.AreEqual(SimpleOrientation.North, st.Orientation);
            // move 2 backward
            moveCommand = new MoveCommand() { Data = "BB" };
            rover.ExecuteCommand(moveCommand);
            st = rover.GetTelemetry();
            Assert.AreEqual(0, st.X);
            Assert.AreEqual(0, st.Y);
            Assert.AreEqual(SimpleOrientation.North, st.Orientation);
            // rotate right
            moveCommand = new MoveCommand() { Data = "R" };
            rover.ExecuteCommand(moveCommand);
            st = rover.GetTelemetry();
            Assert.AreEqual(0, st.X);
            Assert.AreEqual(0, st.Y);
            Assert.AreEqual(SimpleOrientation.East, st.Orientation);
            // move 101 forward
            string steps = string.Empty;
            for (int i = 0; i != 101; i++)
                steps += "F";
            moveCommand = new MoveCommand() { Data = steps };
            rover.ExecuteCommand(moveCommand);
            st = rover.GetTelemetry();
            Assert.AreEqual(0, st.X);
            Assert.AreEqual(0, st.Y);
            Assert.AreEqual(SimpleOrientation.East, st.Orientation);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ExampleTest()
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
