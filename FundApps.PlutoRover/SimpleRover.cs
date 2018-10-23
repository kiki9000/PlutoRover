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
        public void ExecuteCommand(ISimpleCommand command) => throw new NotImplementedException();
        public SimpleTelemetry GetTelemetry() => throw new NotImplementedException();
    }
}