using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;
using Alarm_Library;

namespace Alarm_Library
{
    public class Console_Controller
    {
        /// <summary>
        /// List of alarms.
        /// </summary>
        public List<Alarm> alarm_list = new List<Alarm>();

        public bool Quit = false;

        public bool AddEditMenu = true;

        public GUI_Controller c;

        public Console_Controller(GUI_Controller control) { c = control; }

        public void Write2Console()
        {
            Console.WriteLine("These are the alarms:");
            if (alarm_list.Count == 0) ReadFromFile();
            else foreach (Alarm alarm in alarm_list) Console.WriteLine(c.MakeAlarmText(alarm));
            if (AddEditMenu)
            {
                Console.WriteLine("");
                Console.WriteLine("Choose an Action (1-3)");
                Console.WriteLine("1: Add Alarm");
                Console.WriteLine("2: Edit Alarm");
                Console.WriteLine("3: Quit Application");

                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Choose an Action (1-3)");
                Console.WriteLine("1: Stop Alarm");
                Console.WriteLine("2: Snooze Alarm");
                Console.WriteLine("3: Quit Application");

                Console.WriteLine("");
            }
        }

        void ReadFromFile()
        {
            c.ReadFile(2);
            alarm_list = c.alarmList;
            foreach (Alarm alarm in alarm_list) { Console.WriteLine(c.MakeAlarmText(alarm)); }
        }

        public void ActionChoice()
        {
            int action_num = Convert.ToInt32(Console.ReadLine());
            if (AddEditMenu)
            {
                switch (action_num)
                {
                    // This is to ADD an Alarm.
                    case 1:
                        AddHelper();
                        break;
                    // This is to EDIT an Alarm.
                    case 2:
                        EditHelper();
                        break;
                    // This is to Quit the application.
                    case 3:
                        QuitHelper();
                        break;
                    default:
                        Console.WriteLine("");
                        break;
                }
            }
            else
            {
                switch (action_num)
                {
                    // This is to stop the active alarm.
                    case 1:
                        StopHelper();
                        break;
                    // This is to snooze the active alarm.
                    case 2:
                        SnoozeHelper();
                        break;
                    // This is to Quit the application.
                    case 3:
                        QuitHelper();
                        break;
                    default:
                        Console.WriteLine("");
                        break;
                }
            }
        }

        void AddHelper()
        {
            Console.WriteLine("");
            Console.WriteLine("******************************");
            if (alarm_list.Count > 4)
            {
                Console.WriteLine("Cannot have more than 5 alarms.");
                Thread.Sleep(1500);
            }
            else
            {
                AddEditMessage();
                Alarm a = MakeAlarmFromInput();
                if (a != null)
                {
                    alarm_list.Add(a);
                    c.alarmList = alarm_list;
                }
                else
                {
                    Console.WriteLine("Incorrect input, please read the settings!");
                    Thread.Sleep(1500);
                    AddHelper();
                }
            }
            Console.WriteLine("******************************");
            Console.WriteLine("");
            Console.Clear();
        }

        void EditHelper()
        {
            Console.WriteLine("");
            Console.WriteLine("******************************");
            Console.WriteLine("Choose which alarm to EDIT (1-" + alarm_list.Count + ").");
            int index = Convert.ToInt32(Console.ReadLine());
            if (index > alarm_list.Count || index < 1) Console.WriteLine("Number chosen not in range.");
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Chosen Alarm: " + c.MakeAlarmText(alarm_list[index - 1]));
                Console.WriteLine("Choose new Settings.");
                Console.WriteLine("");

                AddEditMessage();
                Alarm a = MakeAlarmFromInput();
                if (a != null)
                {
                    alarm_list[index - 1] = a;
                    c.alarmList = alarm_list;
                }
                else
                {
                    Console.WriteLine("Incorrect input, please read the settings!");
                    Thread.Sleep(1500);
                    EditHelper();
                }
            }
            Console.WriteLine("******************************");
            Console.WriteLine("");
            Console.Clear();
        }

        void StopHelper()
        {
            Console.WriteLine("");
            Console.WriteLine("******************************");
            Console.WriteLine("Choose which alarm to STOP (1-" + alarm_list.Count + "): ");
            int index2 = Convert.ToInt32(Console.ReadLine());
            if (index2 > alarm_list.Count || index2 < 1) Console.WriteLine("Number chosen not in range.");
            else
            {
                if (alarm_list[index2 - 1].Status == Alarm.State.ON || alarm_list[index2 - 1].Status == Alarm.State.GOING_OFF)
                {
                    Console.WriteLine("");
                    alarm_list[index2 - 1].Status = Alarm.State.OFF;
                    c.alarmList = alarm_list;
                    Console.WriteLine("Chosen Alarm: " + c.MakeAlarmText(alarm_list[index2 - 1]));
                    Console.WriteLine("Turned OFF");
                    Console.WriteLine("");
                    AddEditMenu = true;
                    for (int i = 0; i < c.alarmList.Count; i++)
                    {
                        if (c.alarmList[i].Status == Alarm.State.GOING_OFF) AddEditMenu = false;

                    }
                }
                else Console.WriteLine("Alarm cannot be turned off");
            }
            Console.WriteLine("******************************");
            Console.WriteLine("");
            Console.Clear();
        }

