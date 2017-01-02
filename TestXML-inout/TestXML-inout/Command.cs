using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestXML_inout
{
    public class Command
    {
        public string CommandID { get; set; }
        public string CommandString { get; set; }
        public CommandAction[] ActionSequence { get; set; }
    }
    public class CommandAction
    {
        public string ActionID { get; set; }
        public string ActionType { get; set; }    //default this value to Say
        public int Duration { get; set; }
        public int Delay { get; set; }
        public string KeyCodes { get; set; }
        public string Context { get; set; }
    }
}
