using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alarm_Library;

namespace Alarm_GUI
{
    public partial class AddEdit : Form
    {
        //// Delegates from Controller ////

        /// <summary>
        /// This is the helper for the SetButtonClick
        /// </summary>
        SetEventHelper_DEL set_helper;

        MakeSound2String_DEL sound_string;

        ///////////////////////////////////

        /// <summary>
        /// This check for an alarm edit.
        /// </summary>
        public bool reset;

        /// <summary>
        /// This is the constructor.
        /// </summary>
        /// <param name="alarm">This is the alarm form reference.</param>
        public AddEdit()
        {
            InitializeComponent();
            time_select.Format = DateTimePickerFormat.Time;

            List<string> sound_list = Enum.GetNames(typeof(Alarm.AlarmSound)).ToList();
            sound_dropdown.DataSource = sound_list;
        }

        /// <summary>
        /// This is the AddEdit SetContructor.
        /// 
        /// This adds the references to the delegates.
        /// </summary>
        /// <param name="set_h">This is the SetEventHelper Delegate.</param>
        public void SetConstructor(SetEventHelper_DEL set_h, MakeSound2String_DEL set_s)
        {
            set_helper = set_h;
            sound_string = set_s;
        }

        public void Edit(Alarm a)
        {
            SetTime(a.Time);
            CheckedOnOff(a.Status != Alarm.State.OFF);
            SetSound(sound_string(a.Sound));
            this.Show();
        }

        public void Add()
        {
            Alarm a = new();
            Edit(a);
        }

        /// <summary>
        /// Event handler for when the form is close with the red X.
        /// </summary>
        /// <param name="sender">This is the button.</param>
        /// <param name="e">These are the arguments.</param>
        private void AddEdit_FormClosing(object sender, FormClosingEventArgs e) { this.Hide(); e.Cancel = true; }

        /// <summary>
        /// Event handler for the cancel button.
        /// </summary>
        /// <param name="sender">This is the cancel button.</param>
        /// <param name="e">These are the arguments.</param>
        private void cancel_button_Click(object sender, EventArgs e) { this.Hide(); }

        /// <summary>
        /// Event handler for the set button.
        /// </summary>
        /// <param name="sender">This is the set button.</param>
        /// <param name="e">These are the arguments.</param>
        private void set_button_Click(object sender, EventArgs e)
        {
            time_select.Format = DateTimePickerFormat.Custom;
            time_select.CustomFormat = "hh:mm:ss tt";
            set_helper();
        }

        /// <summary>
        /// This sets the time_select value.
        /// </summary>
        /// <param name="t">This is the value to change to.</param>
        public void SetTime(DateTime t)
        {
            time_select.Value = t;
            // reset = true;
        }

        /// <summary>
        /// This hides the view.
        /// </summary>
        public void HideView() { this.Hide(); }

        /// <summary>
        /// The retrieves the time_select value.
        /// </summary>
        /// <returns>Returns the DateTime from the value.</returns>
        public DateTime GetTimeSelectValue() { return time_select.Value; }

        /// <summary>
        /// This returns the Alarm Sound.
        /// </summary>
        /// <returns>Returns the Alarm Sound.</returns>
        public string GetSound() { return (string)sound_dropdown.SelectedItem; }

        /// <summary>
        /// This sets the sound that is shown in the dropdown.
        /// </summary>
        /// <param name="sound">This is the sound to show.</param>
        public void SetSound(string sound) { sound_dropdown.SelectedItem = sound; }

        /// <summary>
        /// Retrieves whether or not the On checkbox is checked
        /// </summary>
        /// <returns>Returns whether or not the checkbox is checked,</returns>
        public bool CheckedChanged() { return check_on.Checked; }

        /// <summary>
        /// Changes the enabled value of the On checkbox.
        /// </summary>
        /// <param name="b">This is the value to change the enabled property to.</param>
        public void CheckedOnOff(bool b) { check_on.Checked = b; }
    }
}
