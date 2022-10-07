using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Text.Json;

namespace Trill_Alarm
{
    public partial class Alarm501 : Form
    {
        //// Delegates from Controller ////

        /// <summary>
        /// Delegate to read the text file.
        /// </summary>
        ReadFile_DEL read;

        /// <summary>
        /// Delegate to make text from an alarm.
        /// </summary>
        MakeAlarmText_DEL text;

        /// <summary>
        /// Delegate to write to the text file.
        /// </summary>
        Write2TXT_DEL write;

        /// <summary>
        /// Delegate to check the alarm to see if one has gone off.
        /// </summary>
        CheckAlarms check_alarm;

        /// <summary>
        /// This starts the internal timer.
        /// </summary>
        StartTimer_DEL start_timer;

        /// <summary>
        /// This creates a new AddEdit view.
        /// </summary>
        MakeNewAddEdit_DEL make_edit;

        /// <summary>
        /// This is the helper for the SelectedChanged Event.
        /// </summary>
        SelectedEventHelper_DEL selected_helper;

        /// <summary>
        /// This is the helper for the StopButtonClicked Event.
        /// </summary>
        StopEventHelper_DEL stop_helper;

        /// <summary>
        /// This is the helper for the SnoozeButtonClicked Event.
        /// </summary>
        SnoozeEventHelper_DEL snooze_helper;

        /// <summary>
        /// This is the helper for the EditButtonClicked Event.
        /// </summary>
        EditEventHelper_DEL edit_helper;

        ///////////////////////////////////

        /// <summary>
        /// This is the list number of the edited alarm.
        /// </summary>
        public int placing;

        /// <summary>
        /// List of alarms.
        /// </summary>
        public List<Alarm> alarmList = new List<Alarm>();

        /// <summary>
        /// Constructor for the alarm.
        /// </summary>
        public Alarm501() { InitializeComponent(); }


        /// <summary>
        /// This is the Alarm501 SetConstructor.
        /// 
        /// This adds the references to the delegates.
        /// </summary>
        /// <param name="rf">This is the ReadFile Delegate.</param>
        /// <param name="mat">This is the MakeAlarmText Delegate.</param>
        /// <param name="wr">This is the Write2TXT Delegate.</param>
        /// <param name="ca">This is the ChackAlarms Delegate.</param>
        /// <param name="st">This is the StartTimer Delegate.</param>
        /// <param name="select">This is the SelectedEventHelper Delegate.</param>
        /// <param name="stop">This is the StopEventHelper Delegate.</param>
        /// <param name="snooze">This is the SnoozeEventHelper Delegate.</param>
        /// <param name="edit">THis is the EditEventHelper Delegate.</param>
        public void SetConstructor(ReadFile_DEL rf, MakeAlarmText_DEL mat, Write2TXT_DEL wr, CheckAlarms ca, StartTimer_DEL st,
            SelectedEventHelper_DEL select, StopEventHelper_DEL stop, SnoozeEventHelper_DEL snooze, EditEventHelper_DEL edit, MakeNewAddEdit_DEL newEdit)
        {
            read = rf;
            text = mat;
            write = wr;
            check_alarm = ca;
            start_timer = st;
            selected_helper = select;
            stop_helper = stop;
            snooze_helper = snooze;
            edit_helper = edit;
            make_edit = newEdit;
        }

        /// <summary>
        /// This method checks the alarms to see if they have gone off.
        /// </summary>
        /// <param name="sender">sender.</param>
        /// <param name="e">These are the arguments.</param>
        private void CheckAlarms(object sender, ElapsedEventArgs e) { check_alarm(sender, e); }

        /// <summary>
        /// Event handler for the add button.
        /// </summary>
        /// <param name="sender">This is the add_button.</param>
        /// <param name="e">These are the arguments.</param>
        private void add_button_Click(object sender, EventArgs e) { make_edit(); }

        /// <summary>
        /// Event handler for the edit button.
        /// </summary>
        /// <param name="sender">This is the edit_button.</param>
        /// <param name="e">These are the arguments.</param>
        private void edit_button_Click(object sender, EventArgs e) { edit_helper(); }

