using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundApps.PlutoRover
{
    /// <summary>
    /// Definition of command that can be sent to the rover.
    /// </summary>
    public interface ISimpleCommand
    {
        /// <summary>
        /// Command payload.
        /// </summary>
        string Data { get; set; }
    }
}