using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Alarm_Library
{
    public class Library_Program
    {
        public static void Main(string[] args) { }
    }

    // Alarm501 Delegates
    public delegate void CheckTheBox_DEL(bool b);
    public delegate void SetTheTime_DEL(DateTime t);
    public delegate void ReadFile_DEL(int i);
    public delegate string MakeAlarmText_DEL(Alarm a);
    public delegate void Write2TXT_DEL();
    public delegate Alarm MakeAlarmFromSelected_DEL();
    public delegate void SelectedEventHelper_DEL();
    public delegate void StopEventHelper_DEL();
    public delegate void SnoozeEventHelper_DEL();
    public delegate void EditEventHelper_DEL();
    public delegate void MakeNewAddEdit_DEL();

    // AddEdit Delegates
    public delegate void SetEventHelper_DEL();
    public delegate void Edit_DEL(Alarm a);
    public delegate void Add_DEL();
    public delegate string MakeSound2String_DEL(Alarm.AlarmSound sound);

    // Controller Delegates
    public delegate void Add2AlarmViewList_DEL(string item);
    public delegate string GetSpecificItem_DEL(int index);
    public delegate string GetSelectedItem_DEL();
    public delegate void CheckAlarms_DEL(object sender, ElapsedEventArgs e);
    public delegate int GetPlacing_DEL();
    public delegate void EditButtonOnOff_DEL(bool b);
    public delegate void SnoozeButtonOnOff_DEL(bool b);
    public delegate void StopButtonOnOff_DEL(bool b);
    public delegate void ChangeAlarmWentOffText_DEL(string sound);
    public delegate void ChangeAlarm_List_DEL(int index, Alarm a);
    public delegate double SnoozeTimeValue_DEL();
    public delegate void TooManyAlarmMessage_DEL();

    public delegate void SetTime_DEL(DateTime t);
    public delegate void HideView_DEL();
    public delegate void CheckOnOff_DEL(bool b);
    public delegate DateTime GetTimeSelectValue_DEL();

    public delegate string GetSound_DEL();
    public delegate bool CheckedChanged_DEL();
}
