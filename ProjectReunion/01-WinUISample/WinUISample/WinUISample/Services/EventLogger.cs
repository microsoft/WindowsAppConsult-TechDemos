using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUISample.Services
{
    public class EventLogger
    {
        public void WriteLog(string text)
        {
            string source = "DemoTestApplication";
            string log = "DemoEventLog";
            EventLog demoLog = new EventLog(log);
            demoLog.Source = source;
            demoLog.WriteEntry(text, EventLogEntryType.Information);
        }
    }
}
