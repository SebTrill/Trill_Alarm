using System.Timers;

namespace Trill_Alarm
{
    internal static class Program
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
            Controller c = new Controller(a.AddAlarmItem, a.GetSpecific, a.GetSelected, a.EditButtonOnOff, a.SnoozeButtonOnOff, a.StopButtonOnOff,
                a.ChangeAlarmWentOffText, a.ChangeAlarm_List, a.SnoozeTimeValue, e.SetTime, e.CheckedOnOff, e.CheckedChanged, e.ChickenChecked,
                e.NoiseChecked, e.DogChecked, e.SubwayChecked, e.SirenChecked, e.ChickenOnOff, e.NoiseOnOff, e.DogOnOff, e.SubwayOnOff, e.SirenOnOff,
                e.GetTimeSelectValue, e.HideView);

            // This sets all of the delegates, in the Alarm501 view, to their counterparts in the Controller class.
            a.SetConstructor(c.ReadFile, c.MakeAlarmText, c.Write2TXT, c.CheckAlarms, c.StartTimer, c.SelectedEventHelper, c.StopEventHelper,
                c.SnoozeEventHelper, c.EditEventHelper, c.MakeNewAddEdit);

            // This sets all of the delegates, in the AddEdit view, to their counterparts in the Controller class.
            e.SetConstructor(c.ChickenChangedHelper, c.NoiseChangedHelper, c.DogChangedHelper, c.SubwayChangedHelper, c.SirenChangedHelper,
                c.SetEventHelper);

            Application.Run(a);
        }
    }

    // Alarm501 Delegates
    public delegate void CheckTheBox_DEL(bool b);
    public delegate void SetTheTime_DEL(DateTime t);
    public delegate void ReadFile_DEL();
    public delegate string MakeAlarmText_DEL(Alarm a);
    public delegate void Write2TXT_DEL();
    public delegate Alarm MakeAlarmFromSelected_DEL();
    public delegate void StartTimer_DEL(Alarm501 a);
    public delegate void SelectedEventHelper_DEL();
    public delegate void StopEventHelper_DEL();
    public delegate void SnoozeEventHelper_DEL();
    public delegate void EditEventHelper_DEL();
    public delegate void MakeNewAddEdit_DEL();

    // AddEdit Delegates
    public delegate void SetEventHelper_DEL();
    public delegate void ChickenChangedHelper_DEL();
    public delegate void NoiseChangedHelper_DEL();
    public delegate void DogChangedHelper_DEL();
    public delegate void SubwayChangedHelper_DEL();
    public delegate void SirenChangedHelper_DEL();

    // Controller Delegates
    public delegate void Add2AlarmViewList(string item);
    public delegate string GetSpecificItem(int index);
    public delegate string GetSelectedItem();
    public delegate void CheckAlarms(object sender, ElapsedEventArgs e);
    public delegate int GetPlacing_DEL();
    public delegate void EditButtonOnOff_DEL(bool b);
    public delegate void SnoozeButtonOnOff_DEL(bool b);
    public delegate void StopButtonOnOff_DEL(bool b);
    public delegate void ChangeAlarmWentOffText_DEL(string sound);
    public delegate void ChangeAlarm_List_DEL(int index, Alarm a);
    public delegate double SnoozeTimeValue_DEL();

    public delegate void SetTime(DateTime t);
    public delegate void HideView_DEL();
    public delegate void CheckOnOff_DEL(bool b);
    public delegate DateTime GetTimeSelectValue_DEL();
    public delegate bool ChickenChecked_DEL();
    public delegate bool NoiseChecked_DEL();
    public delegate bool DogChecked_DEL();
    public delegate bool SubwayChecked_DEL();
    public delegate bool SirenChecked_DEL();
    public delegate bool CheckedChanged_DEL();
    public delegate void ChickenOnOff_DEL(bool b);
    public delegate void NoiseOnOff_DEL(bool b);
    public delegate void DogOnOff_DEL(bool b);
    public delegate void SubwayOnOff_DEL(bool b);
    public delegate void SirenOnOff_DEL(bool b);
}