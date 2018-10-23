using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundApps.PlutoRover
{
    /// <summary>
    /// Minimum definition of the machine that can execute commands and provide sensor data (position and orientation).
    /// </summary>
    public interface ISimpleMachine
    {
        void ExecuteCommand(ISimpleCommand command);
        SimpleTelemetry GetTelemetry();
    }
}