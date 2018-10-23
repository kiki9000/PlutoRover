using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundApps.PlutoRover
{
    /// <summary>
    /// Structured information about current position and orientation.
    /// </summary>
    public struct SimpleTelemetry
    {
        internal SimpleTelemetry(int x, int y, SimpleOrientation o)
        {
            this.X = x;
            this.Y = y;
            this.Orientation = o;
        }

        public int X;
        public int Y;
        public SimpleOrientation Orientation;

        public override string ToString()
        {
            return $"{X},{Y},{Orientation}";
        }
    }
}