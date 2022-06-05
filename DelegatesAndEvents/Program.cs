using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public delegate void WorkPerformerdHandler(int hours, Worktype worktype);
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public enum Worktype
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
