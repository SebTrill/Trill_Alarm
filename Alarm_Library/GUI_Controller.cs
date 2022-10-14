using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Alarm_Library
{
    /// <summary>
    /// This is the enum for the states that the alarms can have.
    /// </summary>
    public enum Event
    {
        START,
        ADD,
        EDIT,
        SNOOZE,
        STOP,
        CLOSE,
        CLICK,
        SELECT,
        CANCEL,
        SET
    }

    public class GUI_Controller
    {
        //// Delegates from Alarm501 ////

        /// <summary>
        /// This adds an alarm to the list of alarms.
        /// </summary>
        Add2AlarmViewList_DEL add_alarm;

        /// <summary>
        /// This retrieves a specific item from the alarm_list using an index.
        /// </summary>
        GetSpecificItem_DEL get_specific;

        /// <summary>
        /// This retrieves the selected item in the alarm_list.
        /// </summary>
        GetSelectedItem_DEL get_selected;

        /// <summary>
        /// This enables or disables the edit button.
        /// </summary>
        EditButtonOnOff_DEL edit_onoff;

        /// <summary>
        /// This enables or disables the snooze button.
        /// </summary>
        SnoozeButtonOnOff_DEL snooze_onoff;

        /// <summary>
        /// This enables or disables the stop button.
        /// </summary>
        StopButtonOnOff_DEL stop_onoff;

        /// <summary>
        /// This changes the alarmgoneoff textbox text.
        /// </summary>
        ChangeAlarmWentOffText_DEL change_text;

        /// <summary>
        /// This changes a specific alarm in the list of alarms using a given alarm and index.
        /// </summary>
        ChangeAlarm_List_DEL change_list;

        /// <summary>
        /// This retrieves the value of the snooze numeric up-down.
        /// </summary>
        SnoozeTimeValue_DEL snooze_value;

        /// <summary>
        /// This is the delegate to print out a message for too many alarms being added.
        /// </summary>
        TooManyAlarmMessage_DEL alarm_many_message;

        ////////////////////////////////

        //// Delegates from AddEdit ////

        /// <summary>
        /// This edits the alarm.
        /// </summary>
        Edit_DEL edit_alarm;

        /// <summary>
        /// This add an alarm.
        /// </summary>
        Add_DEL edit_new_alarm;

        /// <summary>
        /// This sets the time.
        /// </summary>
        SetTime_DEL set;

        /// <summary>
        /// This hides the AddEdit view.
        /// </summary>
        HideView_DEL hide;

        /// <summary>
        /// This enables or diables the check_on checkbox.
        /// </summary>
        CheckOnOff_DEL check_onoff;

        /// <summary>
        /// This retrieves the time.
        /// </summary>
        GetTimeSelectValue_DEL get_time;

        /// <summary>
        /// This retrieves the AlarmSound of the chosen alarm.
        /// </summary>
        GetSound_DEL get_sound;

        /// <summary>
        /// The retrieves a bool value of whether or not the check_on checkbox is checked.
        /// </summary>
        CheckedChanged_DEL checked_check;

        ////////////////////////////////

        /// <summary>
        /// List of alarms.
        /// </summary>
        public List<Alarm> alarmList = new List<Alarm>();

        /// <summary>
        /// this is the index of the item being edited.
        /// </summary>
        public int Placing;

        /// <summary>
        /// This tells whether or not we are editing.
        /// </summary>
        public bool Editing;

        /// <summary>
        /// This is the Controller Constructor.
        /// </summary>
        /// <param name="a2a">This is the Add2AlarmViewList Delegate.</param>
        /// <param name="getspec">This is the GetSpecificItem Delegate.</param>
        /// <param name="getselec">This is the GetSelectedItem Delegate.</param>
        /// <param name="edit_button">This is the EditButtonOnOff_DEL Delegate.</param>
        /// <param name="snooze_button">This is the SnoozeButtonOnOff_DEL Delegate.</param>
        /// <param name="stop_button">This is the StopButtonOnOff_DEL Delegate.</param>
        /// <param name="changeT">This is the ChangeAlarmWentOffText_DEL Delegate.</param>
        /// <param name="changeL">This is the ChangeAlarm_List_DEL Delegate.</param>
        /// <param name="value">This is the SnoozeTimeValue_DEL Delegate.</param>
        /// <param name="st">This is the SetTime Delegate.</param>
        /// <param name="chk">This is the CheckOnOff_DEL Delegate.</param>
        /// <param name="check_c">This is the CheckedChanged_DEL Delegate.</param>
        /// <param name="time_value">This is the GetTimeSelectValue_DEL Delegate.</param>
        /// <param name="h">This is the HideView_DEL Delegate.</param>
        public GUI_Controller(Add2AlarmViewList_DEL a2a, GetSpecificItem_DEL getspec, GetSelectedItem_DEL getselec, EditButtonOnOff_DEL edit_button,
            SnoozeButtonOnOff_DEL snooze_button, StopButtonOnOff_DEL stop_button, ChangeAlarmWentOffText_DEL changeT, ChangeAlarm_List_DEL changeL,
            SnoozeTimeValue_DEL value, TooManyAlarmMessage_DEL many_alarm, SetTime_DEL st, CheckOnOff_DEL chk, CheckedChanged_DEL check_c, 
            GetTimeSelectValue_DEL time_value, HideView_DEL h, Edit_DEL edit_a, Add_DEL edit_new_a, GetSound_DEL get_s)
        {
            // These are from the Alarm501 view.
            add_alarm = a2a;
            get_specific = getspec;
            get_selected = getselec;
            edit_onoff = edit_button;
            change_text = changeT;
            change_list = changeL;
            snooze_onoff = snooze_button;
            stop_onoff = stop_button;
            snooze_value = value;
            alarm_many_message = many_alarm;

            // These are from the AddEdit view.
            set = st;
            hide = h;
            check_onoff = chk;
            get_time = time_value;
            checked_check = check_c;
            edit_alarm = edit_a;
            edit_new_alarm = edit_new_a;
            get_sound = get_s;
        }

        public GUI_Controller() { }

        /// <summary>
        /// This method checks the alarms to see if they have gone off.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CheckAlarms(object sender, ElapsedEventArgs e)
        {
            DateTime current = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            if (alarmList != null)
            {
                foreach (Alarm a in alarmList)
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
        /// Reads from the file.
        /// </summary>
        public void ReadFile(int i)
        {
            if (File.Exists("AlarmData.txt"))
            {
                StreamReader sr = new StreamReader("AlarmData.txt");
                while (!sr.EndOfStream)
                {
                    string[] alarmData = sr.ReadLine().Split(',');
                    Alarm.State status = 0;
                    Alarm.AlarmSound sound = 0;

                    if (alarmData.Length == 0) break;

                    if (alarmData[1] == "1") status = Alarm.State.ON;
                    else if (alarmData[1] == "0") status = Alarm.State.OFF;
                    else if (alarmData[1] == "2") status = Alarm.State.STOPPED;
                    else if (alarmData[1] == "3") status = Alarm.State.GOING_OFF;
                    else if (alarmData[1] == "4") status = Alarm.State.SNOOZE;

                    if (alarmData[2] == "0") sound = Alarm.AlarmSound.NONE;
                    else if (alarmData[2] == "1") sound = Alarm.AlarmSound.CHICKEN;
                    else if (alarmData[2] == "2") sound = Alarm.AlarmSound.NOISE;
                    else if (alarmData[2] == "3") sound = Alarm.AlarmSound.BARKING;
                    else if (alarmData[2] == "4") sound = Alarm.AlarmSound.SUBWAY;
                    else if (alarmData[2] == "5") sound = Alarm.AlarmSound.SIRENS;

                    Alarm a = new(Convert.ToDateTime(alarmData[0]), status, sound);
                    
                    if(i == 1) AddItem2List(a);
                    else if(i == 2) alarmList.Add(a);
                }
                sr.Close();
            }
        }

        /// <summary>
        /// This makes the text for the item added to the list.
        /// </summary>
        /// <param name="a">Alarm to add to the list.</param>
        public string MakeAlarmText(Alarm a)
        {
            string[] text = a.Time.ToString().Split(' ');
            if (a.Status == Alarm.State.ON) return text[1] + " " + text[2] + "  ON:  " + a.Sound;
            else if (a.Status == Alarm.State.OFF) return text[1] + " " + text[2] + "  OFF:  " + a.Sound;
            else if (a.Status == Alarm.State.GOING_OFF) return text[1] + " " + text[2] + "  GOING OFF:  " + a.Sound;
            else if (a.Status == Alarm.State.STOPPED) return text[1] + " " + text[2] + "  STOPPED:  " + a.Sound;
            else return text[1] + " " + text[2] + "  SNOOZED:  " + a.Sound;
        }

        /// <summary>
        /// This makes the alarm sound into a string.
        /// </summary>
        /// <param name="sound">This is the sound to convert.</param>
        /// <returns>Returns the string of the sound.</returns>
        public string MakeSound2String(Alarm.AlarmSound sound)
        {
            if (sound == Alarm.AlarmSound.CHICKEN) return "CHICKEN";
            else if (sound == Alarm.AlarmSound.NOISE) return "NOISE";
            else if (sound == Alarm.AlarmSound.BARKING) return "BARKING";
            else if (sound == Alarm.AlarmSound.SUBWAY) return "SUBWAY";
            else if (sound == Alarm.AlarmSound.SIRENS) return "SIRENS";
            else return "NONE";
        }


        /// <summary>
        /// This is what sets off the Alarm.
        /// </summary>
        /// <param name="a">This is the alarm that is going off</param>
        public void SignalAlarm(Alarm a)
        {
            int index = alarmList.IndexOf(a);
            a.Status = Alarm.State.GOING_OFF;
            edit_onoff(false);
            string sound = "";

            if (a.Sound == Alarm.AlarmSound.CHICKEN) sound = "CHICKEN SOUNDS";
            else if (a.Sound == Alarm.AlarmSound.NOISE) sound = "WHITE NOISE";
            else if (a.Sound == Alarm.AlarmSound.BARKING) sound = "DOG BARKING";
            else if (a.Sound == Alarm.AlarmSound.SUBWAY) sound = "BUSY SUBWAY";
            else if (a.Sound == Alarm.AlarmSound.SIRENS) sound = "BLARING SIRENS";
            else if (a.Sound == Alarm.AlarmSound.NONE) sound = "NO SOUND";

            change_text("ALARM WENT OFF WITH " + sound);
            change_list(index, a);
        }

        /// <summary>
        /// This adds an item to the list.
        /// </summary>
        /// <param name="a">Alarm to add to the list.</param>
        public void AddItem2List(Alarm a)
        {
            if (alarmList.Count < 6)
            {
                alarmList.Add(a);
                add_alarm(MakeAlarmText(a));
            }
            else alarm_many_message();
        }

        /// <summary>
        /// This adds an edited alarm to the list.
        /// </summary>
        /// <param name="a">Alarm to add to the list.</param>
        public void AddItem2SpecificSpot(Alarm a)
        {
            if (alarmList.Count < 6)
            {
                alarmList[Placing] = a;
                change_list(Placing, a);
            }
            else alarm_many_message();
        }

        /// <summary>
        /// This writes to the text file.
        /// </summary>
        public void Write2TXT()
        {
            using (StreamWriter sw = new StreamWriter("AlarmData.txt"))
            {
                sw.Flush();
                int status = 0;
                int sound = 0;
                foreach (Alarm a in alarmList)
                {
                    if (a.Status == Alarm.State.ON) status = 1;
                    else if (a.Status == Alarm.State.OFF) status = 0;
                    else if (a.Status == Alarm.State.STOPPED) status = 2;
                    else if (a.Status == Alarm.State.GOING_OFF) status = 3;
                    else if (a.Status == Alarm.State.SNOOZE) status = 4;

                    if (a.Sound == Alarm.AlarmSound.NONE) sound = 0;
                    else if (a.Sound == Alarm.AlarmSound.CHICKEN) sound = 1;
                    else if (a.Sound == Alarm.AlarmSound.NOISE) sound = 2;
                    else if (a.Sound == Alarm.AlarmSound.BARKING) sound = 3;
                    else if (a.Sound == Alarm.AlarmSound.SUBWAY) sound = 4;
                    else if (a.Sound == Alarm.AlarmSound.SIRENS) sound = 5;

                    sw.WriteLine(a.Time.ToString() + "," + status.ToString() + "," + sound.ToString());
                }
            }
        }

        /// <summary>
        /// This makes an alarm from the selected list item.
        /// </summary>
        /// <returns>Returns an alarm from selected item.</returns>
        public Alarm MakeAlarmFromSelected()
        {
            int i = 0;
            while (get_specific(i) != get_selected()) i++;
            return alarmList[i];
        }

        /// <summary>
        /// This sets the time with the given DateTime.
        /// </summary>
        /// <param name="t">This is the DateTime to set the timer to.</param>
        public void SetTheTime(DateTime t) { set(t); }

        /// <summary>
        /// This checks the check_on checkbox in the AddEdit view.
        /// </summary>
        /// <param name="b"></param>
        public void CheckTheBox(bool b)
        {
            if (b == true) check_onoff(true);
            else check_onoff(false);
        }

        /// <summary>
        /// This is a helper for the SelectedChanged event in the Alarm501 view.
        /// </summary>
        public void SelectedEventHelper()
        {
            if (get_selected() != null)
            {
                Alarm a = MakeAlarmFromSelected();
                if (a.Status == Alarm.State.GOING_OFF)
                {
                    stop_onoff(true);
                    snooze_onoff(true);
                }
                if (a.Status == Alarm.State.OFF || a.Status == Alarm.State.ON || a.Status == Alarm.State.STOPPED)
                {
                    edit_onoff(true);

                    if (a.Status == Alarm.State.STOPPED)
                    {
                        stop_onoff(false);
                        snooze_onoff(false);
                    }
                }
                if (a.Status == Alarm.State.SNOOZE || a.Status == Alarm.State.GOING_OFF)
                {
                    edit_onoff(false);

                    if (a.Status == Alarm.State.SNOOZE)
                    {
                        stop_onoff(false);
                        snooze_onoff(false);
                    }
                }
            }
        }

        /// <summary>
        /// This is a helper for the StopButtonClicked event in the Alarm501 view.
        /// </summary>
        public void StopEventHelper()
        {
            if (get_selected() != null)
            {
                Alarm a = MakeAlarmFromSelected();
                int index = alarmList.IndexOf(a);
                change_text(" ");
                a.Status = Alarm.State.STOPPED;
                change_list(index, a);
            }
        }

        /// <summary>
        /// This is a helper for the SnoozeButtonClicked event in the Alarm501 view.
        /// </summary>
        public void SnoozeEventHelper()
        {
            DateTime current = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                        DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            if (get_selected() != null)
            {
                Alarm a = MakeAlarmFromSelected();
                int index = alarmList.IndexOf(a);
                change_text(" ");
                stop_onoff(false);
                snooze_onoff(false);
                a.Time = current.AddSeconds(snooze_value() * 60);
                a.Status = Alarm.State.SNOOZE;
                change_list(index, a);
            }
        }

        /// <summary>
        /// This is a helper for the EditButtonClicked event in the Alarm501 view.
        /// </summary>
        public void EditEventHelper()
        {
            if (get_selected() != null)
            {
                Editing = true;

                Alarm alarm = MakeAlarmFromSelected();

                int i = 0;
                while (get_specific(i) != get_selected()) i++;
                Placing = i;

                edit_alarm(alarm);
            }
        }

        /// <summary>
        /// This is a method that retrieves the chosen sound for the alarm from the AddEdit view.
        /// </summary>
        /// <returns>Returns an AlarmSound enum value of the sound type.</returns>
        public Alarm.AlarmSound GetSound()
        {
            if (get_sound() == "CHICKEN") return Alarm.AlarmSound.CHICKEN;
            else if (get_sound() == "NOISE") return Alarm.AlarmSound.NOISE;
            else if (get_sound() == "BARKING") return Alarm.AlarmSound.BARKING;
            else if (get_sound() == "SUBWAY") return Alarm.AlarmSound.SUBWAY;
            else if (get_sound() == "SIRENS") return Alarm.AlarmSound.SIRENS;
            else return Alarm.AlarmSound.NONE;
        }

        /// <summary>
        /// This is a helper for the SetButtonClicked event in the AddEdit view.
        /// </summary>
        public void SetEventHelper()
        {
            if (checked_check())
            {
                if (Editing)
                {
                    AddItem2SpecificSpot(new Alarm(get_time(), Alarm.State.ON, GetSound()));
                    hide();
                }
                else
                {
                    AddItem2List(new Alarm(get_time(), Alarm.State.ON, GetSound()));
                    hide();
                }
            }
            else
            {
                if (Editing)
                {
                    AddItem2SpecificSpot(new Alarm(get_time(), Alarm.State.OFF, GetSound()));
                    hide();
                }
                else
                {
                    AddItem2List(new Alarm(get_time(), Alarm.State.OFF, GetSound()));
                    hide();
                }
            }
        }

        /// <summary>
        /// This makes a new AddEdit View.
        /// </summary>
        public void MakeNewAddEdit()
        {
            edit_new_alarm();
        }
    }
}
