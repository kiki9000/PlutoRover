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
        public SimpleRover() : this(100, 100)
        {
        }

        public SimpleRover(int maxX, int maxY)
        {
            this.maxX = maxX;
            this.maxY = maxY;
        }

        private readonly int maxX = 100;
        private readonly int maxY = 100;

        SimpleTelemetry currentPosition = new SimpleTelemetry(0, 0, SimpleOrientation.North);

        public int MaxX => maxX;
        public int MaxY => maxY;

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
            int newX = currentPosition.X;
            int newY = currentPosition.Y;

            switch (currentPosition.Orientation)
            {
                case SimpleOrientation.North:
                    newX += steps;
                    break;
                case SimpleOrientation.East:
                    newY += steps;
                    break;
                case SimpleOrientation.South:
                    newX -= steps;
                    break;
                case SimpleOrientation.West:
                    newY -= steps;
                    break;
            }

            if ((newX > maxX) || (newX < 0))
                newX = Wrap(newX, maxX);
            if ((newY > maxY) || (newY < 0))
                    newY = Wrap(newY, maxY);

            currentPosition.X = newX;
            currentPosition.Y = newY;
        }

        int Wrap(int kX, int max)
        {
            int range_size = max + 1;

            if (kX < 0)
                kX += range_size * ((0 - kX) / range_size + 1);

            return kX % range_size;
        }

        private void ReportObsticle() => throw new NotImplementedException();

        #endregion
    }
}