using System.Timers;
using Alarm_Library;

namespace Alarm_GUI
{
    internal static class GUI_Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();

            // Creating instances of my views.
            Alarm501 a = new();
            AddEdit e = new();

            // This creates the Controller with all the delegates from Alarm501 and AddEdit views.
            GUI_Controller c = new GUI_Controller(a.AddAlarmItem, a.GetSpecific, a.GetSelected, a.EditButtonOnOff, a.SnoozeButtonOnOff, a.StopButtonOnOff,
                a.ChangeAlarmWentOffText, a.ChangeAlarm_List, a.SnoozeTimeValue, a.TooManyAlarmMessage, e.SetTime, e.CheckedOnOff, e.CheckedChanged, e.GetTimeSelectValue, 
                e.HideView, e.Edit, e.Add, e.GetSound);

            // This sets all of the delegates, in the Alarm501 view, to their counterparts in the Controller class.
            a.SetConstructor(c.ReadFile, c.MakeAlarmText, c.Write2TXT, c.CheckAlarms, c.SelectedEventHelper, c.StopEventHelper,
                c.SnoozeEventHelper, c.EditEventHelper, c.MakeNewAddEdit);

            // This sets all of the delegates, in the AddEdit view, to their counterparts in the Controller class.
            e.SetConstructor(c.SetEventHelper, c.MakeSound2String);

            Application.Run(a);
        }
    }
}