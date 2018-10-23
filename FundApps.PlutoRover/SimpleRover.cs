using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundApps.PlutoRover
{
    /// <summary>
    /// Implementation of machine capable providing position, orientation and executing commands.
    /// </summary>
    public class SimpleRover : ISimpleMachine
    {
        SimpleTelemetry currentPosition = new SimpleTelemetry(0, 0, SimpleOrientation.North);

        #region ISimpleMachine implementation

        public void ExecuteCommand(ISimpleCommand command)
        {
            if (command is MoveCommand)
            {
                string steps = command.Data;
                foreach (char c in steps.ToLower())
                {
                    switch (c)
                    {
                        case 'f':
                            Move(1);
                            break;
                        case 'b':
                            Move(-1);
                            break;
                        case 'l':
                            Rotate(-90);
                            break;
                        case 'r':
                            Rotate(90);
                            break;
                        default:
                            ReportObsticle();
                            break;
                    }
                }
            }
        }

        public SimpleTelemetry GetTelemetry()
        {
            return currentPosition;
        }

        #endregion

        #region private methods

        private void Rotate(int degrees)
        {
            int n = (int)currentPosition.Orientation + (degrees < 0 ? -1 : 1);

            // complete the circle
            if (n < (int)SimpleOrientation.North)
                n = (int)SimpleOrientation.West;
            if (n > (int)SimpleOrientation.West)
                n = (int)SimpleOrientation.North;

            currentPosition.Orientation = (SimpleOrientation)n;
        }

        private void Move(int steps)
        {
            switch (currentPosition.Orientation)
            {
                case SimpleOrientation.North:
                    currentPosition.X += steps;
                    break;
                case SimpleOrientation.East:
                    currentPosition.Y += steps;
                    break;
                case SimpleOrientation.South:
                    currentPosition.X -= steps;
                    break;
                case SimpleOrientation.West:
                    currentPosition.Y -= steps;
                    break;
            }
        }

        private void ReportObsticle() => throw new NotImplementedException();

        #endregion
    }
}