        void SnoozeHelper()
        {
            Console.WriteLine("");
            Console.WriteLine("******************************");
            Console.WriteLine("Choose which alarm to SNOOZE (1-" + alarm_list.Count + ").");
            int index3 = Convert.ToInt32(Console.ReadLine());
            if (index3 > alarm_list.Count || index3 < 1) Console.WriteLine("Number chosen not in range.");
            else
            {
                if (alarm_list[index3 - 1].Status != Alarm.State.GOING_OFF) Console.WriteLine("Alarm cannot be snoozed");
                else
                {
                    while (true)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Snooze for how many minutes: ");
                        double snooze_time = Convert.ToDouble(Console.ReadLine());
                        if (snooze_time > 0 && snooze_time <= 30)
                        {
                            DateTime current = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                            DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                            Console.WriteLine("Chosen Alarm: " + c.MakeAlarmText(alarm_list[index3 - 1]));
                            Console.WriteLine("Snoozed for " + snooze_time + " minutes.");
                            alarm_list[index3 - 1].Status = Alarm.State.SNOOZE;
                            alarm_list[index3 - 1].Time = current.AddSeconds(60 * snooze_time);
                            c.alarmList = alarm_list;
                            Console.WriteLine("");
                            AddEditMenu = true;
                            for (int i = 0; i < c.alarmList.Count; i++)
                            {
                                if (c.alarmList[i].Status == Alarm.State.GOING_OFF) AddEditMenu = false;

                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please try again! The snooze can be between 1 and 30 minutes.");
                        }
                    }
                }
            }
            Console.WriteLine("******************************");
            Console.WriteLine("");
            Console.Clear();
        }

        void QuitHelper()
        {
            c.alarmList = alarm_list;
            c.Write2TXT();
            Quit = true;
            Environment.Exit(0);
        }

        /// <summary>
        /// This method checks the alarms to see if they have gone off.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CheckAlarms(object sender, ElapsedEventArgs e)
        {
            DateTime current = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            if (alarm_list != null)
            {
                foreach (Alarm a in alarm_list)
                {
                    if (a.Status == Alarm.State.ON && TimeSpan.Compare(a.Time.TimeOfDay, current.TimeOfDay) == 0)
                    {
                        SignalAlarm(a);
                    }
                    if (a.Status == Alarm.State.SNOOZE && TimeSpan.Compare(a.Time.TimeOfDay, current.TimeOfDay) == 0)
                    {
                        SignalAlarm(a);
                    }
                }
            }
        }

        /// <summary>
        /// This is what sets off the Alarm.
        /// </summary>
        /// <param name="a">This is the alarm that is going off</param>
        public void SignalAlarm(Alarm a)
        {
            int index = alarm_list.IndexOf(a);
            a.Status = Alarm.State.GOING_OFF;
            string sound = "";

            if (a.Sound == Alarm.AlarmSound.CHICKEN) sound = "CHICKEN SOUNDS";
            else if (a.Sound == Alarm.AlarmSound.NOISE) sound = "WHITE NOISE";
            else if (a.Sound == Alarm.AlarmSound.BARKING) sound = "DOG BARKING";
            else if (a.Sound == Alarm.AlarmSound.SUBWAY) sound = "BUSY SUBWAY";
            else if (a.Sound == Alarm.AlarmSound.SIRENS) sound = "BLARING SIRENS";
            else if (a.Sound == Alarm.AlarmSound.NONE) sound = "NO SOUND";
            AddEditMenu = false;
            Console.Clear();

            Console.WriteLine("******************************");
            Console.WriteLine("******************************");
            Console.WriteLine("Alarm " + Convert.ToString(index + 1) + " went off with " + sound);
            Console.WriteLine("******************************");
            Console.WriteLine("******************************");
            Console.WriteLine("");
            Console.WriteLine("");

            Write2Console();
        }

        void AddEditMessage()
        {
            Console.WriteLine("");
            Console.WriteLine("Alarm Settings (Listed below):");
            Console.WriteLine("hh:mm:ss AM/PM for the time.");
            Console.WriteLine("State of the alarm.");
            Console.WriteLine("     ON");
            Console.WriteLine("     OFF");
            Console.WriteLine("Sound of the alarm.");
            Console.WriteLine("     CHICKEN");
            Console.WriteLine("     NOISE");
            Console.WriteLine("     BARKING");
            Console.WriteLine("     SUBWAY");
            Console.WriteLine("     SIRENS");
            Console.WriteLine("Separate everything with commas.");
            Console.WriteLine("Example: 10:30:30 PM,ON,BARKING");
            Console.WriteLine("");
            Console.WriteLine("Settings: ");
            Console.WriteLine("");
        }

        Alarm MakeAlarmFromInput()
        {
            DateTime t = default;
            string[] alarm_data = Console.ReadLine().Split(',');
            if (alarm_data.Length == 3)
            {
                try
                {
                    t = Convert.ToDateTime(alarm_data[0]);
                }
                catch (Exception e)
                {
                    return null;
                }

                Alarm.State state = default;
                if (alarm_data[1] == "ON") state = Alarm.State.ON;
                else if (alarm_data[1] == "OFF") state = Alarm.State.OFF;

                Alarm.AlarmSound sound = Alarm.AlarmSound.NONE;
                if (alarm_data[2] == "CHICKEN") sound = Alarm.AlarmSound.CHICKEN;
                else if (alarm_data[2] == "NOISE") sound = Alarm.AlarmSound.NOISE;
                else if (alarm_data[2] == "BARKING") sound = Alarm.AlarmSound.BARKING;
                else if (alarm_data[2] == "SUBWAY") sound = Alarm.AlarmSound.SUBWAY;
                else if (alarm_data[2] == "SIRENS") sound = Alarm.AlarmSound.SIRENS;

                return new Alarm(t, state, sound);
            }
            else
            {
                return null;
            }

        }
    }
}
