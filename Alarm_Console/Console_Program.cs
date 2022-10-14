using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alarm_Library;

namespace Alarm_Console 
{
    public class Console_Program
    {
        public static void Main(string[] args)
        {
            GUI_Controller c = new();
            Console_Controller temp_c = new(c);

            System.Timers.Timer myTimer = new System.Timers.Timer(1000);
            myTimer.Elapsed += temp_c.CheckAlarms;
            myTimer.AutoReset = true;
            myTimer.Start();

            while (temp_c.Quit == false)
            {
                temp_c.Write2Console();
                temp_c.ActionChoice();
            }
        }
    }
}
