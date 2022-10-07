using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Trill_Alarm
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

    public class Controller
    {
        //// Delegates from Alarm501 ////

        /// <summary>
        /// This adds an alarm to the list of alarms.
        /// </summary>
        Add2AlarmViewList add_alarm;

        /// <summary>
        /// This retrieves a specific item from the alarm_list using an index.
        /// </summary>
        GetSpecificItem get_specific;

        /// <summary>
        /// This retrieves the selected item in the alarm_list.
        /// </summary>
        GetSelectedItem get_selected;

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

        ////////////////////////////////

        //// Delegates from AddEdit ////

        /// <summary>
        /// This sets the time.
        /// </summary>
        SetTime set;

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
        /// The retrieves a bool value of whether or not the check_on checkbox is checked.
        /// </summary>
        CheckedChanged_DEL checked_check;

        /// <summary>
        /// The retrieves a bool value of whether or not the ux_chickenAlarm checkbox is checked.
        /// </summary>
        ChickenChecked_DEL chicken_check;

        /// <summary>
        /// The retrieves a bool value of whether or not the ux_noiseAlarm checkbox is checked.
        /// </summary>
        NoiseChecked_DEL noise_check;

        /// <summary>
        /// The retrieves a bool value of whether or not the ux_dogAlarm checkbox is checked.
        /// </summary>
        DogChecked_DEL dog_check;

        /// <summary>
        /// The retrieves a bool value of whether or not the ux_subwayAlarm checkbox is checked.
        /// </summary>
        SubwayChecked_DEL subway_check;

        /// <summary>
        /// The retrieves a bool value of whether or not the ux_sirenAlarm checkbox is checked.
        /// </summary>
        SirenChecked_DEL siren_check;

        /// <summary>
        /// This enables or diables the ux_chickenAlarm checkbox.
        /// </summary>
        ChickenOnOff_DEL chicken_onoff;

        /// <summary>
        /// This enables or diables the ux_noiseAlarm checkbox.
        /// </summary>
        NoiseOnOff_DEL noise_onoff;

        /// <summary>
        /// This enables or diables the ux_dogAlarm checkbox.
        /// </summary>
        DogOnOff_DEL dog_onoff;

        /// <summary>
        /// This enables or diables the ux_subwayAlarm checkbox.
        /// </summary>
        SubwayOnOff_DEL subway_onoff;

        /// <summary>
        /// This enables or diables the ux_sirenAlarm checkbox.
        /// </summary>
        SirenOnOff_DEL siren_onoff;

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
        /// <param name="chicken_c">This is the ChickenChecked_DEL Delegate.</param>
        /// <param name="noise_c">This is the NoiseChecked_DEL Delegate.</param>
        /// <param name="dog_c">This is the DogChecked_DEL Delegate.</param>
        /// <param name="subway_c">This is the SubwayChecked_DEL Delegate.</param>
        /// <param name="siren_c">This is the SirenChecked_DEL Delegate.</param>
        /// <param name="chicken_o">This is the ChickenOnOff_DEL Delegate.</param>
        /// <param name="noise_o">This is the NoiseOnOff_DEL Delegate.</param>
        /// <param name="dog_o">This is the DogOnOff_DEL Delegate.</param>
        /// <param name="subway_o">This is the SubwayOnOff_DEL Delegate.</param>
        /// <param name="siren_o">This is the SirenOnOff_DEL Delegate.</param>
        /// <param name="time_value">This is the GetTimeSelectValue_DEL Delegate.</param>
        /// <param name="h">This is the HideView_DEL Delegate.</param>
        public Controller(Add2AlarmViewList a2a, GetSpecificItem getspec, GetSelectedItem getselec, EditButtonOnOff_DEL edit_button,
            SnoozeButtonOnOff_DEL snooze_button, StopButtonOnOff_DEL stop_button, ChangeAlarmWentOffText_DEL changeT, ChangeAlarm_List_DEL changeL,
            SnoozeTimeValue_DEL value, SetTime st, CheckOnOff_DEL chk, CheckedChanged_DEL check_c, ChickenChecked_DEL chicken_c, NoiseChecked_DEL noise_c, 
            DogChecked_DEL dog_c, SubwayChecked_DEL subway_c, SirenChecked_DEL siren_c, ChickenOnOff_DEL chicken_o, NoiseOnOff_DEL noise_o, 
            DogOnOff_DEL dog_o, SubwayOnOff_DEL subway_o, SirenOnOff_DEL siren_o, GetTimeSelectValue_DEL time_value, HideView_DEL h)
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

            // These are from the AddEdit view.
            set = st;
            hide = h;
            check_onoff = chk;
            get_time = time_value;
            checked_check = check_c;
            chicken_check = chicken_c;
            noise_check = noise_c;
            dog_check = dog_c;
            subway_check = subway_c;
            siren_check = siren_c;
            chicken_onoff = chicken_o;
            noise_onoff = noise_o;
            dog_onoff = dog_o;
            subway_onoff = subway_o;
            siren_onoff = siren_o;
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
        public void ReadFile()
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
                    AddItem2List(a);
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
            if (a.Status == Alarm.State.ON) return text[1] + " " + text[2] + "  ON";
            else if (a.Status == Alarm.State.OFF) return text[1] + " " + text[2] + "  OFF";
            else if (a.Status == Alarm.State.GOING_OFF) return text[1] + " " + text[2] + "  GOING OFF";
            else if (a.Status == Alarm.State.STOPPED) return text[1] + " " + text[2] + "  STOPPED";
            else return text[1] + " " + text[2] + "  SNOOZED";
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
            else MessageBox.Show("Can't make any more alarms!");
        }

        /// <summary>
        /// This adds an edited alarm to the list.
        /// </summary>
        /// <param name="a">Alarm to add to the list.</param>
        public void AddItem2SpecificSpot(Alarm a)
        {
            if(alarmList.Count < 6)
            {
                alarmList[Placing] = a;
                change_list(Placing, a);
            }
            else MessageBox.Show("Can't make any more alarms!");
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
        /// This starts the internal timer for the application.
        /// </summary>
        /// <param name="a">This is the Alarm501 view to synchronize the timer to.</param>
        public void StartTimer(Alarm501 a)
        {
            System.Timers.Timer myTimer = new System.Timers.Timer(1000);
            myTimer.Elapsed += CheckAlarms;
            myTimer.SynchronizingObject = a;
            myTimer.AutoReset = true;
            myTimer.Start();
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
                AddEdit addEdit2 = new();
                addEdit2.SetConstructor(ChickenChangedHelper, NoiseChangedHelper, DogChangedHelper, SubwayChangedHelper, SirenChangedHelper, 
                    SetEventHelper);

                if (alarm.Status == Alarm.State.ON) CheckTheBox(true);
                else if (alarm.Status == Alarm.State.OFF) CheckTheBox(false);

                int i = 0;
                while (get_specific(i) != get_selected()) i++;
                Placing = i;

                SetTheTime(alarm.Time);
                addEdit2.Show();
            }
        }

        /// <summary>
        /// This is a method that retrieves the chosen sound for the alarm from the AddEdit view.
        /// </summary>
        /// <returns>Returns an AlarmSound enum value of the sound type.</returns>
        public Alarm.AlarmSound GetSound()
        {
            if (chicken_check() == true) return Alarm.AlarmSound.CHICKEN;
            else if (noise_check() == true) return Alarm.AlarmSound.NOISE;
            else if (dog_check() == true) return Alarm.AlarmSound.BARKING;
            else if (subway_check() == true) return Alarm.AlarmSound.SUBWAY;
            else if (siren_check() == true) return Alarm.AlarmSound.SIRENS;
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
            AddEdit addEdit = new();
            addEdit.SetConstructor(ChickenChangedHelper, NoiseChangedHelper, DogChangedHelper, SubwayChangedHelper, SirenChangedHelper, SetEventHelper);
            addEdit.Show();
        }

        /// <summary>
        /// This is a helper for the ChickenChanged event in the AddEdit view.
        /// </summary>
        public void ChickenChangedHelper()
        {
            if (chicken_check() == true)
            {
                dog_onoff(false);
                noise_onoff(false);
                siren_onoff(false);
                subway_onoff(false);
            }
            else
            {
                dog_onoff(true);
                noise_onoff(true);
                siren_onoff(true);
                subway_onoff(true);
            }
        }

        /// <summary>
        /// This is a helper for the NoiseChanged event in the AddEdit view.
        /// </summary>
        public void NoiseChangedHelper()
        {
            if (noise_check() == true)
            {
                dog_onoff(false);
                chicken_onoff(false);
                siren_onoff(false);
                subway_onoff(false);
            }
            else
            {
                dog_onoff(true);
                chicken_onoff(true);
                siren_onoff(true);
                subway_onoff(true);
            }
        }

        /// <summary>
        /// This is a helper for the DogChanged event in the AddEdit view.
        /// </summary>
        public void DogChangedHelper()
        {
            if (dog_check() == true)
            {
                noise_onoff(false);
                chicken_onoff(false);
                siren_onoff(false);
                subway_onoff(false);
            }
            else
            {
                chicken_onoff(true);
                noise_onoff(true);
                siren_onoff(true);
                subway_onoff(true);
            }
        }

        /// <summary>
        /// This is a helper for the SubwayChanged event in the AddEdit view.
        /// </summary>
        public void SubwayChangedHelper()
        {
            if (subway_check() == true)
            {
                dog_onoff(false);
                noise_onoff(false);
                siren_onoff(false);
                chicken_onoff(false);
            }
            else
            {
                dog_onoff(true);
                noise_onoff(true);
                siren_onoff(true);
                chicken_onoff(true);
            }
        }

        /// <summary>
        /// This is a helper for the SirenChanged event in the AddEdit view.
        /// </summary>
        public void SirenChangedHelper()
        {
            if (siren_check() == true)
            {
                dog_onoff(false);
                noise_onoff(false);
                chicken_onoff(false);
                subway_onoff(false);
            }
            else
            {
                dog_onoff(true);
                noise_onoff(true);
                chicken_onoff(true);
                subway_onoff(true);
            }
        }
    }
}
