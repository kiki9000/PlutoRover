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
        public event EventHandler ObstacleDetected;

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
                            return;
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
                    newY += steps;
                    break;
                case SimpleOrientation.East:
                    newX += steps;
                    break;
                case SimpleOrientation.South:
                    newY -= steps;
                    break;
                case SimpleOrientation.West:
                    newX -= steps;
                    break;
            }

            if ((newX > maxX) || (newX < 0))
                newX = Wrap(newX, maxX);
            if ((newY > maxY) || (newY < 0))
                    newY = Wrap(newY, maxY);

            currentPosition.X = newX;
            currentPosition.Y = newY;
        }

        int Wrap(in int val, in int max)
        {
            int rangeSize = max + 1;
            int x = val;

            if (x < 0)
                x += rangeSize * ((0 - x) / rangeSize + 1);

            return x % rangeSize;
        }

        private void ReportObsticle() {
            if (ObstacleDetected != null)
                ObstacleDetected(this, null);
        }

        #endregion
    }
}