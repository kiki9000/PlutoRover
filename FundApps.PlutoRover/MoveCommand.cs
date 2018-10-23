using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundApps.PlutoRover
{
    public class MoveCommand : ISimpleCommand
    {
        public string Data { get; set; }
    }
}