        /// <summary>
        /// Event handler for the snooze button.
        /// </summary>
        /// <param name="sender">This is the snooze_button.</param>
        /// <param name="e">These are the arguments.</param>
        private void snooze_button_Click(object sender, EventArgs e) { snooze_helper(); }

        /// <summary>
        /// Event handler for the stop button.
        /// </summary>
        /// <param name="sender">This is the stop_button.</param>
        /// <param name="e">These are the arguments.</param>
        private void stop_button_Click(object sender, EventArgs e) { stop_helper(); }

        /// <summary>
        /// Event hanlder for the list.
        /// </summary>
        /// <param name="sender">This is the alarm_list ListBox.</param>
        /// <param name="e">These are the arguments.</param>
        private void alarm_list_SelectedIndexChanged(object sender, EventArgs e) { selected_helper(); }

        /// <summary>
        /// Event handler for when the application closes.
        /// 
        /// This event writes the alarms in the list to the text file 
        /// to save them for later use.
        /// </summary>
        /// <param name="sender">This is the Form.</param>
        /// <param name="e">These are the arguments.</param>
        private void Alarm501_FormClosing(object sender, FormClosingEventArgs e) { write(); }

        /// <summary>
        /// Event for when the application opens.
        /// 
        /// This event starts the internal timer for the application
        /// as well as reads the text file and puts the read alarms into
        /// the list.
        /// </summary>
        /// <param name="sender">This is the Form.</param>
        /// <param name="e">These are the arguments.</param>
        private void Alarm501_Load(object sender, EventArgs e)
        {
            start_timer(this);
            read();
        }

        /// <summary>
        /// This adds an item to the alarm listbox.
        /// </summary>
        /// <param name="item">This is the string to add to the listbox list.</param>
        public void AddAlarmItem(string item) { alarm_list.Items.Add(item); }

        /// <summary>
        /// This gets the specific string value from the alarm_list listbox.
        /// </summary>
        /// <param name="i">This is the index of the item to retrieve.</param>
        /// <returns>Returns a string from the listbox list.</returns>
        public string GetSpecific(int i) { return (string)alarm_list.Items[i]; }

        /// <summary>
        /// This gets the item that is selected from the alarm_list listbox.
        /// </summary>
        /// <returns>Returns the string that is being selected in the listbox.</returns>
        public string GetSelected() { return (string)alarm_list.SelectedItem; }

        /// <summary>
        /// This turns the edit button on or off.
        /// </summary>
        /// <param name="b">This is the bool that determines if the button will be on or off.</param>
        public void EditButtonOnOff(bool b) { edit_button.Enabled = b; }

        /// <summary>
        /// This turns the snooze button on or off.
        /// </summary>
        /// <param name="b">This is the bool that determines if the button will be on or off.</param>
        public void SnoozeButtonOnOff(bool b) { snooze_button.Enabled = b; }

        /// <summary>
        /// This turns the stop button on or off.
        /// </summary>
        /// <param name="b">This is the bool that determines if the button will be on or off.</param>
        public void StopButtonOnOff(bool b) { stop_button.Enabled = b; }

        /// <summary>
        /// This changes the alarmwentoff text.
        /// </summary>
        /// <param name="sound">This is the text to show.</param>
        public void ChangeAlarmWentOffText(string sound) { alarmwentoff_text.Text = sound; }

        /// <summary>
        /// This changes one specific item in the alarm_list listbox.
        /// </summary>
        /// <param name="index">This is the index of the item to change.</param>
        /// <param name="a">This is the alarm to change the old one to.</param>
        public void ChangeAlarm_List(int index, Alarm a) { alarm_list.Items[index] = text(a); }

        /// <summary>
        /// This retrieve the value in the snoozetime numericupdown.
        /// </summary>
        /// <returns>Returns the value in the numericupdown.</returns>
        public double SnoozeTimeValue() { return (double)ux_snoozetime.Value; }
    }
}
